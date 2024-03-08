using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsTimer
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Lesson> Lessons => Set<Lesson>();
        public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=lessons.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Day>().HasData(
                new Day { DayId = 1, DayWeek = "Monday" },
                new Day { DayId = 2, DayWeek = "Tuesday" },
                new Day { DayId = 3, DayWeek = "Wednesday" },
                new Day { DayId = 4, DayWeek = "Thursday" },
                new Day { DayId = 5, DayWeek = "Friday" },
                new Day { DayId = 6, DayWeek = "Saturday" });
        }
    }
}
