using System.Windows.Controls;
using SixthCSharpPractice.ViewModel;

namespace SixthCSharpPractice.View;

public partial class SelectPage : Page
{
    private readonly MainViewModel _mainViewModel;

    public SelectPage(MainViewModel mainViewModel)
    {
        InitializeComponent();
        _mainViewModel = mainViewModel;
        DataContext = _mainViewModel;
    }
}