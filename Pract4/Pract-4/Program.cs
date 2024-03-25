using Pract_4;
using System.ComponentModel;
using System.Linq;
using System.Text;

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        DateTime a = DateTime.Now;
        DateOnly d = DateOnly.FromDateTime(a);
        Zametka zametka1 = new Zametka();
        zametka1.name = "Взломать пентагон";
        zametka1.opisanie = "Типичный день русского хакера";
        zametka1.data = new DateOnly(2023, 10, 14);
        Zametka zametka2 = new Zametka();
        zametka2.name = "Сходить на пары";
        zametka2.opisanie = "4 пары";
        zametka2.data = new DateOnly(2023, 10, 14);
        Zametka zametka3 = new Zametka();
        zametka3.name = "Написать практос по шарпу";
        zametka3.opisanie = "Не очень хочется, но надо";
        zametka3.data = new DateOnly(2023, 10, 16);
        Zametka zametka4 = new Zametka();
        zametka4.name = "Поиграть в плойку";
        zametka4.opisanie = "Допройти наконец-то God of War";
        zametka4.data = new DateOnly(2023, 10, 16);
        Zametka zametka5 = new Zametka();
        zametka5.name = "Сходить на пары";
        zametka5.opisanie = "3 пары";
        zametka5.data = new DateOnly(2023, 10, 17);
        List<Zametka> Zametkas = new List<Zametka>() { zametka1, zametka2, zametka3, zametka4, zametka5 };
        Arrow(d, Zametkas);
    }
    static public void Arrow(DateOnly d, List<Zametka> Zametkas)
    {
        Console.Clear();
        Console.Write(" Выбрана дата:" + d);
        ConsoleKeyInfo key;
        int position = 1;
        int i = 1;
        List<Zametka> sorted = Zametkas.Where(item => item.data == d).ToList();
        foreach (var item in sorted)
        {
            Console.SetCursorPosition(2, i);
            Console.Write(i + ". " + item.name);
            i++;
        }
        do
        {
            Console.SetCursorPosition(0, position);
            Console.Write("->");
            key = Console.ReadKey(true);
            Console.SetCursorPosition(0, position);
            Console.Write("  ");
            position = key.Key == ConsoleKey.UpArrow && position != 1 ? position-=1 : key.Key == ConsoleKey.DownArrow && position != 4 ? position+=1 : position;
            if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.RightArrow)
            {
                Date(key, d, Zametkas);
            }
            if (key.Key == ConsoleKey.Enter)
            {
                Opisanie(position, d, sorted, Zametkas);
            }
            if (key.Key == ConsoleKey.Tab)
            {
                Zapis(Zametkas);
            }
        } while (key.Key != ConsoleKey.Escape);
    }
    static void Date(ConsoleKeyInfo key, DateOnly d, List<Zametka> Data)
    {
        if (key.Key == ConsoleKey.LeftArrow)
        {
            d = d.AddDays(-1);
            Arrow(d, Data);
        }
        else if (key.Key == ConsoleKey.RightArrow)
        {
            d = d.AddDays(1);
            Arrow(d, Data);
        }
    }
    static void Opisanie(int num, DateOnly d, List<Zametka> sorted, List<Zametka> Zametkas)
    {
        ConsoleKeyInfo key;
        do
        {
            Console.Clear();
            int i = 1;
            foreach (var item in sorted)
            {
                if (i == num)
                {
                    Console.WriteLine(item.data + "\n---------------\n" + item.name + "\n---------------\n" + item.opisanie + "\n---------------\n");
                }
                i++;
            }
            Console.WriteLine("Для выхода нажмите ESC");
            key = Console.ReadKey(true);
        } while (key.Key != ConsoleKey.Escape);
        Arrow(d, Zametkas);
    }
    static void Zapis(List<Zametka> Zametkas)
    {
        Console.Clear();
        DateOnly d = new DateOnly();
        Console.Write("Введите дату: ");
        DateOnly.TryParse(Console.ReadLine(), out d);
        Zametka zametka6 = new Zametka();
        Console.WriteLine("Введите название: ");
        zametka6.name = Console.ReadLine();
        Console.WriteLine("Введите описание: ");
        zametka6.opisanie = Console.ReadLine();
        zametka6.data = d;
        Zametkas.Add(zametka6);
        Arrow(d, Zametkas);
    }
}