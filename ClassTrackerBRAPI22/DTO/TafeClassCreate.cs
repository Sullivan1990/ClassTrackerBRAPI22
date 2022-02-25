using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassTrackerBRAPI22.DTO
{
    public class TafeClassCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime? StartTime { get; set; }
        public int? DurationMinutes { get; set; }
        public int TeacherId { get; set; }
    }
}
