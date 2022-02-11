using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassTrackerBRAPI22.Entities
{
    public class ClassTrackerContext : DbContext
    {
        public ClassTrackerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TafeClass> TafeClasses { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1, Name = "Steve", Email = "Steve@email.com", Phone = "1234123412" },
                new Teacher { TeacherId = 2, Name = "Jennifer", Email = "Jennifer@email.com", Phone = "5432234523" }
            );
        }
    }
}