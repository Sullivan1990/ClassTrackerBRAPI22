using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassTrackerBRAPI22.Entities
{
    public class Unit
    {
        public int UnitId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Foreign Key
        public int TafeClassId { get; set; }

        // Navigation Properties
        public TafeClass TafeClass { get; set; }
    }
}