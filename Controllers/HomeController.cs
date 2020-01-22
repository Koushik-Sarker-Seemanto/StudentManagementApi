using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsProject.Models;
using ServicesManager.ServiceClasses;
using ServicesManager.ServiceInterfaces;


namespace StudentManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStudentManager _studentManager;

        public HomeController(ILogger<HomeController> logger, IStudentManager studentManager)
        {
            _logger = logger;
            _studentManager = studentManager;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> tempStudents = _studentManager.RetriveAll();
            return Ok(tempStudents);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Student student = _studentManager.RetriveById(id);
            return Ok(student);
        }
        
        [HttpPost]
        public IActionResult Add([FromBody]Student student)
        {
            if (student == null)
                return BadRequest();
            
            _studentManager.Create(student);
            return new CreatedAtActionResult(nameof(Get), "Home", new { id = student.Id }, student);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody]Student student)
        {
            Student st = _studentManager.RetriveById(id);
            if (st != null)
            {
                _studentManager.Update(student);
            }

            return Ok(student);
        }
    
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Student st = _studentManager.RetriveById(id);
            if (st != null)
            {
                _studentManager.Delete(id);
            }
            return Ok(st);
        }
        
    }
}