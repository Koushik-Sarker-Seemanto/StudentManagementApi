using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagementApi.Models;

namespace StudentManagementApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private IStudentRepository _repository;
        

        public HomeController(ILogger<HomeController> logger, IStudentRepository repository)
        {
            _logger = logger;
            this._repository = repository;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var tempStudents = _repository.GetAll();
            return Ok(tempStudents);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Student student = _repository.GetById(id);
            return Ok(student);
        }
        
        [HttpPost]
        public IActionResult Add([FromBody]Student student)
        {
            if (student == null)
                return BadRequest();
            
            _repository.Insert(student);
            return new CreatedAtActionResult(nameof(Get), "Home", new { id = student.Id }, student);
            //return Ok(student);
            //return CreatedAtAction(nameof(Get), new {Id = student.Id}, student);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody]Student student)
        {
            Student st = _repository.GetById(id);
            if (st != null)
            {
                _repository.Update(student);
            }

            return Ok(student);
        }
    
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Student st = _repository.GetById(id);
            if (st != null)
            {
                _repository.Delete(id);
            }
            return Ok(st);
        }
        
    }
}