using ClassTrackerBRAPI22.DTO;
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
    public class TafeClassController : ControllerBase
    {

        #region Setup

        private readonly ClassTrackerContext _context;

        public TafeClassController(ClassTrackerContext context)
        {
            _context = context;
        }

        #endregion

        #region CRUD Endpoints

        // GET: api/<TafeClassController>
        [HttpGet]
        public IEnumerable<TafeClass> Get()
        {
            return _context.TafeClasses;
        }

        // GET api/<TafeClassController>/5
        [HttpGet("{id}")]
        public ActionResult<TafeClass> Get(int id)
        {
            var tafeClass = _context.TafeClasses.Find(id);

            if (tafeClass == null)
            {
                return NotFound();
            }
            return tafeClass;
        }

        // POST api/<TafeClassController>
        // Example DTO usage in place of the full entity
        [HttpPost]
        public ActionResult<TafeClass> Post(TafeClassCreate tafeClass)
        {
            if (tafeClass == null)
            {
                return BadRequest();
            }

            // convert the DTO to an entity
            TafeClass createdTafeClass = new TafeClass()
            {
                Name = tafeClass.Name,
                Description = tafeClass.Description,
                Location = tafeClass.Location,
                StartTime = tafeClass.StartTime,
                DurationMinutes = tafeClass.DurationMinutes,
                TeacherId = tafeClass.TeacherId
            };

            // Save the entity
            _context.TafeClasses.Add(createdTafeClass);

            _context.SaveChanges();

            return CreatedAtAction("Post", createdTafeClass);
        }

        // PUT api/<TafeClassController>/5
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<TafeClass> Put(int id, [FromBody] TafeClass tafeClass)
        {
            if (id != tafeClass.TafeClassId)
            {
                return BadRequest();
            }

            _context.TafeClasses.Update(tafeClass);
            _context.SaveChanges();
            
            return Ok(tafeClass);
        }

        // DELETE api/<TafeClassController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tafeClass = _context.TafeClasses.Find(id);

            if(tafeClass != null)
            {
                _context.TafeClasses.Remove(tafeClass);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        #endregion

        #region Custom Endpoints

        /// <summary>
        /// Get all Tafeclasses for a given TeacherID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("TafeClassesForTeacherId")]
        public ActionResult TafeClassesForTeacherId(int id)
        {
            return Ok(_context.TafeClasses.Where(c => c.TeacherId == id));
        }

        #endregion

    }
}
