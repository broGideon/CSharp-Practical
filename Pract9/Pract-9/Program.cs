using Pract_9;
using System.Diagnostics;
using System.IO;
using System.Text;

static class Program
{
    static public void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        UsingHotKey use = new UsingHotKey();
        use.A();
    }
}
public class UsingHotKey
{
    public void A()
    {
        int position;
        do
        {
            Console.Clear();
            Console.WriteLine("Менеджер горячих клавиш\nF1 - Создание горячей клавиши\nF10 - Перейти в режим выполнения горячих клавишей");
            string file = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            file = file + "\\HotKey";
            List<HotKey> hotKeys = SerDeser.Deserialize(file);
            int pos = 3;
            foreach (HotKey hotKey in hotKeys)
            {
                Console.SetCursorPosition(2, pos);
                pos++;
                Console.WriteLine($"{hotKey.Key} - {hotKey.Path.Substring(hotKey.Path.LastIndexOf('\\')+1)}");
            }
            Strelochki strelocki = new Strelochki(3, pos-1);
            position = strelocki.Menu();
            if (position == (int)Pract_9.Key.F1)
            {
                CreateHotKey(hotKeys, file, pos);
            }
            else if (position == (int)Pract_9.Key.F10)
            {
                UseHoteKey(hotKeys);
            }
            else if (position != (int)Pract_9.Key.Backsсape)
            {
                ShowInformation(position - 3, file);
            }
        } while (position != (int)Pract_9.Key.Backsсape);
    }
    private void CreateHotKey(List<HotKey> hotKeys, string file, int pos)
    {
        Boolean prov;
        do
        {
            prov = true;
            List<Char> keys = new List<char>();
            foreach (HotKey hotKey in hotKeys)
            {
                keys.Add(hotKey.Key);
            }
            Console.SetCursorPosition(0, pos);
            Console.WriteLine("----------------------\nВведите клавишу:");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.F10 || key.Key == ConsoleKey.Backspace)
            {
                Console.WriteLine("\nНа эту кнопку забиндить нельзя");
                pos = pos + 4;
                prov = false;
            }
            foreach (Char keyChar in keys)
            {
                if (keyChar == key.KeyChar)
                {
                    Console.WriteLine("\nТакая кнопка уже есть");
                    pos = pos + 4;
                    prov = false;
                    break;
                }
            }
            if (prov == true)
            {
                Console.SetCursorPosition(0, pos+3);
                Console.WriteLine("Введите путь до файла: ");
                string path = Console.ReadLine();
                HotKey newHotKey = new HotKey(path, key.KeyChar);
                hotKeys.Add(newHotKey);
                SerDeser.Serialize(hotKeys, file);
                return;
            }
        } while (prov != true);
    }
    private void UseHoteKey(List<HotKey> hotKeys)
    {
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            foreach (HotKey hotKey in hotKeys)
            {
                if (hotKey.Key == key.KeyChar)
                {
                    string path = hotKey.Path;
                    try
                    {
                    Process.Start(new ProcessStartInfo { FileName = path, UseShellExecute = true });
                    }
                    catch  
                    { 
                        Console.WriteLine(""); 
                    }
                    break;
                }
            }
        } while (key.Key != ConsoleKey.Backspace);
        return;
    }
    private void ShowInformation(int pos, string path)
    {
        try
        {
        List<HotKey> hotKeys = SerDeser.Deserialize(path);
        var hotKey = hotKeys[pos];
        Console.Clear();
        Console.WriteLine($"Кнопочка - {hotKey.Key}");
        Console.WriteLine($"Путь до файла - {hotKey.Path}\n------------------");
        Console.WriteLine("F1 - Изменение горячей клавиши\nF2 - Удаление горячей клавиши");
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.F1)
            {
                UpdateHotKey(hotKeys, pos, path);
                break;
            }
            else if (key.Key == ConsoleKey.F2)
            {
                var sorted = hotKeys.Where(item => item != hotKey).ToList();
                SerDeser.Serialize(sorted, path);
                break;
            }
        } while (key.Key != ConsoleKey.Backspace);
        return;
        }
        catch
        {
            return;
        }
    }
    private void UpdateHotKey(List<HotKey> hotKeys, int pos, string file)
    {
        List<Char> keys = new List<char>();
        Boolean prov;
        do
        {
            prov = true;
            foreach (HotKey hotKey in hotKeys)
            {
                keys.Add(hotKey.Key);
            }
            Console.SetCursorPosition(0, pos);
            Console.WriteLine("----------------------\nВведите новую клавишу:");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.F10 || key.Key == ConsoleKey.Backspace)
            {
                Console.WriteLine("На эту кнопку забиндить нельзя");
                prov = false;
            }
            foreach (Char keyChar in keys)
            {
                if (keyChar == key.KeyChar)
                {
                    Console.Write("Такая кнопка уже есть");
                    prov = false;
                    break;
                }
            }
            if (prov == true)
            {
                Console.WriteLine("\nВведите новый путь до файла: ");
                string path = Console.ReadLine();
                HotKey newHotKey = new HotKey(path, key.KeyChar);
                hotKeys[pos] = newHotKey;
                SerDeser.Serialize(hotKeys, file);
                ShowInformation(pos, file);
            }
        } while (prov != true);
    }
}
