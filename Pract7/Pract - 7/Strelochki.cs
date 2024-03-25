using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract___7
{
    static class Strelochki
    {
        static public int menuDrive(int MinStrelochka, int MaxStrelochka)
        {
            int position = MinStrelochka;
            ConsoleKeyInfo key;
            do
            {
                Console.SetCursorPosition(0, position);
                Console.Write("->");
                key = Console.ReadKey(true);
                Console.SetCursorPosition(0, position);
                Console.Write("  ");
                position = key.Key == ConsoleKey.UpArrow && position != MinStrelochka ? position -= 1 : key.Key == ConsoleKey.DownArrow && position != MaxStrelochka ? position += 1 : position;

            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            if (key.Key == ConsoleKey.Enter)
            {
                return position;
            }
            else
            {
                return -1;
            }
        }
        static public int menuDirectory(int MinStrelochka, int MaxStrelochka, string papka)
        {
            int position = MinStrelochka;
            ConsoleKeyInfo key;
            do
            {
                Console.SetCursorPosition(0, position);
                Console.Write("->");
                key = Console.ReadKey(true);
                Console.SetCursorPosition(0, position);
                Console.Write("  ");
                if (key.Key == ConsoleKey.F1 || key.Key == ConsoleKey.F2 || key.Key == ConsoleKey.F3 || key.Key == ConsoleKey.F4)
                {
                    papki.createOrDelete(papka, key);
                    return -2;
                }
                position = key.Key == ConsoleKey.UpArrow && position != MinStrelochka ? position -= 1 : key.Key == ConsoleKey.DownArrow && position != MaxStrelochka ? position += 1 : position;

            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            if (key.Key == ConsoleKey.Enter)
            {
                return position;
            }
            else
            {
                return -1;
            }
        }
    }
    static class papki
    {
        static public void createOrDelete(string papka, ConsoleKeyInfo key)
        {
            try
            {
                if (key.Key == ConsoleKey.F1)
                {
                    Console.SetCursorPosition(93, 11);
                    Console.WriteLine("Ну давай создавай");
                    Console.SetCursorPosition(93, 12);
                    Console.WriteLine("Введи название...");
                    Console.SetCursorPosition(93, 13);
                    string path = Console.ReadLine();
                    if (Directory.Exists(papka + '\\' + path) == false)
                    {
                        Directory.CreateDirectory(papka + '\\' + path);
                    }
                    return;
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    Console.SetCursorPosition(93, 11);
                    Console.WriteLine("Ну и зачем удалять-то?");
                    Console.SetCursorPosition(93, 12);
                    Console.WriteLine("Введи название...");
                    Console.SetCursorPosition(93, 13);
                    string path = Console.ReadLine();
                    if (Directory.Exists(papka + '\\' + path))
                    {
                        Directory.Delete(papka + '\\' + path, true);
                        return;
                    }
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    Console.SetCursorPosition(93, 11);
                    Console.WriteLine("Ну давай создавай");
                    Console.SetCursorPosition(93, 12);
                    Console.WriteLine("Введи название...");
                    Console.SetCursorPosition(93, 13);
                    string path = Console.ReadLine();
                    if (File.Exists(papka + '\\' + path) == false)
                    {
                        File.Create(papka + '\\' + path);
                    }
                    return;
                }
                else if (key.Key == ConsoleKey.F4)
                {
                    Console.SetCursorPosition(93, 11);
                    Console.WriteLine("Ну и зачем удалять-то?");
                    Console.SetCursorPosition(93, 12);
                    Console.WriteLine("Введи название...");
                    Console.SetCursorPosition(93, 13);
                    string path = Console.ReadLine();
                    if (File.Exists(papka + '\\' + path))
                    {
                        File.Delete(papka + '\\' + path);
                    }
                    return;
                }
            }
            catch 
            {
                return;
            }
        }
    }
}
