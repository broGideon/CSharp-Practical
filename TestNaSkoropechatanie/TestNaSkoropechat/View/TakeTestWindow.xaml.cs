using System.Windows;
using TestNaSkoropechat.ViewModel;

namespace TestNaSkoropechat.View;

public partial class TakeTestWindow : Window
{
    public TakeTestWindow(string name)
    {
        InitializeComponent();
        TakeTestViewModel takeTestViewModel = new TakeTestViewModel();
        takeTestViewModel.RequestClose += (sender, args)=> CloseWindow();
        takeTestViewModel.Name = name;
        DataContext = takeTestViewModel;
    }
    
    private void CloseWindow()
    {
        ResultWindow resultWindow = new ResultWindow();
        resultWindow.Show();
        this.Close();
    }
}