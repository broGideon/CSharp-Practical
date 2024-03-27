using System.IO;
using System.Windows.Data;
using Newtonsoft.Json;
using TestNaSkoropechat.Model;
using TestNaSkoropechat.ViewModel.Helpers;

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
        string text = File.ReadAllText("ResultsTest.json");
        Results = JsonConvert.DeserializeObject<List<Result>>(text);
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