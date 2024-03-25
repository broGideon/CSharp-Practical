using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace CreateTest
{
    public partial class TestWindow : Window
    {
        public TestWindow(bool createTest)
        {
            InitializeComponent();
            CreateTest.IsEnabled = createTest;
        }

        private void TakeTest_Click(object sender, RoutedEventArgs e)
        {
            var tests = SerDeser.Deserialize();
            if (tests.Count == 0)
            {
                PageFraim.Content = new NotTestPage();
                return;
            }
            PageFraim.Content = new TakeTestPage();
        }

        private void CreateTest_Click(object sender, RoutedEventArgs e)
        {
            PageFraim.Content = new CreateTestPage();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
