using Microsoft.Maui.Controls;
using System;
using System.Threading;

namespace LessonsTimer
{
    public partial class MainPage : ContentPage
    {
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
            var lessons = db.Lessons.Where(Lesson => Lesson.DayWeek == today.ToString).ToList();
            if (lessons.Count == 0) return;
            Timer timer = new Timer(async (state) => await RefreshPage(lessons), null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }

        private void RefreshPage(var lessons) 
        {
            TimeSpan currentTimeSpan = GetTimeOfDay();
            foreach (var lesson in lessons) {
                if (currentTimeSpan >= lesson.TimeStart && currentTimeSpan <= lesson.TimeEnd) {
                    mainNameLesson = lesson.Name;
                    // Calc to end of lesson every min
                    TimeSpan timeLeft = lesson.TimeEnd - currentTimeSpan;
                    mainEndLesson = (timeLeft.Hours == 0) ? $"{timeLeft.Minutes}" : $"{timeLeft.Hours}:{timeLeft.Minutes:00}";
                }
            }
        }

        private async void SettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }

}
