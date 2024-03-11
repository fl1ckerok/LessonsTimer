
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

    private void ApplyClicked(object sender, EventArgs e)
    {
        // ����������, �� frames - �� ����� ������, � ������� � ���� � ���� �������� (Entry)
        Frame[] frames = { MondayFirst, MondaySecond, MondayThird, MondayFourth, MondayFifth,
                           TuesdayFirst, TuesdaySecond, TuesdayThird, TuesdayFourth, TuesdayFifth,
                           WednesdayFirst, WednesdaySecond, WednesdayThird, WednesdayFourth, WednesdayFifth,
                           ThursdayFirst, ThursdaySecond, ThursdayThird, ThursdayFourth, ThursdayFifth,
                           FridayFirst, FridaySecond, FridayThird, FridayFourth, FridayFifth,
                           SaturdayFirst, SaturdaySecond, SaturdayThird, SaturdayFourth, SaturdayFifth};

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

    private void SaveToDB()
    {
        
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
                frames[counter-1].IsVisible = false;
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
            } else DisplayAlert("error", "5 ��� - ��������", "OK");
        }
    }
}