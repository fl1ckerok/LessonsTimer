using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsTimer
{
    public class ImageButtonSettings : ImageButton
    {
        string day;
        public ImageButtonSettings(string input_day) : base() 
        {
            Day = input_day;
        }

        public string Day { get; }
    }
}
