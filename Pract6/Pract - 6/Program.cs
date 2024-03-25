using Newtonsoft.Json;
using Pract___6;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

public class Program
{
    static public void Main()
    {
        Desereoleze ds = new Desereoleze();
        ds.Menu();
    }
}
public class Desereoleze
{
    public void Menu()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Введите название файла");
        string file = Console.ReadLine();
        Console.Clear();
        if (file.EndsWith(".txt"))
        {
            TXT(file);
        }
        else if (file.EndsWith(".xml"))
        {
            XML(file);
        }
        else if (file.EndsWith(".json"))
        {
            JSON(file);
        }
    }
    private void TXT(string file)
    {
        string[] figures = File.ReadAllLines(file);
        Change ch = new Change();
        ch.input(figures);

    }
    private void XML(string file)
    {
        List<Figure> figures = new List<Figure>();
        XmlSerializer xml = new XmlSerializer(typeof(List<Figure>));
        using (FileStream fl = new FileStream(file, FileMode.OpenOrCreate))
        {
            figures = (List<Figure>)xml.Deserialize(fl);
        }
        string[] figur = new string[figures.Count * 3];
        int i = 0;
        foreach(Figure item in figures)
        {
            figur[i] = item.Name;
            i++;
            figur[i] = item.Dlina.ToString();
            i++;
            figur[i] = item.Shirina.ToString();
            i++;
        }
        Change ch = new Change();
        ch.input(figur);
    }
    private void JSON(string file)
    {
        string result = File.ReadAllText(file);
        List<Figure> figures = JsonConvert.DeserializeObject<List<Figure>>(result);
        string[] figur = new string[figures.Count * 3];
        int i = 0;
        foreach (Figure item in figures)
        {
            figur[i] = item.Name;
            i++;
            figur[i] = item.Dlina.ToString();
            i++;
            figur[i] = item.Shirina.ToString();
            i++;
        }
        Change ch = new Change();
        ch.input(figur);
    }
}
public class Change
{
    public void input(string[] figures)
    {
        int position;
        int position1;
        do
        {
            Console.WriteLine("Для записи файла нажмите F1. Закрыть программу - ESC");
            position = 1;
            foreach (string item in figures)
            {
                Console.SetCursorPosition(2, position);
                Console.Write(item);
                position++;
            }
            position1 = Strelochka(position-1);
            if (position1 < position)
            {
            Console.SetCursorPosition(2, position1);
            Console.Write("                       ");
            Console.SetCursorPosition(2, position1);
            figures[position1 - 1] = Console.ReadLine();
            Console.Clear();
            }
        } while (position1 < position);
        if (position1 == position)
        {
        Console.Clear();
        Sereolize sr = new Sereolize();
        sr.Ser(figures);
        }
    }
    private int Strelochka(int MaxStrelochka)
    {
        ConsoleKeyInfo key;
        int MinStrelochka = 1;
        int position = MinStrelochka;
        do
        {
            Console.SetCursorPosition(0, position);
            Console.Write("->");
            key = Console.ReadKey(true);
            Console.SetCursorPosition(0, position);
            Console.Write("  ");
            position = key.Key == ConsoleKey.UpArrow && position != MinStrelochka ? position -= 1 : key.Key == ConsoleKey.DownArrow && position != MaxStrelochka ? position += 1 : position;

        } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.F1 && key.Key != ConsoleKey.Escape);
        if (key.Key == ConsoleKey.Enter)
        {
        return position;
        }
        else if (key.Key == ConsoleKey.F1)
        {
            return MaxStrelochka + 1;
        }
        else
        {
            return MaxStrelochka + 2;
        }
    }
}
public class Sereolize
{
    public void Ser(string[] figures)
    {
        int count = figures.Count();
        List<Figure> figure = new List<Figure>();
        for (int i = 0; i < count; i += 3)
        {
            string name = figures[i];
            int dlina = int.Parse(figures[i + 1]);
            int shirina = int.Parse(figures[i + 2]);
            Figure list = new Figure(name, dlina, shirina);
            figure.Add(list);
        }
        Console.Clear();
        Console.WriteLine("Введите файл куда хотите записаь текст");
        string file = Console.ReadLine();
        if (file.EndsWith(".txt"))
        {
            TXT(file, figure);
        }
        else if (file.EndsWith(".xml"))
        {
            XML(file, figure);
        }
        else if (file.EndsWith(".json"))
        {
            JSON(file, figure);
        }
    }
    private void TXT(string file, List<Figure> figures)
    {
        foreach (Figure item in figures)
        {
            File.AppendAllText(file, $"{item.Name}\n{item.Dlina}\n{item.Shirina}\n");
        }
            Console.Clear();
        Console.WriteLine("Если хотите закрыть программу нажмите ESC\nДля продолжения нажмите любую кнопку");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key != ConsoleKey.Escape)
        {
            Console.Clear();
            Desereoleze ds = new Desereoleze();
            ds.Menu();
        }
    }
    private void XML(string file, List<Figure> figures)
    {
        XmlSerializer xml = new XmlSerializer(typeof(List<Figure>));
        using (FileStream fl = new FileStream(file, FileMode.OpenOrCreate))
        {
            xml.Serialize(fl, figures);
        }
        Console.Clear();
        Console.WriteLine("Если хотите закрыть программу нажмите ESC");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key != ConsoleKey.Escape)
        {
            Console.Clear();
            Desereoleze ds = new Desereoleze();
            ds.Menu();
        }
    }
    private void JSON(string file, List<Figure> figures)
    {
        string json = JsonConvert.SerializeObject(figures);
        File.WriteAllText(file, json);
        Console.Clear();
        Console.WriteLine("Если хотите закрыть программу нажмите ESC");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key != ConsoleKey.Escape)
        {
            Console.Clear();
            Desereoleze ds = new Desereoleze();
            ds.Menu();
        }
    }
}