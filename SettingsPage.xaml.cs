
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls.Compatibility;
using StackLayoutAlias = Microsoft.Maui.Controls.StackLayout;

namespace LessonsTimer;

public partial class SettingsPage : ContentPage
{

    private Dictionary<ImageButton, List<Frame>> buttonFramesDictionary = [];
    public SettingsPage()
    {
        InitializeComponent();

        buttonFramesDictionary.Add(MondayButton, [MondayFirst, MondaySecond, MondayThird, MondayFourth, MondayFifth]);
        buttonFramesDictionary.Add(TuesdayButton, [TuesdayFirst, TuesdaySecond, TuesdayThird, TuesdayFourth, TuesdayFifth]);
        buttonFramesDictionary.Add(WednesdayButton, [WednesdayFirst, WednesdaySecond, WednesdayThird, WednesdayFourth, WednesdayFifth]);
        buttonFramesDictionary.Add(ThursdayButton, [ThursdayFirst, ThursdaySecond, ThursdayThird, ThursdayFourth, ThursdayFifth]);
        buttonFramesDictionary.Add(FridayButton, [FridayFirst, FridaySecond, FridayThird, FridayFourth, FridayFifth]);
        buttonFramesDictionary.Add(SaturdayButton, [SaturdayFirst, SaturdaySecond, SaturdayThird, SaturdayFourth, SaturdayFifth]);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadData();
    }

    private void LoadData()
    {
        using ApplicationContext db = new ApplicationContext();
        // 30 елементів в лісті, розбити знову через фрейми, закидати так як для Attach
        var lessons = db.Lessons.ToList();
        var lessonsInDb = lessons.Count;
        Dictionary<int, List<Frame>> nameFramesDict = [];
        nameFramesDict.Add(0, [MondayFirst, MondaySecond, MondayThird, MondayFourth, MondayFifth]);
        nameFramesDict.Add(1, [TuesdayFirst, TuesdaySecond, TuesdayThird, TuesdayFourth, TuesdayFifth]);
        nameFramesDict.Add(2, [WednesdayFirst, WednesdaySecond, WednesdayThird, WednesdayFourth, WednesdayFifth]);
        nameFramesDict.Add(3, [ThursdayFirst, ThursdaySecond, ThursdayThird, ThursdayFourth, ThursdayFifth]);
        nameFramesDict.Add(4, [FridayFirst, FridaySecond, FridayThird, FridayFourth, FridayFifth]);
        nameFramesDict.Add(5, [SaturdayFirst, SaturdaySecond, SaturdayThird, SaturdayFourth, SaturdayFifth]);
        int generalId = 0;
        if (lessonsInDb == 0) return;
        for (int i = 0; i < nameFramesDict.Count; i++)
        {
            var frames = nameFramesDict[i];
            for (int k = 0; k < frames.Count; k++)
            {
                SetEntry(frames[k], lessons[generalId].Name);
                SetTime(frames[k], true, lessons[generalId].TimeStart);
                SetTime(frames[k], false, lessons[generalId].TimeStart);
                frames[k].IsVisible = lessons[generalId].Visible;
                generalId++;
            }

        }
    }

    private void ApplyClicked(object sender, EventArgs e)
    {
        Frame[] frames = [ MondayFirst, MondaySecond, MondayThird, MondayFourth, MondayFifth,
                        TuesdayFirst, TuesdaySecond, TuesdayThird, TuesdayFourth, TuesdayFifth,
                        WednesdayFirst, WednesdaySecond, WednesdayThird, WednesdayFourth, WednesdayFifth,
                        ThursdayFirst, ThursdaySecond, ThursdayThird, ThursdayFourth, ThursdayFifth,
                        FridayFirst, FridaySecond, FridayThird, FridayFourth, FridayFifth,
                        SaturdayFirst, SaturdaySecond, SaturdayThird, SaturdayFourth, SaturdayFifth];

        // ����������, �� frames - �� ����� ������, � ������� � ���� � ���� �������� (Entry)
        foreach (var frame in frames)
        {
            if (frame.IsVisible)
            {
                // �������� �� ���� �������� ��������� ����� �����, ���� ���� ������
                foreach (var child in frame.Children)
                {
                    if (child is StackLayoutAlias stackLayout)
                    {
                        foreach (var entry in stackLayout.Children.OfType<Entry>())
                        {
                            if (string.IsNullOrWhiteSpace(entry.Text))
                            {
                                DisplayAlert("Error!", "�� ���� ���� ����. ������� ��� ��������� ����.", "������");
                            }
                            else
                            {
                                SaveToDB();
                                DisplayAlert("�����!", "���������.", "��.");
                            }
                        }
                    }
                }
            }
        }
    }

