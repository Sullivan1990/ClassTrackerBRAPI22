using ClassTrackerBRAPI22.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassTrackerBRAPI22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ClassTrackerContext _context;

        public TeacherController(ClassTrackerContext context)
        {
            _context = context;
        }

        // GET: api/<TeacherController>
        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            return _context.Teachers;
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public ActionResult<Teacher> Get(int id)
        {
            var teacher = _context.Teachers.Find(id);

            if (teacher == null)
            {
                return NotFound();
            }
            return teacher;

        }

        [HttpGet]
        [Route("GetWithChildren")]
        public ActionResult<Teacher> GetWithChildren(int id)
        {
            var teacher = _context.Teachers.Where(c => c.TeacherId == id)
                                           .Include(c => c.TafeClasses)
                                           .FirstOrDefault();

            if (teacher == null)
            {
                return NotFound();
            }
            return teacher;

        }

        // POST api/<TeacherController>
        [HttpPost]
        public ActionResult<Teacher> Post(Teacher teacher)
        {
            if(teacher == null)
            {
                return BadRequest();
            }

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return CreatedAtAction("Post", teacher);
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}