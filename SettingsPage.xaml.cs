
using Microsoft.Maui.Controls.Compatibility;
using StackLayoutAlias = Microsoft.Maui.Controls.StackLayout;

namespace LessonsTimer;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    // Variables

    int Mon = 1;
    int Tue = 1;
    int Wed = 1;
    int Thu = 1;
    int Fri = 1;
    int Sat = 1;

    private void ApplyClicked(object sender, EventArgs e)
    {
        // Припустимо, що frames - це масив фреймів, у кожному з яких є поля введення (Entry)
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
                // Перевірте всі поля введення всередині цього рамки, якщо вона видима
                foreach (var child in frame.Children)
                {
                    if (child is StackLayoutAlias stackLayout)
                    {
                        foreach (var entry in stackLayout.Children.OfType<Entry>())
                        {
                            if (string.IsNullOrWhiteSpace(entry.Text))
                            {
                                DisplayAlert("Error!", "Ви маєте пусті поля. Видаліть або заповніть пару.", "Гаразд");
                            }
                            else
                            {
                                SaveToDB();
                                DisplayAlert("Увага!", "Збережено.", "ОК.");
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
        if ((sender == MondayTrash) && (Mon >= 2))
        {
            switch (Mon)
            {
                case 5:
                    MondayFifth.IsVisible = false;
                    Mon--;
                    break;
                case 4:
                    MondayFourth.IsVisible = false;
                    Mon--;
                    break;
                case 3:
                    MondayThird.IsVisible = false;
                    Mon--;
                    break;
                case 2:
                    MondaySecond.IsVisible = false;
                    Mon--;
                    break;
            }
        }
        else if ((sender == TuesdayTrash) && (Tue >= 2))
        {
            switch (Tue)
            {
                case 5:
                    TuesdayFifth.IsVisible = false;
                    Tue--;
                    break;
                case 4:
                    TuesdayFourth.IsVisible = false;
                    Tue--;
                    break;
                case 3:
                    TuesdayThird.IsVisible = false;
                    Tue--;
                    break;
                case 2:
                    TuesdaySecond.IsVisible = false;
                    Tue--;
                    break;
            }
        }
        else if ((sender == WednesdayTrash) && (Wed >= 2))
        {
            switch (Wed)
            {
                case 5:
                    WednesdayFifth.IsVisible = false;
                    Wed--;
                    break;
                case 4:
                    WednesdayFourth.IsVisible = false;
                    Wed--;
                    break;
                case 3:
                    WednesdayThird.IsVisible = false;
                    Wed--;
                    break;
                case 2:
                    WednesdaySecond.IsVisible = false;
                    Wed--;
                    break;
            }
        }
        else if ((sender == ThursdayTrash) && (Thu >= 2))
        {
            switch (Thu)
            {
                case 5:
                    ThursdayFifth.IsVisible = false;
                    Thu--;
                    break;
                case 4:
                    ThursdayFourth.IsVisible = false;
                    Thu--;
                    break;
                case 3:
                    ThursdayThird.IsVisible = false;
                    Thu--;
                    break;
                case 2:
                    ThursdaySecond.IsVisible = false;
                    Thu--;
                    break;
            }
        }
        else if ((sender == FridayTrash) && (Fri >= 2))
        {
            switch (Fri)
            {
                case 5:
                    FridayFifth.IsVisible = false;
                    Fri--;
                    break;
                case 4:
                    FridayFourth.IsVisible = false;
                    Fri--;
                    break;
                case 3:
                    FridayThird.IsVisible = false;
                    Fri--;
                    break;
                case 2:
                    FridaySecond.IsVisible = false;
                    Fri--;
                    break;
            }
        }
        else if ((sender == SaturdayTrash) && (Sat >= 2))
        {
            switch (Sat)
            {
                case 5:
                    SaturdayFifth.IsVisible = false;
                    Sat--;
                    break;
                case 4:
                    SaturdayFourth.IsVisible = false;
                    Sat--;
                    break;
                case 3:
                    SaturdayThird.IsVisible = false;
                    Sat--;
                    break;
                case 2:
                    SaturdaySecond.IsVisible = false;
                    Sat--;
                    break;
            }
        }
    }
    private void ClickAdd(object sender, EventArgs e) 
    {
        if ((sender == MondayButton) && (Mon <= 4))
        {
            switch (Mon)
            {
                case 1:
                    MondaySecond.IsVisible = true;
                    Mon++;
                    break;
                case 2:
                    MondayThird.IsVisible = true;
                    Mon++;
                    break;
                case 3:
                    MondayFourth.IsVisible = true;
                    Mon++;
                    break;
                case 4:
                    MondayFifth.IsVisible = true;
                    Mon++;
                    break;
            }
        }
        else if ((sender == TuesdayButton) && (Tue <= 4))
        {
            switch (Tue)
            {
                case 1:
                    TuesdaySecond.IsVisible = true;
                    Tue++;
                    break;
                case 2:
                    TuesdayThird.IsVisible = true;
                    Tue++;
                    break;
                case 3:
                    TuesdayFourth.IsVisible = true;
                    Tue++;
                    break;
                case 4:
                    TuesdayFifth.IsVisible = true;
                    Tue++;
                    break;
            }
        }
        else if ((sender == WednesdayButton) && (Wed <= 4))
        {
            switch (Wed)
            {
                case 1:
                    WednesdaySecond.IsVisible = true;
                    Wed++;
                    break;
                case 2:
                    WednesdayThird.IsVisible = true;
                    Wed++;
                    break;
                case 3:
                    WednesdayFourth.IsVisible = true;
                    Wed++;
                    break;
                case 4:
                    WednesdayFifth.IsVisible = true;
                    Wed++;
                    break;
            }
        }
        else if ((sender == ThursdayButton) && (Thu <= 4))
        {
            switch (Thu)
            {
                case 1:
                    ThursdaySecond.IsVisible = true;
                    Thu++;
                    break;
                case 2:
                    ThursdayThird.IsVisible = true;
                    Thu++;
                    break;
                case 3:
                    ThursdayFourth.IsVisible = true;
                    Thu++;
                    break;
                case 4:
                    ThursdayFifth.IsVisible = true;
                    Thu++;
                    break;
            }
        }
        else if ((sender == FridayButton) && (Fri <= 4))
        {
            switch (Fri)
            {
                case 1:
                    FridaySecond.IsVisible = true;
                    Fri++;
                    break;
                case 2:
                    FridayThird.IsVisible = true;
                    Fri++;
                    break;
                case 3:
                    FridayFourth.IsVisible = true;
                    Fri++;
                    break;
                case 4:
                    FridayFifth.IsVisible = true;
                    Fri++;
                    break;
            }
        }
        else if ((sender == SaturdayButton) && (Sat <= 4))
        {
            switch (Sat)
            {
                case 1:
                    SaturdaySecond.IsVisible = true;
                    Sat++;
                    break;
                case 2:
                    SaturdayThird.IsVisible = true;
                    Sat++;
                    break;
                case 3:
                    SaturdayFourth.IsVisible = true;
                    Sat++;
                    break;
                case 4:
                    SaturdayFifth.IsVisible = true;
                    Sat++;
                    break;
            }
        }
        else DisplayAlert("error", "5 Пар - максимум", "OK");
    }
}