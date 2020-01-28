using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ModelsProject.Models;
using ServicesManager.Repositories;
using ServicesManager.ServiceClasses;
using ServicesManager.ServiceInterfaces;


namespace StudentManagementApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<StudentDatabaseSettings>(
                Configuration.GetSection(nameof(StudentDatabaseSettings)));

            services.AddSingleton<IStudentDatabaseSettings>(sp => 
                sp.GetRequiredService<IOptions<StudentDatabaseSettings>>().Value);
            
            services.AddControllers();
            //services.AddSingleton(typeof(IGenericRepository<Student>),typeof(GenericRepository<Student>));
            //services.AddSingleton(typeof(IGenericFactory), typeof(GenericFactory));
            services.AddSingleton(typeof(IGenericRepository), typeof(GenericRepository));

            services.AddSingleton<IStudentManager, StudentManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}