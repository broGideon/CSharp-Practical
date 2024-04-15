using System.Windows.Controls;
using SixthCSharpPractice.ViewModel;

namespace SixthCSharpPractice.View;

public partial class CalendarPage : Page
{
    private readonly MainViewModel _mainViewModel;

    public CalendarPage(MainViewModel mainViewModel)
    {
        InitializeComponent();
        _mainViewModel = mainViewModel;
        _mainViewModel.Refresh += (sender, args) => AddCards();
        AddCards();
    }

    private void AddCards()
    {
        PageWrapPanel.Children.Clear();
        foreach (var item in _mainViewModel.DayCards) PageWrapPanel.Children.Add(item);
    }
}