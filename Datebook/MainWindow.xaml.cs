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

namespace Datebook
{
    public partial class MainWindow : Window
    {
        private List<Note> notes;
        public MainWindow()
        {
            InitializeComponent();
            notes = SerDeser.Deserialize<Note>("Note.json");
            DatePicker.Text = DateTime.Now.Date.ToString();
        }
        private void DatePicker_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Read(Convert.ToDateTime(DatePicker.Text));
            return;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            Note note = new Note(Name.Text, Description.Text, Convert.ToDateTime(DatePicker.Text));
            notes.Add(note);
            SerDeser.Sereolize<List<Note>>(notes, "Note.json");
            Read(Convert.ToDateTime(DatePicker.Text));
            return;
        }
        private void Read(DateTime date)
        {
            List<Note> sorted = notes.Where(x => x.Date == date).ToList();
            ListBox.DisplayMemberPath = "Name";
            ListBox.ItemsSource = null;
            ListBox.ItemsSource = sorted;
            return;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection = ListBox.SelectedItems;
            if (selection.Count > 0)
            {
                Name.Text = (selection[0] as Note).Name;
                Description.Text = (selection[0] as Note).Description;
            }
            return;
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            try
            {
                var note = ListBox.SelectedItems[0] as Note;
                int index = notes.FindIndex(item => item == note);
                notes[index] = new Note(Name.Text, Description.Text, Convert.ToDateTime(DatePicker.Text));
                SerDeser.Sereolize<List<Note>>(notes, "Note.json");
                Read(Convert.ToDateTime(DatePicker.Text));
                return;
            }
            catch
            {
                return;
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                var note = ListBox.SelectedItems[0] as Note;
                int index = notes.FindIndex(item => item == note);
                notes.RemoveAt(index);
                SerDeser.Sereolize<List<Note>>(notes, "Note.json");
                Read(Convert.ToDateTime(DatePicker.Text));
                return;
            }
            catch
            {
                return;
            }
        }
    }
}