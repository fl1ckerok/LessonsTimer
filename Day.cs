using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsTimer
{
    public class Day
    {
        public int DayId { get; set; }
        public string? DayWeek { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; } = [];
    }
}
