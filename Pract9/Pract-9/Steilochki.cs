
namespace Pract_9
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

            } while (key.Key != ConsoleKey.F1 && key.Key != ConsoleKey.F10 && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace);
            if (key.Key == ConsoleKey.F1)
            {
                return (int)Pract_9.Key.F1;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                return position;
            }
            else if (key.Key == ConsoleKey.F10)
            {
                return (int)Pract_9.Key.F10;
            }
            else
            {
                return (int)Pract_9.Key.Backsсape;
            }
        }
    }
}
