using ClassTrackerBRAPI22.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        #region Setup

        private readonly ClassTrackerContext _context;

        public TeacherController(ClassTrackerContext context)
        {
            _context = context;
        }

        #endregion

        #region CRUD Endpoints

        // GET: api/<TeacherController>
        [Authorize]
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

        // POST api/<TeacherController>
        [HttpPost]
        public ActionResult<Teacher> Post(Teacher teacher)
        {
            if (teacher == null)
            {
                return BadRequest();
            }

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return CreatedAtAction("Post", teacher);
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public ActionResult<Teacher> Put(int id, [FromBody] Teacher teacher)
        {
            if (id != teacher.TeacherId)
            {
                return BadRequest();
            }

            _context.Teachers.Update(teacher);
            _context.SaveChanges();

            return Ok(teacher);
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var teacher = _context.Teachers.Find(id);

            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();

        }

        #endregion

    }
}