    private string NumToDay(int num)
    {
        string day = "";
        switch (num)
        {
            case 0:
                day = "Monday";
                break;
            case 1:
                day = "Tuesday";
                break;
            case 2:
                day = "Wednesday";
                break;
            case 3:
                day = "Thursday";
                break;
            case 4:
                day = "Friday";
                break;
            case 5:
                day = "Saturday";
                break;
        }
        return day;
    }

    private string GetEntry(Frame frame)
    {
        StackLayoutAlias sl = (StackLayoutAlias)frame.Content;
        Entry entry = (Entry)sl.Children[0];
        return entry.Text;
    }

    private void SetEntry(Frame frame, string text)
    {
        StackLayoutAlias sl = (StackLayoutAlias)frame.Content;
        Entry entry = (Entry)sl.Children[0];
        entry.Text = text;
    }

    private TimeSpan GetTime(Frame frame, bool priority)
    {
        StackLayoutAlias sl = (StackLayoutAlias)frame.Content;
        TimePicker time = priority ? (TimePicker)sl.Children[2] : (TimePicker)sl.Children[4];
        TimeSpan timeSpan = time.Time;
        return timeSpan;
    }

    private void SetTime(Frame frame, bool priority, TimeSpan timeSet)
    {
        StackLayoutAlias sl = (StackLayoutAlias)frame.Content;
        TimePicker time = priority ? (TimePicker)sl.Children[2] : (TimePicker)sl.Children[4];
        time.Time = timeSet;
    }

    private void SaveToDB()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            Dictionary<int, List<Frame>> nameFramesDict = [];
            nameFramesDict.Add(0, [MondayFirst, MondaySecond, MondayThird, MondayFourth, MondayFifth]);
            nameFramesDict.Add(1, [TuesdayFirst, TuesdaySecond, TuesdayThird, TuesdayFourth, TuesdayFifth]);
            nameFramesDict.Add(2, [WednesdayFirst, WednesdaySecond, WednesdayThird, WednesdayFourth, WednesdayFifth]);
            nameFramesDict.Add(3, [ThursdayFirst, ThursdaySecond, ThursdayThird, ThursdayFourth, ThursdayFifth]);
            nameFramesDict.Add(4, [FridayFirst, FridaySecond, FridayThird, FridayFourth, FridayFifth]);
            nameFramesDict.Add(5, [SaturdayFirst, SaturdaySecond, SaturdayThird, SaturdayFourth, SaturdayFifth]);

            int generalId = 1;
            for (int i = 0; i < nameFramesDict.Count; i++)
            {
                var frames = nameFramesDict[i];
                for (int k = 0; k < frames.Count; k++)
                {
                    if (!db.Lessons.Any(l => l.LessonId == generalId))
                    {
                        db.Lessons.Add(new Lesson
                        {
                            LessonId = generalId,
                            DayWeek = NumToDay(i),
                            Name = GetEntry(frames[k]),
                            TimeStart = GetTime(frames[k], true),
                            TimeEnd = GetTime(frames[k], false),
                            Visible = frames[k].IsVisible,
                            DayId = i + 1
                        });
                    }
                    else
                    {
                        var existingLesson = db.Lessons.First(l => l.LessonId == generalId);
                        existingLesson.Name = GetEntry(frames[k]);
                        existingLesson.TimeStart = GetTime(frames[k], true);
                        existingLesson.TimeEnd = GetTime(frames[k], false);
                        existingLesson.Visible = frames[k].IsVisible;
                        db.Attach(existingLesson);
                    }
                    generalId++;
                }
            }

            // Зберігаємо зміни у базі даних
            db.SaveChanges();
            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateException ex)
            //{
            //    // Розгорнення внутрішньої помилки
            //    Exception innerException = ex.InnerException;
            //    while (innerException != null)
            //    {
            //        Console.WriteLine(innerException.Message);
            //        innerException = innerException.InnerException;
            //    }
            //    // Опрацювання помилки додатково за потреби
            //}
        }
    }

    private void ClickDel(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        int counter = 0;
        if (buttonFramesDictionary.ContainsKey(button))
        {
            var frames = buttonFramesDictionary[button];
            foreach (var frame in frames)
            {
                if (frame.IsVisible) counter++;         // Get counter of Visible frames
            }
            if (counter >= 2)
            {
                frames[counter - 1].IsVisible = false;
                counter--;
            }
        }
    }
    private void ClickAdd(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        int counter = 0;
        if (buttonFramesDictionary.ContainsKey(button))
        {
            var frames = buttonFramesDictionary[button];
            foreach (var frame in frames)
            {
                if (frame.IsVisible) counter++;         // Get counter of Visible frames
            }
            if (counter <= 4)
            {
                frames[counter].IsVisible = true;
                counter++;
            }
            else DisplayAlert("error", "5 ��� - ��������", "OK");
        }
    }
}