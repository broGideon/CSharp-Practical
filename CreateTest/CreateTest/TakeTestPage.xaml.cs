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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CreateTest
{
    /// <summary>
    /// Логика взаимодействия для TakeTestPage.xaml
    /// </summary>
    public partial class TakeTestPage : Page
    {
        private List<Test> tests = new List<Test>();
        int pos = 0;
        int result = 0;
        int variantOtveta;
        public TakeTestPage()
        {
            InitializeComponent();
            tests = SerDeser.Deserialize();
            name.Text = tests[pos].Name;
            description.Text = tests[pos].Description;
            _1.Content = tests[pos].FirstQuestion;
            _2.Content = tests[pos].SecondQuestion;
            _3.Content = tests[pos].ThirdQuestion;
            variantOtveta = (int)tests[pos].VariantOtveta;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            pos++;
            if (pos == tests.Count)
            {
                myGrid.Children.Clear();
                myGrid.RowDefinitions.Clear();
                myGrid.RowDefinitions.Add(new RowDefinition());
                TextBlock textBlock = new TextBlock();
                myGrid.Children.Add(textBlock);
                Grid.SetColumn(textBlock, 0);
                Grid.SetRow(textBlock, 0);
                textBlock.Text = $"Правильных ответов {result} из {pos}";
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.FontSize = 24;
                return;
            }
            string otvet = "_" + variantOtveta;
            if ((sender as Button).Name == otvet)
            {
                result++;
            }
            name.Text = tests[pos].Name;
            description.Text = tests[pos].Description;
            _1.Content = tests[pos].FirstQuestion;
            _2.Content = tests[pos].SecondQuestion;
            _3.Content = tests[pos].ThirdQuestion;
            variantOtveta = (int)tests[pos].VariantOtveta;
        }
    }
}
