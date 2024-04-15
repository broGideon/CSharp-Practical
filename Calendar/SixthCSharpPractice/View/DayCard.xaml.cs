using System.Windows;
using SixthCSharpPractice.ViewModel;

namespace SixthCSharpPractice.View;

public partial class DayCard
{
    private readonly MainViewModel _mainViewModel;

    public DayCard(MainViewModel mainViewModel)
    {
        InitializeComponent();
        _mainViewModel = mainViewModel;
        DataContext = this;
        Path = "../../../Model/Source/Default.png";
    }

    public string DayNumber { get; set; }
    public string Path { get; set; }
    private void DayCard_MouseDown(object sender, RoutedEventArgs e)
    {
        _mainViewModel.OpenSelectPage(Convert.ToInt32(DayNumber));
    }
}