using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            buttons = new List<Button> { _1, _2, _3, _4, _5, _6, _7, _8, _9 };
        }
        List<Button> buttons;
        Random random = new Random();
        string xod1 = "X";
        string xod2 = "O";

        private void Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content = xod1;
            (sender as Button).IsEnabled = false;

            Proverka();

            Robot();
            Proverka();
        }
        private void Robot()
        {
            bool proverka = false;
            int knopka;
            do
            {
                knopka = random.Next(1, 9);
                buttons.ForEach(item => { if (item.IsEnabled == true) { proverka = true; } });
                if (proverka == false) { break; }
            } while (false == buttons[knopka].IsEnabled);
            if (proverka == true)
            {
                buttons[knopka].Content = xod2;
                buttons[knopka].IsEnabled = false;
            }

            return;
        }
        private void Proverka()
        {
            bool proverka = false;
            buttons.ForEach(item => { if (item.IsEnabled == true) { proverka = true; } });

            if ((buttons[0].Content.ToString() == "X" && buttons[1].Content.ToString() == "X" && buttons[2].Content.ToString() == "X") || (buttons[3].Content.ToString() == "X" && buttons[4].Content.ToString() == "X" && buttons[5].Content.ToString() == "X") || (buttons[6].Content.ToString() == "X" && buttons[7].Content.ToString() == "X" && buttons[8].Content.ToString() == "X") || (buttons[0].Content.ToString() == "X" && buttons[3].Content.ToString() == "X" && buttons[6].Content.ToString() == "X") || (buttons[1].Content.ToString() == "X" && buttons[4].Content.ToString() == "X" && buttons[7].Content.ToString() == "X") || (buttons[2].Content.ToString() == "X" && buttons[5].Content.ToString() == "X" && buttons[8].Content.ToString() == "X") || (buttons[0].Content.ToString() == "X" && buttons[4].Content.ToString() == "X" && buttons[8].Content.ToString() == "X") || (buttons[2].Content.ToString() == "X" && buttons[4].Content.ToString() == "X" && buttons[6].Content.ToString() == "X"))
            {
                TextBlock.Text = "Победили крестики";
                buttons.ForEach(item => { item.IsEnabled = false; });
            }
            else if ((buttons[0].Content.ToString() == "O" && buttons[1].Content.ToString() == "O" && buttons[2].Content.ToString() == "O") || (buttons[3].Content.ToString() == "O" && buttons[4].Content.ToString() == "O" && buttons[5].Content.ToString() == "O") || (buttons[6].Content.ToString() == "O" && buttons[7].Content.ToString() == "O" && buttons[8].Content.ToString() == "O") || (buttons[0].Content.ToString() == "O" && buttons[3].Content.ToString() == "O" && buttons[6].Content.ToString() == "O") || (buttons[1].Content.ToString() == "O" && buttons[4].Content.ToString() == "O" && buttons[7].Content.ToString() == "O") || (buttons[2].Content.ToString() == "O" && buttons[5].Content.ToString() == "O" && buttons[8].Content.ToString() == "O") || (buttons[0].Content.ToString() == "O" && buttons[4].Content.ToString() == "O" && buttons[8].Content.ToString() == "O") || (buttons[2].Content.ToString() == "O" && buttons[4].Content.ToString() == "O" && buttons[6].Content.ToString() == "O"))
            {
                TextBlock.Text = "Победили нолики";
                buttons.ForEach(item => { item.IsEnabled = false; });
            }
            else if (proverka == false) { TextBlock.Text = "Ничья"; }


            return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = "Крестики-нолики";
            string a = xod2;
            xod2 = xod1;
            xod1 = a;
            foreach (Button button in buttons)
            {
                button.Content = "";
                button.IsEnabled = true;
            }
            if (xod1 == "O") { Robot(); }
        }
    }
}