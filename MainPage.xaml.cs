//using MetalKit;
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
            DateTime todayDateTime = DateTime.Today; // Поточна дата
            DateTime tomorrowDateTime = todayDateTime.AddDays(1); // Додати один день
            DayOfWeek tomorrow = tomorrowDateTime.DayOfWeek; // Отримати день тижня для завтрашньої дати
            var lessons = db.Lessons.Where(lesson => lesson.DayWeek == today.ToString() && lesson.Visible).ToList();
            if (lessons.Count == 0) return;
            var lessonsTom = db.Lessons.Where(lesson => lesson.DayWeek == tomorrow.ToString() && lesson.Visible).ToList();
            timer = new Timer(async (state) => await RefreshPage(lessons, lessonsTom), null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }
        private async Task RefreshPage(List<Lesson> lessons, List<Lesson> lessonsTom)
        {
            TimeSpan currentTimeSpan = GetTimeOfDay();
            if (GetTodayDay().ToString() != "Sunday" || GetTodayDay().ToString() != "Saturday")
            {
                foreach (var lesson in lessons)
                {
                    // Current Time в межах пари.
                    if (currentTimeSpan >= lesson.TimeStart && currentTimeSpan <= lesson.TimeEnd)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            startEnd.Text = "До кінця ";
                            mainNameLesson.Text = $"{lesson.Name} ";
                            // Calc to end of lesson every min.
                            TimeSpan timeLeft = lesson.TimeEnd - currentTimeSpan;
                            mainEndLesson.Text = (timeLeft.Hours == 0) ? $"{timeLeft.Minutes}" : $"{timeLeft.Hours}:{timeLeft.Minutes:00}";
                            if (timeLeft.Hours != 0)
                            {
                                hourOrMinutes.Text = "год.";
                            }
                            else
                            {
                                hourOrMinutes.Text = "хв.";
                            }
                        });

                        break;
                    }
                    // Якщо поза межами пар
                    else
                    {
                        if (!(lesson.TimeEnd - currentTimeSpan <= TimeSpan.Zero))
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                startEnd.Text = "До початку ";
                                mainNameLesson.Text = $"{lesson.Name} ";
                                TimeSpan timeLeftToNextLesson = lesson.TimeStart - currentTimeSpan;
                                mainEndLesson.Text = (timeLeftToNextLesson.Hours == 0) ? $"{timeLeftToNextLesson.Minutes}" : $"{timeLeftToNextLesson.Hours}:{timeLeftToNextLesson.Minutes:00}";
                                if (timeLeftToNextLesson.Hours != 0)
                                {
                                    hourOrMinutes.Text = "год.";
                                }
                                else
                                {
                                    hourOrMinutes.Text = "хв.";
                                }
                            });
                            break;
                        }
                    }
                }
                int enabled = 0;
                int active = 0;
                List<Frame> framesToday = [TodayL1, TodayL2, TodayL3, TodayL4];
                foreach (var lesson in lessons)
                {
                    if (!(lesson.TimeStart - currentTimeSpan < TimeSpan.Zero))
                    {
                        enabled++;
                    }
                }
                active = enabled;
                for (int i = 0; i < lessons.Count; i++)
                {
                    int index = i;
                    if (enabled == 0)
                    {
                        Device.BeginInvokeOnMainThread(() => framesToday[index].IsVisible = false);
                    }
                    else
                    {
                        if (!(lessons[index].TimeStart - currentTimeSpan < TimeSpan.Zero))
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                framesToday[index].IsVisible = true;
                                var stackL = (HorizontalStackLayout)framesToday[index].Content;
                                var nameLess = (Label)stackL.Children[0];
                                var less_Name = lessons[index].Name;
                                nameLess.Text = less_Name;
                                var timeSt = (Label)stackL.Children[2];
                                var timeEn = (Label)stackL.Children[4];
                                timeSt.Text = lessons[index].TimeStart.ToString(@"hh\:mm");
                                timeEn.Text = lessons[index].TimeEnd.ToString(@"hh\:mm");
                            });
                            enabled--;
                        }
                    }
                }
                if (active == 0) Device.BeginInvokeOnMainThread(() => NextLessonsTab.IsVisible = false);
                else Device.BeginInvokeOnMainThread(() => NextLessonsTab.IsVisible = true);
            }
            if ((GetTodayDay() + 1).ToString() != "Sunday" || (GetTodayDay() + 1).ToString() != "Saturday")
            {
                List<Frame> framesTom = [TomL1, TomL2, TomL3, TomL4, TomL5];
                int enabled = 0;
                int active = 0;
                foreach (var lesson in lessonsTom)
                {
                    enabled++;
                }
                active = enabled;
                for (int k = 0; k < lessonsTom.Count; k++)
                {
                    // Збереження локальної змінної для МейнТреду, який бере змінні посиланням.
                    int index = k;
                    if (enabled == 0)
                    {
                        Device.BeginInvokeOnMainThread(() => framesTom[index].IsVisible = false);
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            framesTom[index].IsVisible = true;
                            var stackL = (HorizontalStackLayout)framesTom[index].Content;
                            var nameLess = (Label)stackL.Children[0];
                            nameLess.Text = lessonsTom[index].Name;
                            var timeSt = (Label)stackL.Children[2];
                            var timeEn = (Label)stackL.Children[4];
                            timeSt.Text = lessonsTom[index].TimeStart.ToString(@"hh\:mm");
                            timeEn.Text = lessonsTom[index].TimeEnd.ToString(@"hh\:mm");
                        });
                        enabled--;
                    }
                }
                if (active == 0) Device.BeginInvokeOnMainThread(() => TomorrowLessonsTab.IsVisible = false);
                else Device.BeginInvokeOnMainThread(() => TomorrowLessonsTab.IsVisible = true);
            }
        }

        private async void SettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }

}
