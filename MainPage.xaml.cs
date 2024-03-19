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
                                } else
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
                int i = 0;
                List<Frame> framesToday = [TodayL1, TodayL2, TodayL3, TodayL4];
                foreach (var lesson in lessons)
                {
                    if (!(lesson.TimeStart - currentTimeSpan < TimeSpan.Zero))
                    {
                        enabled++;
                    }
                }
                active = enabled;
                foreach (var frame in framesToday)
                {
                    if (enabled == 0)
                    {
                        
                        Device.BeginInvokeOnMainThread(() => frame.IsVisible = false);
                    }
                    else
                    {
                        if (!(lessons[i].TimeStart - currentTimeSpan < TimeSpan.Zero))
                        {
                            Device.BeginInvokeOnMainThread(() => 
                            {
                                frame.IsVisible = true;
                                var stackL = (HorizontalStackLayout)frame.Content;
                                var nameLess = (Label)stackL.Children[0];
                                nameLess.Text = lessons[i].Name;
                                var timeSt = (Label)stackL.Children[2];
                                var timeEn = (Label)stackL.Children[4];
                                timeSt.Text = lessons[i].TimeStart.ToString(@"hh\:mm");
                                timeEn.Text = lessons[i].TimeEnd.ToString(@"hh\:mm");
                                i++;
                            });
                        }
                        enabled--;
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
                int i = 0;
                foreach (var lesson in lessonsTom)
                {
                    enabled++;
                }
                active = enabled;
                foreach (var frame in framesTom)
                {
                    if (enabled == 0)
                    {
                        frame.IsVisible = false;
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() => 
                        {
                            frame.IsVisible = true;
                            var stackL = (HorizontalStackLayout)frame.Content;
                            Label nameLess = (Label)stackL.Children[0];
                            nameLess.Text = lessonsTom[i].Name;
                            var timeSt = (Label)stackL.Children[2];
                            var timeEn = (Label)stackL.Children[4];
                            timeSt.Text = lessonsTom[i].TimeStart.ToString(@"hh\:mm");
                            timeEn.Text = lessonsTom[i].TimeEnd.ToString(@"hh\:mm");
                            enabled--;
                            i++;
                        });
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
