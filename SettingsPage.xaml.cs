
namespace LessonsTimer;

public partial class SettingsPage : ContentPage
{
    VerticalStackLayout monBody;
    VerticalStackLayout tueBody;
    VerticalStackLayout wedBody;
    VerticalStackLayout thuBody;
    VerticalStackLayout friBody;
    VerticalStackLayout satBody;
    public SettingsPage()
    {
        InitializeComponent();

        StackLayout Week = new();

        StackLayout mondayCase = new();
        StackLayout tuesdayCase = new();
        StackLayout wednesdayCase = new();
        StackLayout thursdayCase = new();
        StackLayout fridayCase = new();
        StackLayout saturdayCase = new();

        HorizontalStackLayout monHeader = new();
        HorizontalStackLayout tueHeader = new();
        HorizontalStackLayout wedHeader = new();
        HorizontalStackLayout thuHeader = new();
        HorizontalStackLayout friHeader = new();
        HorizontalStackLayout satHeader = new();

        monBody = new();
        tueBody = new();
        wedBody = new();
        thuBody = new();
        friBody = new();
        satBody = new();

        Label Monday = new Label { Text = "Понеділок", FontSize=40 };
        Label Tuesday = new Label { Text = "Вівторок", FontSize = 40 };
        Label Wednesday = new Label { Text = "Середа", FontSize = 40 };
        Label Thursday = new Label { Text = "Четвер", FontSize = 40 };
        Label Friday = new Label { Text = "П'ятниця", FontSize = 40 };
        Label Saturday = new Label { Text = "Субота", FontSize = 40 };

        ImageButtonSettings butMon = new ImageButtonSettings("Mon") { Source = "Image/settings.svg" };
        butMon.Clicked += MonAdd;
        ImageButtonSettings butTue = new ImageButtonSettings("Tue") { Source = "Image/settings.svg" };
        butTue.Clicked += TueAdd;
        ImageButtonSettings butWed = new ImageButtonSettings("Wed") { Source = "Image/settings.svg" };
        butWed.Clicked += WedAdd;
        ImageButtonSettings butThu = new ImageButtonSettings("Thu") { Source = "Image/settings.svg" };
        butThu.Clicked += ThuAdd;
        ImageButtonSettings butFri = new ImageButtonSettings("Fri") { Source = "Image/settings.svg" };
        butFri.Clicked += FriAdd;
        ImageButtonSettings butSat = new ImageButtonSettings("Sat") { Source = "Image/settings.svg" };
        butSat.Clicked += SatAdd;

        

        monHeader.Children.Add(Monday);
        monHeader.Children.Add(butMon);

        tueHeader.Children.Add(Tuesday);
        tueHeader.Children.Add(butTue);

        wedHeader.Children.Add(Wednesday);
        wedHeader.Children.Add(butWed);

        thuHeader.Children.Add(Thursday);
        thuHeader.Children.Add(butThu);

        friHeader.Children.Add(Friday);
        friHeader.Children.Add(butFri);

        satHeader.Children.Add(Saturday);
        satHeader.Children.Add(butSat);

        // Sborka

        mondayCase.Children.Add(monHeader);
        mondayCase.Children.Add(monBody);

        tuesdayCase.Children.Add(tueHeader);
        tuesdayCase.Children.Add(tueBody);

        wednesdayCase.Children.Add(wedHeader);
        wednesdayCase.Children.Add(wedBody);

        thursdayCase.Children.Add(thuHeader);
        thursdayCase.Children.Add(thuBody);


        fridayCase.Children.Add(friHeader);
        fridayCase.Children.Add(friBody);


        saturdayCase.Children.Add(satHeader);
        saturdayCase.Children.Add(satBody);

        //

        Week.Children.Add(mondayCase);
        Week.Children.Add(tuesdayCase);
        Week.Children.Add(wednesdayCase);
        Week.Children.Add(thursdayCase);
        Week.Children.Add(fridayCase);
        Week.Children.Add(saturdayCase);

        ScrollView scrollView = new ScrollView
        {
            Margin = new Thickness(20),
            Content = Week
        };

        Content = scrollView;


    }

    private void SatAdd(object? sender, EventArgs e)
    {
        if (sat <= 4)
        {
            sat++;
            satBody.Children.Add(new Entry { Placeholder = "Нова назва предмету" });
            satBody.Children.Add(new TimePicker());
            satBody.Children.Add(new TimePicker());
        }
        else messageStackOverflow();

    }

    private  void FriAdd(object? sender, EventArgs e)
    {
        if (fri <= 4)
        {
            fri++;
            friBody.Children.Add(new Entry { Placeholder = "Нова назва предмету" });
            friBody.Children.Add(new TimePicker());
            friBody.Children.Add(new TimePicker());
        } else messageStackOverflow();
    }

    private  void ThuAdd(object? sender, EventArgs e)
    {
        if (thu <= 4)
        {
            thu++;
            thuBody.Children.Add(new Entry { Placeholder = "Нова назва предмету" });
            thuBody.Children.Add(new TimePicker());
            thuBody.Children.Add(new TimePicker());
        } else messageStackOverflow();
    }

    private  void WedAdd(object? sender, EventArgs e)
    {
        if (wed <= 4)
        {
            wed++;
            wedBody.Children.Add(new Entry { Placeholder = "Нова назва предмету" });
            wedBody.Children.Add(new TimePicker());
            wedBody.Children.Add(new TimePicker());
        } else messageStackOverflow();
    }

    private  void TueAdd(object? sender, EventArgs e)
    {
        if (tue <= 4)
        {
            tue++;
            tueBody.Children.Add(new Entry { Placeholder = "Нова назва предмету" });
            tueBody.Children.Add(new TimePicker());
            tueBody.Children.Add(new TimePicker());
        } else messageStackOverflow();
    }

    private void MonAdd(object? sender, EventArgs e)
    {
        if (mon <= 4)
        {
            mon++;
            monBody.Children.Add(new Entry { Placeholder = "Нова назва предмету" });
            monBody.Children.Add(new TimePicker());
            monBody.Children.Add(new TimePicker());
        } else messageStackOverflow();

    }

    int mon = 0;
    int tue = 0;
    int wed = 0;
    int thu = 0;
    int fri = 0;
    int sat = 0;

    public void messageStackOverflow()
    {
        DisplayAlert("Stack Overflow", "Ви наклацали забагато пар!", "Блін.");
    }
}