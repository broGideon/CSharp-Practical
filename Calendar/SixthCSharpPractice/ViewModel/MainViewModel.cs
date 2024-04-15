using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using SixthCSharpPractice.Model;
using SixthCSharpPractice.View;
using SixthCSharpPractice.ViewModel.Helper;

namespace SixthCSharpPractice.ViewModel;

public class MainViewModel : BindingHelper
{
    public void BackToCalendarPage(object sender, RoutedEventArgs e)
    {
        if ((sender as Button).Name == "Forward" && (sender as Button).Content == "Сохранить")
        {
            Save();
            return;
        }

        if ((sender as Button).Name == "Back" && (sender as Button).Content == "Назад") OpenCalendar?.Invoke(this, EventArgs.Empty);
        else if ((sender as Button).Name == "Forward") _currentDateTime = _currentDateTime.AddMonths(1);
        else _currentDateTime = _currentDateTime.AddMonths(-1);
        var textInfo = CultureInfo.CurrentCulture.TextInfo;
        CurrentDate = $"{textInfo.ToTitleCase(_currentDateTime.ToString("MMMM"))}, {_currentDateTime.Year.ToString()}";
        RunAnimation?.Invoke(this, EventArgs.Empty);
        CreateDayCards();
    }

    private void CreateDayCards()
    {
        DayCards.Clear();
        var count = DateTime.DaysInMonth(_currentDateTime.Year, _currentDateTime.Month);
        var items = SerDeser.Deserialize<ChoiceDay>("Days.json");
        var choiceDays = new List<ChoiceDay>();
        foreach (var item in items) if (item.Date.Year == _currentDateTime.Year && item.Date.Month == _currentDateTime.Month) choiceDays.Add(item);
        for (var i = 1; i <= count; i++)
        {
            var dayCard = new DayCard(this);
            dayCard.DayNumber = i.ToString();
            var path = Search(choiceDays, i);
            if (path != null) dayCard.Path = path;
            DayCards.Add(dayCard);
        }
        Refresh?.Invoke(this, EventArgs.Empty);
    }

    private string Search(List<ChoiceDay> choiceDays, int count)
    {
        var choices = new List<Choice>();
        foreach (var item in choiceDays)
            if (count == item.Date.Day)
            {
                choices = item.Choices;
                break;
            }
        foreach (var item in choices) if (item.IsActive) return item.Path;
        return null;
    }

    public void OpenSelectPage(int day)
    {
        _day = day;
        Foods.Clear();
        _currentDateTime = new DateTime(_currentDateTime.Year, _currentDateTime.Month, day);
        CurrentDate = $"{_weekDaies[_currentDateTime.DayOfWeek.ToString()]}, число: {day}";
        var items = SerDeser.Deserialize<ChoiceDay>("Days.json");
        var choices = new List<Choice>();
        foreach (var item in items)
            if (item.Date.Year == _currentDateTime.Year && item.Date.Month == _currentDateTime.Month && item.Date.Day == day)
            {
                choices = item.Choices;
                break;
            }
        foreach (var item in choices)
        {
            var food = new FoodCard();
            food.Path = item.Path;
            food.ProductType = item.Name;
            food.CheckBox.IsChecked = item.IsActive;
            Foods.Add(food);
        }
        if (Foods.Count != 0)
        {
            OpenSelect?.Invoke(this, EventArgs.Empty);
            return;
        }
        var paths = new string[10]
        {
            "beef",
            "bread",
            "cheese",
            "cola",
            "fish-food",
            "ice-cream-cone",
            "pineapple",
            "pizza",
            "strawberry",
            "sunny-side-up-eggs"
        };
        var names = new string[10]
        {
            "мясо",
            "мучное",
            "молочные продукты",
            "напитки",
            "рыба",
            "сладкое",
            "фрукуты",
            "фастфуд",
            "ягоды",
            "жопа"
        };
        for (var i = 0; i < paths.Length; i++)
        {
            var foodCard = new FoodCard();
            foodCard.Path = $"../../../Model/Source/icons/{paths[i]}-96.png";
            foodCard.ProductType = names[i];
            foodCard.HorizontalAlignment = HorizontalAlignment.Left;
            Foods.Add(foodCard);
        }
        RunAnimation?.Invoke(this, EventArgs.Empty);
        OpenSelect?.Invoke(this, EventArgs.Empty);
    }

    private void Save()
    {
        List<Choice> choice = new List<Choice>();
        foreach (var item in Foods)
        {
            choice.Add(new Choice(item.ProductType, item.Path, (bool)item.CheckBox.IsChecked));
        }
        var choiceDay = new ChoiceDay(new DateTime(_currentDateTime.Year, _currentDateTime.Month, _day), choice);
        var items = SerDeser.Deserialize<ChoiceDay>("Days.json");
        foreach (var item in items)
        {
            if (item.Date == choiceDay.Date)
            {
                item.Choices = choice;
                SerDeser.Serialize<List<ChoiceDay>>(items, "Days.json");
                return;
            }
        }
        items.Add(choiceDay);
        SerDeser.Serialize<List<ChoiceDay>>(items, "Days.json");
    }

    #region GlobalVariables

    public event EventHandler OpenCalendar;
    public event EventHandler RunAnimation;
    public event EventHandler OpenSelect;

    private readonly Dictionary<string, string> _weekDaies = new()
    {
        { "Monday", "Понедельник" },
        { "Tuesday", "Вторник" },
        { "Wednesday", "Среда" },
        { "Thursday", "Четверг" },
        { "Friday", "Пятница" },
        { "Saturday", "Суббота" },
        { "Sunday", "Воскресенье" }
    };

    public event EventHandler Refresh;
    private DateTime _currentDateTime;
    public List<DayCard> DayCards = new();

    public MainViewModel()
    {
        _currentDateTime = DateTime.Today;
        var textInfo = CultureInfo.CurrentCulture.TextInfo;
        CurrentDate = $"{textInfo.ToTitleCase(_currentDateTime.ToString("MMMM"))}, {_currentDateTime.Year.ToString()}";

        CreateDayCards();
    }

    private int _day;
    private string _currentDate;

    public string CurrentDate
    {
        get => _currentDate;
        set
        {
            _currentDate = value;
            OnPropertyChanged();
        }
    }

    private List<FoodCard> _foods = new();

    public List<FoodCard> Foods
    {
        get => _foods;
        set
        {
            _foods = value;
            OnPropertyChanged();
        }
    }

    #endregion
}