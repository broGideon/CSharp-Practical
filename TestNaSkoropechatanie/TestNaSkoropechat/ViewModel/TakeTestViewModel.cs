using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;
using TestNaSkoropechat.Model;
using TestNaSkoropechat.ViewModel.Helpers;
namespace TestNaSkoropechat.ViewModel;

public class TakeTestViewModel : BindingHelper
{
    #region struct
    
    private bool stop = false;

    private string text;

    private int count = 0;

    private string readText;

    private int time = 60;

    public string Name;
    public int Time
    {
        get{ return time; }
        set
        {
            time = value;
            OnPropertyChanged();
        }
    }

    public string ReadText
    {
        get { return readText; }
        set { readText = value; OnPropertyChanged(); }   
    }
    
    public event EventHandler RequestClose;

    public int Result;

    public TakeTestViewModel()
    {
        text = "Lucas goes to school every day of the week. He has many subjects to go to each school day: English, " +
               "art, science, mathematics, gym, and history. His mother packs a big backpack full of books and lunch for Lucas. " +
               "His first class is English, and he likes that teacher very much. His English teacher says that he is a good pupil, " +
               "which Lucas knows means that she thinks he is a good student.";
    }

    #endregion

    public void ShowCustomer(object sender, KeyEventArgs args)
    {
        string key;
        if (args.Key == Key.Space)
        {
            key = " ";
        }
        else
        {
            key = args.Key.ToString().ToLower();
        }
        if (ReadText[0].ToString().ToLower() == key)
        {
            Result++;
            count++;
            try
            {
                ReadText = text[count] + text[count+1].ToString() + text[count+2] + text[count+3] + text[count+4];
            }
            catch (Exception e)
            {
                ReadText = ReadText.Substring(1, ReadText.Length - 1);
            }
        }
        if (count == text.Length || stop)
        {
            StopTest();
        }
    }

    public void StartTest(object sender, RoutedEventArgs e)
    {
        (sender as Button).IsEnabled = false;
        readText = text[count].ToString();
        Thread thread = new Thread(new ThreadStart(Timer));
        thread.Start();
        ReadText = text[count] + text[count+1].ToString() + text[count+2] + text[count+3] + text[count+4];
    }

    private void Timer()
    {
        do
        {
            Thread.Sleep(1000);
            Time--;
        } while (Time != 0);

        stop = true;
    }

    private void StopTest()
    {
        List<Result> results = new List<Result>();
        try
        {
            string text = File.ReadAllText("ResultsTest.json");
            results = JsonConvert.DeserializeObject<List<Result>>(text); 
        }
        catch { }

        if (results == null)
        {
            results = new List<Result>();
        }
        
        int charMinut = Time != 0 ? Result * (Time/60 + 1) : Result;
        float charSecond = (float)Result / (60 - Time);
        results.Add(new Result(Name, charMinut, charSecond));
        
        File.WriteAllText("ResultsTest.json", JsonConvert.SerializeObject(results));
        
        RequestClose?.Invoke(this, EventArgs.Empty);
        
    }
}