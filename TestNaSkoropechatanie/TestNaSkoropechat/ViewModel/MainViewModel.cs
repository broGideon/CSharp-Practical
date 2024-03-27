using System.Windows.Controls;
using TestNaSkoropechat.View;
using TestNaSkoropechat.ViewModel.Helpers;

namespace TestNaSkoropechat.ViewModel;

public class MainViewModel : BindingHelper
{
    #region struct
    
    public event EventHandler RequestClose;
    
    public string name;

    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            OnPropertyChanged();
        }
    }

    public BindableCommand AddCommand { get; set; }

    #endregion

    public MainViewModel()
    {
        AddCommand = new BindableCommand(_ => Autorization());
    }

    private void Autorization()
    {
        if (Name != null)
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}