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

namespace CreateTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox textBox = new TextBox {Name = "textBox"};
            mainGrid.Children.Add(textBox);
            Grid.SetRow(textBox, 3);
            textBox.Margin = new Thickness(20);
            textBox.KeyUp += textBox_KeyUp;
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter & (sender as TextBox).Text == "бам бам")
            {
                TestWindow testWindow = new TestWindow(true);
                this.Close();
                testWindow.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TestWindow testWindow = new TestWindow(false);
            this.Close();
            testWindow.Show();
        }
    }
}