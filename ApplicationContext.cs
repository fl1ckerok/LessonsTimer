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
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Day> Days => Set<Day>();
        public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Отримання шляху до каталогу даних додатка на платформі Android
            string androidFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            // Отримання шляху до каталогу даних додатка на платформі iOS
            // Для iOS ви можете використовувати статичний шлях, наприклад, 
            // var iosFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library");
            string iosFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library");

            // Об'єднання шляху відповідно до платформи
            string dbFilePath = Path.Combine(androidFolderPath, "lessons.db");
#if __IOS__
            dbFilePath = Path.Combine(iosFolderPath, "lessons.db");
#endif

            // Переконайтеся, що каталог існує
            Directory.CreateDirectory(Path.GetDirectoryName(dbFilePath));


            optionsBuilder.UseSqlite($"Data Source={dbFilePath}");
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
