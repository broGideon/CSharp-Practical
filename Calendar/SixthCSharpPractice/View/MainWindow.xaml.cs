using System.Windows;
using System.Windows.Media.Animation;
using MaterialDesignThemes.Wpf;
using SixthCSharpPractice.View;
using SixthCSharpPractice.ViewModel;

namespace SixthCSharpPractice;

public partial class MainWindow : Window
{
    private readonly CalendarPage _calendarPage;
    private readonly MainViewModel mainViewModel;

    public MainWindow()
    {
        InitializeComponent();
        mainViewModel = new MainViewModel();
        mainViewModel.OpenSelect += (sender, args) => OpenSelectPage();
        mainViewModel.OpenCalendar += (sender, args) => OpenCalendarPage();
        mainViewModel.RunAnimation += (sender, args) => BeginAnimation();
        DataContext = mainViewModel;
        _calendarPage = new CalendarPage(mainViewModel);
        MainFraim.Content = _calendarPage;
    }

    public void OpenCalendarPage()
    {
        var packIcon = new PackIcon();
        packIcon.Kind = PackIconKind.ArrowRight;
        Forward.Content = packIcon;
        var packIcon2 = new PackIcon();
        packIcon2.Kind = PackIconKind.ArrowLeft;
        Back.Content = packIcon2;
        MainFraim.Content = _calendarPage;
    }

    private void OpenSelectPage()
    {
        Forward.Content = "Сохранить";
        Back.Content = "Назад";
        MainFraim.Content = new SelectPage(mainViewModel);
    }

    private void BeginAnimation()
    {
        var opacityAnim = new DoubleAnimation();
        opacityAnim.From = 0;
        opacityAnim.To = 1;
        opacityAnim.Duration = TimeSpan.FromSeconds(0.5);
        MainFraim.BeginAnimation(OpacityProperty, opacityAnim);
    }
}