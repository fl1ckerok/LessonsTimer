
using Microsoft.Maui.Controls.Compatibility;
using StackLayoutAlias = Microsoft.Maui.Controls.StackLayout;

namespace LessonsTimer;

public partial class SettingsPage : ContentPage
{
    //VerticalStackLayout monBody;
    //VerticalStackLayout tueBody;
    //VerticalStackLayout wedBody;
    //VerticalStackLayout thuBody;
    //VerticalStackLayout friBody;
    //VerticalStackLayout satBody;


    //ImageButton butMon = new ImageButton() { Source = "Image/settings.svg" };
    //ImageButton butTue = new ImageButton() { Source = "Image/settings.svg" };
    //ImageButton butWed = new ImageButton() { Source = "Image/settings.svg" };
    //ImageButton butThu = new ImageButton() { Source = "Image/settings.svg" };
    //ImageButton butFri = new ImageButton() { Source = "Image/settings.svg" };
    //ImageButton butSat = new ImageButton() { Source = "Image/settings.svg" };


    public SettingsPage()
    {
        InitializeComponent();

    //    StackLayout Week = new();

    //    StackLayout mondayCase = new();
    //    StackLayout tuesdayCase = new();
    //    StackLayout wednesdayCase = new();
    //    StackLayout thursdayCase = new();
    //    StackLayout fridayCase = new();
    //    StackLayout saturdayCase = new();

    //    HorizontalStackLayout monHeader = new();
    //    HorizontalStackLayout tueHeader = new();
    //    HorizontalStackLayout wedHeader = new();
    //    HorizontalStackLayout thuHeader = new();
    //    HorizontalStackLayout friHeader = new();
    //    HorizontalStackLayout satHeader = new();

    //    monBody = new();
    //    tueBody = new();
    //    wedBody = new();
    //    thuBody = new();
    //    friBody = new();
    //    satBody = new();

    //    Label Monday = new Label { Text = "Понеділок", FontSize=40 };
    //    Label Tuesday = new Label { Text = "Вівторок", FontSize = 40 };
    //    Label Wednesday = new Label { Text = "Середа", FontSize = 40 };
    //    Label Thursday = new Label { Text = "Четвер", FontSize = 40 };
    //    Label Friday = new Label { Text = "П'ятниця", FontSize = 40 };
    //    Label Saturday = new Label { Text = "Субота", FontSize = 40 };


    //    butMon.Clicked += addObj;
    //    butTue.Clicked += addObj;
    //    butWed.Clicked += addObj;
    //    butThu.Clicked += addObj;
    //    butFri.Clicked += addObj;
    //    butSat.Clicked += addObj;



    //    monHeader.Children.Add(Monday);
    //    monHeader.Children.Add(butMon);

    //    tueHeader.Children.Add(Tuesday);
    //    tueHeader.Children.Add(butTue);

    //    wedHeader.Children.Add(Wednesday);
    //    wedHeader.Children.Add(butWed);

    //    thuHeader.Children.Add(Thursday);
    //    thuHeader.Children.Add(butThu);

    //    friHeader.Children.Add(Friday);
    //    friHeader.Children.Add(butFri);

    //    satHeader.Children.Add(Saturday);
    //    satHeader.Children.Add(butSat);

    //    // Sborka

    //    mondayCase.Children.Add(monHeader);
    //    mondayCase.Children.Add(monBody);

    //    tuesdayCase.Children.Add(tueHeader);
    //    tuesdayCase.Children.Add(tueBody);

    //    wednesdayCase.Children.Add(wedHeader);
    //    wednesdayCase.Children.Add(wedBody);

    //    thursdayCase.Children.Add(thuHeader);
    //    thursdayCase.Children.Add(thuBody);


    //    fridayCase.Children.Add(friHeader);
    //    fridayCase.Children.Add(friBody);


    //    saturdayCase.Children.Add(satHeader);
    //    saturdayCase.Children.Add(satBody);

    //    //

    //    Week.Children.Add(mondayCase);
    //    Week.Children.Add(tuesdayCase);
    //    Week.Children.Add(wednesdayCase);
    //    Week.Children.Add(thursdayCase);
    //    Week.Children.Add(fridayCase);
    //    Week.Children.Add(saturdayCase);

    //    ScrollView scrollView = new ScrollView
    //    {
    //        Margin = new Thickness(20),
    //        Content = Week
    //    };

    //    Content = scrollView;


    //}

    //private void addObj(object? sender, EventArgs e)
    //{
    //    //if (sat <= 4)
    //    //{
    //    //    sat++;
    //    //    satBody.Children.Add(new Entry { Placeholder = "Нова назва предмету" });
    //    //    satBody.Children.Add(new TimePicker());
    //    //    satBody.Children.Add(new TimePicker());
    //    //}
    //    //else messageStackOverflow();

    //    if (sender == butMon)
    //    {
    //        messageAdded("Monday");
    //    } else if (sender == butTue)
    //    {
    //        messageAdded("Tuesday");
    //    } else if (sender == butWed)
    //    {
    //        messageAdded("Wednesday");
    //    } else if (sender == butThu)
    //    {
    //        messageAdded("Thursday");
    //    } else if (sender == butFri)
    //    {
    //        messageAdded("Friday");
    //    } else if (sender == butSat) 
    //    {
    //        messageAdded("Saturday");
    //    }

    }

    //int mon = 0;
    //int tue = 0;
    //int wed = 0;
    //int thu = 0;
    //int fri = 0;
    //int sat = 0;

    //public void messageAdded(string Day)
    //{
    //    DisplayAlert("Alert", Day, "Ok");
    //}

    //public void messageStackOverflow()
    //{
    //    DisplayAlert("Stack Overflow", "Ви наклацали забагато пар!", "Блін.");
    //}

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
                                // Поле введення порожнє або містить тільки пробіли
                                // Виконати відповідні дії
                                DisplayAlert("Error!", "Ви маєте пусті поля. Видаліть або заповніть пару.", "Гаразд");
                            }
                            else
                            {
                                // Поле введення не порожнє
                                // Виконати потрібні дії
                                DisplayAlert("", "Kek", "Kek");
                            }
                        }
                    }
                }
            }
        }
    }

    //DisplayAlert("Error!","Ви маєте пусті поля. Видаліть або заповніть пару.","Гаразд");
    //DisplayAlert("", "Kek", "Kek");


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

    // Variables

    int Mon = 1;
    int Tue = 1;
    int Wed = 1;
    int Thu = 1;
    int Fri = 1;
    int Sat = 1;

}