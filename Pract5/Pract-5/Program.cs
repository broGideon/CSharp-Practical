using Pract_5;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Globalization;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

class Program
{

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        List<PodZakaz> forma = new List<PodZakaz>() {
        new PodZakaz("Круг", 300),
        new PodZakaz("Квадрат", 200),
        new PodZakaz("Сердечко", 500),
        new PodZakaz("Прямоугольник", 200),
        };
        Zakaz forma0 = new Zakaz("Форма", forma);
        List<PodZakaz> razmer = new List<PodZakaz>() {
        new PodZakaz("Маленький (диаметр - 20 см)", 500),
        new PodZakaz("Средний (диаметр - 30 см)", 700),
        new PodZakaz("Большой (диаметр - 45 см)", 1200),
        };
        Zakaz razmer0 = new Zakaz("Размер", razmer);
        List<PodZakaz> vkys = new List<PodZakaz>() {
        new PodZakaz("Малиновый", 300),
        new PodZakaz("Банановый", 700),
        new PodZakaz("Шоколадный", 1200),
        new PodZakaz("Клубничный", 1200),
        };
        Zakaz vkys0 = new Zakaz("Вкус коржа", vkys);
        List<PodZakaz> colvo = new List<PodZakaz>() {
        new PodZakaz("3 коржа", 300),
        new PodZakaz("4 коржа", 400),
        new PodZakaz("5 коржей", 500),
        new PodZakaz("6 коржей", 600),
        };
        Zakaz colvo0 = new Zakaz("Количество коржей", colvo);
        List<PodZakaz> glaz = new List<PodZakaz>() {
        new PodZakaz("Шоколад", 400),
        new PodZakaz("Крем", 400),
        new PodZakaz("Бизе", 500),
        new PodZakaz("Ягоды", 600),
        };
        Zakaz glaz0 = new Zakaz("Глазурь", glaz);
        List<PodZakaz> dec = new List<PodZakaz>() {
        new PodZakaz("Фигурки", 700),
        new PodZakaz("Ягодки", 700),
        new PodZakaz("Рисуночки", 700),
        };
        Zakaz dec0 = new Zakaz("Декор", dec);
        List<Zakaz> Pynkt = new List<Zakaz>() { forma0, razmer0, vkys0, colvo0, glaz0, dec0 };
        Punkts m = new Punkts(Pynkt);
        m.Input();
    }
}
public class Punkts
{
    private List<Zakaz> Pynkt;
    public Punkts(List<Zakaz> Pynkt)
    {
        this.Pynkt = Pynkt;
    }
    public void Input()
    {
        int position;
        int prise = 0;
        List<string> Zak = new List<string>();
        do
        {
            int min = 3;
            int max = 3;
            Console.SetCursorPosition(0, 0);    
            Console.WriteLine("Заказ тортиков в ГЛАЗУРЬКА!\nВыберети параметр тортика\n--------------");
            foreach (var item in Pynkt)
            {
                Console.SetCursorPosition(2, max);
                Console.WriteLine(item.Name);
                max++;
            }
            Console.SetCursorPosition(2, max);
            Console.WriteLine("Завершить заказ");
            Strelochki arrow1 = new Strelochki(min, max);
            position = arrow1.Menu();
            Console.Clear();
            Console.SetCursorPosition(0, 0);    
            Console.WriteLine("Для выхода нажмите ESC\nВыберети пункт из меню\n--------------");
            if (position != 9)
            {
                Zakaz d = Pynkt[position - min];
                List<string> Pod = new List<string>();
                List<int> Prises = new List<int>();
                max = min;
                foreach (var item in Pynkt)
                {
                    if (item.Name == d.Name)
                    {
                        foreach (var item2 in item.PodZakazs)
                        {
                            Console.SetCursorPosition(2, max);
                            Console.WriteLine(item2.name + " - " + item2.Prise);
                            Pod.Add(item2.name);
                            Prises.Add(item2.Prise);
                            max++;
                        }
                    }
                }
                Strelochki arrow2 = new Strelochki(min, max - 1);
                position = arrow2.Menu();
                Console.Clear();
                if (position != 10)
                {
                    Zak.Add(Pod[position - min]);
                    prise += Prises[position - min];
                }
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("Итоговая цена: " + prise);
                Zak.ForEach(item => { Console.Write(item + ", "); });
            }
        } while (position != 9);
        Console.Clear();
        TXT(Zak,prise);
    }
    private void TXT(List<string> Zak, int prise)
    {
        DateTime d = DateTime.Now;
        string file = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        file = file + "\\test.txt";
        File.AppendAllText(file, $"Заказ от: {d}\nЗаказ: ");
        Zak.ForEach(item => { File.AppendAllText(file, $"{item}, "); });
        /*foreach (var item in Zak)
        {
            File.AppendAllText(file, $"{item}, ");
        }*/
        File.AppendAllText(file, $"\nИтоговая цена: {prise}\n\n");
        Console.WriteLine("Для создания нового тортика нажмите ENTER");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            Input();
        }
    }
}