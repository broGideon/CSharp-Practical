using System.Windows;
using TestNaSkoropechat.ViewModel;

namespace TestNaSkoropechat.View;

public partial class ResultWindow : Window
{
    public ResultWindow()
    {
        InitializeComponent();
        ResultViewModel resultViewModel = new ResultViewModel();
        resultViewModel.RequestClose += (sender, args) => CloseWindow();
        resultViewModel.RequestStart += (sender, args) => OpenStart();
        DataContext = resultViewModel;
    }
    private void CloseWindow()
    {
        this.Close();
    }

    private void OpenStart()
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}