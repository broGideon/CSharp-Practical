using System.Globalization;
using System.IO;
using System;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.WindowsAPICodePack.Dialogs;
using Windows.UI.Xaml.Media;
using System.Runtime.InteropServices;

namespace Audioplayer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            soundSlider.Value = (float)1;
            media.Volume = (float)1;
        }
        private int index = 0;
        List<string> sorted;
        List<string> history = new List<string>();
        List<string> save = new List<string>();
        bool rand = false;
        bool prov = false;
        bool repeat = false;
        bool IsClosed = false;
        TimeSpan time;
        private void audioSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Position = new TimeSpan(Convert.ToInt64(audioSlider.Value));
            if (media.Position == media.NaturalDuration)
            {
                if (!repeat)
                    index++;
                playMediaElement(sorted[index]);
            }
        }

        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            audioSlider.Maximum = media.NaturalDuration.TimeSpan.Ticks;
        }

        private void soundSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Volume = (float)e.NewValue;
        }

        private void Folder_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog { IsFolderPicker = true };
            var result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                List<string> paths = Directory.GetFiles(dialog.FileName).ToList();
                sorted = paths.Where(item => System.IO.Path.GetExtension(item) == ".mp3" || System.IO.Path.GetExtension(item) == ".mp4a" || System.IO.Path.GetExtension(item) == ".wav").ToList();
                List<string> files = new List<string>();
                foreach (string item in sorted)
                {
                    files.Add(item.Substring(item.LastIndexOf('\\') + 1));
                }
                listBox.ItemsSource = null;
                listBox.ItemsSource = files;
                playMediaElement(sorted[index]);
                Thread thread = new Thread(new ThreadStart(timer));
                thread.Start();
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index = listBox.SelectedIndex;
            if (index >= 0)
            {
                playMediaElement(sorted[index]);
            }
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (prov == false)
                {
                    playMediaElement(sorted[index]);
                    media.Position = time;

                }
                else
                {
                    time = media.Position;
                    media.Stop();
                    prov = false;
                }

            }
            catch { }
        }
        private void timer()
        {
            do
            {
                if (prov != false)
                    Dispatcher.Invoke(() => audioSlider.Value = media.Position.Ticks);
                    Dispatcher.Invoke(() => timeMedia.Text = media.Position.ToString(@"hh\:mm\:ss"));
                    Dispatcher.Invoke(() => remainingTime.Text = TimeSpan.FromTicks((long)audioSlider.Maximum - media.Position.Ticks).ToString(@"hh\:mm\:ss"));
                
                Thread.Sleep(1000);
            } while (!IsClosed);
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            index--;
            if (index == -1)
            {
                index = sorted.Count - 1;
            }
            playMediaElement(sorted[index]);
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            index++;
            if (index == sorted.Count)
            {
                index = 0;
            }
            playMediaElement(sorted[index]);
        }

        private void history_button_Click(object sender, RoutedEventArgs e)
        {
            HistoryWindow historyWindow = new HistoryWindow(history);
            historyWindow.ShowDialog();
            int selectionIndex = historyWindow.SelectionIndex;
            historyWindow.Close();
            playHistory(selectionIndex);
        }
        public void playHistory(int selectionIndex)
        {
            playMediaElement(history[selectionIndex]);

            return;
        }
        private void playMediaElement(string file)
        {
            history.Add(file);
            media.Source = new Uri(file);
            media.Play();
            prov = true;
            return;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (repeat)
                repeat = false;
            else
                repeat = true;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            IsClosed = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!rand)
            {
                sorted.ForEach(item => save.Add((string)item.Clone()));
                Random random = new Random();
                for (int i = sorted.Count - 1; i >= 1; i--)
                {
                    int j = random.Next(i + 1);
                    var temp = sorted[j];
                    sorted[j] = sorted[i];
                    sorted[i] = temp;
                }
                rand = true;
            }
            else
            {
                sorted.Clear();
                save.ForEach(item => sorted.Add((string)item.Clone()));
                save.Clear();
                rand = false;
            }
            listBox.ItemsSource = null;
            List<string> strings = new List<string>();
            foreach (var item in sorted)
            {
                strings.Add(item.Substring(item.LastIndexOf('\\') + 1));
            }
            listBox.ItemsSource = strings;
        }
    }
}