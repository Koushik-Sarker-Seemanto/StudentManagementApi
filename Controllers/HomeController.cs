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
        public IActionResult GetAllStudents()
        {
            List<Student> tempStudents = _studentManager.RetrieveAllStudents();
            return Ok(tempStudents);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            Student student = _studentManager.RetrieveStudentById(id);
            return Ok(student);
        }
        
        [HttpPost]
        public IActionResult CreateStudent([FromBody]Student student)
        {
            if (student == null)
                return BadRequest();
            
            Student newStudent = _studentManager.CreateStudent(student);
            return Ok(newStudent);
            //return new CreatedAtActionResult(nameof(GetStudentById), "Home", new { id = student.Id }, student);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id,[FromBody]Student student)
        {
            Student st = _studentManager.RetrieveStudentById(id);
            if (st != null)
            {
                _studentManager.UpdateStudent(student);
            }

            return Ok(student);
        }
    
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            Student student = _studentManager.RetrieveStudentById(id);
            if (student != null)
            {
                _studentManager.DeleteStudent(id);
            }
            return Ok(student);
        }
        
    }
}