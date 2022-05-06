using ClassTrackerBRAPI22.DTO.ViewModels;
using ClassTrackerBRAPI22.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassTrackerBRAPI22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        // Constructor injection to provide access to database
        private readonly ClassTrackerContext _context;
        public ReportController(ClassTrackerContext context)
        {
            _context = context;
        }

        [HttpGet("TeacherClassCountReport")]
        public IActionResult TeacherClassCountReport(DateTime? from, DateTime? to)
        {

            var teachers = _context.Teachers.Include(c => c.TafeClasses);

            //if(from != null)
            //{
            //    teachers.Where(c => c.Hired > from);
            //}
            //if (to != null)
            //{
            //    teachers.Where(c => c.Hired < to);
            //}

            var teacherclasscountlist = teachers.Select(c => new TeacherClassCount
            {
                TeacherName = c.Name,
                ClassCount = c.TafeClasses.Count
            }).ToList();

            return Ok(teacherclasscountlist);
        }

    }
}
