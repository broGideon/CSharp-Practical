using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract_5
{
    internal class Strelochki
    {
        private int MaxStrelochka;
        private int MinStrelochka;
        public Strelochki(int min, int max) 
        { 
            MaxStrelochka = max;
            MinStrelochka = min;
        }
        public int Menu()
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
                return 10;
            }
        }
    }
}
