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
    public class UnitController : ControllerBase
    {

        #region Setup

        private readonly ClassTrackerContext _context;

        public UnitController(ClassTrackerContext context)
        {
            _context = context;
        }

        #endregion

        #region CRUD Endpoints

        // GET: api/<UnitController>
        [HttpGet]
        public IEnumerable<Unit> Get()
        {
            return _context.Units;
        }

        // GET api/<UnitController>/5
        [HttpGet("{id}")]
        public ActionResult<Unit> Get(int id)
        {
            var unit = _context.Units.Find(id);

            if (unit == null)
            {
                return NotFound();
            }
            return unit;

        }

        // POST api/<UnitController>
        [HttpPost]
        public ActionResult<Unit> Post(Unit unit)
        {
            if (unit == null)
            {
                return BadRequest();
            }

            _context.Units.Add(unit);
            _context.SaveChanges();

            return CreatedAtAction("Post", unit);
        }

        // PUT api/<UnitController>/5
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Unit> Put(int id, [FromBody] Unit unit)
        {
            if (id != unit.UnitId)
            {
                return BadRequest();
            }

            _context.Units.Update(unit);
            _context.SaveChanges();

            return Ok(unit);
        }

        // DELETE api/<UnitController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var unit = _context.Units.Find(id);

            if (unit != null)
            {
                _context.Units.Remove(unit);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        #endregion

        #region Custom Endpoints

        /// <summary>
        /// Get all units for a given TafeClass Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("UnitsForTafeClassId")]
        public ActionResult UnitsForTafeClassId(int id)
        {
            return Ok(_context.Units.Where(c => c.TafeClassId == id));
        }

        #endregion





    }
}
