using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using Windows.UI.Xaml.Controls;
using System.Globalization;
using System.Data;

namespace Audioplayer
{
    public partial class HistoryWindow : Window
    {
        public int SelectionIndex;
        public HistoryWindow(List<string> files)
        {
            InitializeComponent();
            List<string> sorted = new List<string>();
            foreach (string item in files)
            {
                sorted.Add(item.Substring(item.LastIndexOf('\\') + 1));
            }
            history.ItemsSource = sorted;
        }
        private void history_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectionIndex = history.SelectedIndex;
            this.Close();
        }
        
    }
}
