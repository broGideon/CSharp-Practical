using System.IO;
using Bindings;
using Newtonsoft.Json;
using TestNaSkoropechat.Model;
using WpfLibrary1;

namespace TestNaSkoropechat.ViewModel;

public class ResultViewModel : BindingHelper
{
    #region struct

    public event EventHandler RequestClose;

    public event EventHandler RequestStart;

    private List<Result> results;

    public List<Result> Results
    {
        get { return results; }
        set
        {
            results = value;
            OnPropertyChanged();
        }
    }

    public BindableCommand AddComand1 { get; set; }
    
    public BindableCommand AddComand2 { get; set; }

    #endregion

    public ResultViewModel()
    {
        AddComand1 = new BindableCommand(_ => ClickExitButton());
        AddComand2 = new BindableCommand(_ => ClickStartButton());

        Results = SerDeser.Deserialize<List<Result>>("ResultsTest.json");
    }

    public void ClickExitButton()
    {
        RequestClose?.Invoke(this, EventArgs.Empty);
    }
    
    public void ClickStartButton()
    {
        RequestStart?.Invoke(this, EventArgs.Empty);
    }
}