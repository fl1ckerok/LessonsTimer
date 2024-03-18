using Microsoft.Maui.Controls;
using System;
using System.Linq.Expressions;
using System.Threading;

namespace LessonsTimer
{
    public partial class MainPage : ContentPage
    {
        List<Lesson> TodayLessons;
        Timer timer;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            LoadData();
        }

        public DayOfWeek GetTodayDay() 
        {
            DateTime currentTime = DateTime.Now;
            return currentTime.DayOfWeek;
        }

        public TimeSpan GetTimeOfDay() 
        {
            DateTime currentTime = DateTime.Now;
            return currentTime.TimeOfDay;
        }

        private void LoadData()
        {
            using ApplicationContext db = new();
            DayOfWeek today = GetTodayDay();
            var lessons = db.Lessons.Where(lesson => lesson.DayWeek == today.ToString()).ToList();
            if (lessons.Count == 0) return;
            TodayLessons = lessons;
            timer = new Timer(async (state) => await RefreshPage(TodayLessons), null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }
        private async Task RefreshPage(List<Lesson> lessons) 
        {
            TimeSpan currentTimeSpan = GetTimeOfDay();
            foreach (var lesson in lessons) {
                // Current Time в межах пари.
                if (currentTimeSpan >= lesson.TimeStart && currentTimeSpan <= lesson.TimeEnd) {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        startEnd.Text = "До кінця ";
                        mainNameLesson.Text = lesson.Name;
                        // Calc to end of lesson every min.
                        TimeSpan timeLeft = lesson.TimeEnd - currentTimeSpan;
                        mainEndLesson.Text = (timeLeft.Hours == 0) ? $"{timeLeft.Minutes}" : $"{timeLeft.Hours}:{timeLeft.Minutes:00}";
                    });

                    break;
                } 
                // Якщо поза межами пар
                else
                {
                    if (lesson.TimeEnd - currentTimeSpan <= TimeSpan.Zero)
                    {
                        lessons.Remove(lesson);
                    } else 
                    {
                        Device.BeginInvokeOnMainThread(() =>
                            {
                                startEnd.Text = "До початку ";
                                mainNameLesson.Text = lesson.Name;
                                TimeSpan timeLeftToNextLesson = lesson.TimeStart - currentTimeSpan;
                                mainEndLesson.Text = $"{timeLeftToNextLesson.Minutes}";
                            }
                        );
                    }
                }
            }
        }

        private async void SettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }

}
