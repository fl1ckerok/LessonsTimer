using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsTimer
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string? DayWeek { get; set; }
        public string? Name { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public bool Visible { get; set; }
        public int DayId { get; set; }
        public virtual Day Day { get; set; } = null!;
    }
}
