﻿using ASPCoreWebAPICRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly StudentContext context;

        public StudentAPIController(StudentContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> GetStudentById(int id)
        {
           var student=await context.Students.FindAsync(id);

            if (student == null) { 
                return NotFound();  
            }
            return Ok(student); 
        }


        [HttpPost]
        public async Task<ActionResult<List<Student>>> CreateStudent(Student std)
        {
           await context.Students.AddAsync(std);
            await context.SaveChangesAsync();       
            return Ok(std);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Student>>> UpdateStudent(int id,Student std)
        {
            if (id != std.StudentId)
            {
                return BadRequest();
            }
            context.Entry(std).State=EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var std = await context.Students.FindAsync(id); // id find krke
            if (std == null)
            {
                return NotFound();
            }
            context.Students.Remove(std);
            await context.SaveChangesAsync();
            return Ok();
        }


    }
}
