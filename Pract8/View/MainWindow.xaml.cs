using System.Windows;
using TestNaSkoropechat.View;
using TestNaSkoropechat.ViewModel;

namespace TestNaSkoropechat;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainViewModel mainViewModel = new MainViewModel();
        mainViewModel.RequestClose += (sender, args) => CloseWindow();
        DataContext = mainViewModel;
    }

    private void CloseWindow()
    {
        TakeTestWindow testWindow = new TakeTestWindow(textBox.Text);
        testWindow.Show();
        this.Close();
    } 
}