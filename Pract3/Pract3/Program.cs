using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Октавы: F1, F2, F3, F4, F5, F6");
        ConsoleKeyInfo Octava = Console.ReadKey();
        Octavi(Octava);
    }
    static void Octavi(ConsoleKeyInfo Octava)
    {
        Console.WriteLine("Включена октава - " + Octava.Key);
        switch (Octava.Key)
        {
            case ConsoleKey.F1:
                int[] octava1 = new int[] { 163, 173, 183, 194, 206, 218, 231, 245, 259, 275, 291, 308 };
                f(octava1);
                break;
            case ConsoleKey.F2:
                int[] octava2 = new int[] { 327, 346, 367, 388, 412, 436, 462, 490, 519, 550, 582, 617 };
                f(octava2);
                break;
            case ConsoleKey.F3:
                int[] octava3 = new int[] { 654, 693, 734, 777, 824, 873, 925, 980, 1038, 1100, 1165, 1235 };
                f(octava3);
                break;
            case ConsoleKey.F4:
                int[] octava4 = new int[] { 1308, 1386, 1468, 1556, 1648, 1746, 1850, 1960, 2077, 2200, 2331, 2469 };
                f(octava4);
                break;
            case ConsoleKey.F5:
                int[] octava5 = new int[] { 2616, 2772, 2937, 3111, 3296, 3492, 3700, 3920, 4153, 4400, 4662, 4939 };
                f(octava5);
                break;
            case ConsoleKey.F6:
                int[] octava6 = new int[] { 5233, 5544, 5873, 6223, 6593, 6985, 7400, 7840, 8306, 8800, 9323, 9878 };
                f(octava6);
                break;
            
        }
    }
    static void f(int[] octava)
    {
        ConsoleKeyInfo num;
        do
        {
            num = Console.ReadKey(true);
            switch (num.Key)
            {
                case ConsoleKey.D1:
                    Console.Beep(octava[0], 800);
                    break;
                case ConsoleKey.D2:
                    Console.Beep(octava[1], 800);
                    break;
                case ConsoleKey.D3:
                    Console.Beep(octava[2], 800);
                    break;
                case ConsoleKey.D4:
                    Console.Beep(octava[3], 800);
                    break;
                case ConsoleKey.D5:
                    Console.Beep(octava[4], 800);
                    break;
                case ConsoleKey.D6:
                    Console.Beep(octava[5], 800);
                    break;
                case ConsoleKey.D7:
                    Console.Beep(octava[6], 800);
                    break;
                case ConsoleKey.D8:
                    Console.Beep(octava[7], 800);
                    break;
                case ConsoleKey.D9:
                    Console.Beep(octava[8], 800);
                    break;
                case ConsoleKey.D0:
                    Console.Beep(octava[9], 800);
                    break;
                case ConsoleKey.OemMinus:
                    Console.Beep(octava[10], 800);
                    break;
                case ConsoleKey.OemPlus:
                    Console.Beep(octava[11], 800);
                    break;
                case ConsoleKey.F1:
                    Octavi(num);
                    break;
                case ConsoleKey.F2:
                    Octavi(num);
                    break;
                case ConsoleKey.F3:
                    Octavi(num);
                    break;
                case ConsoleKey.F4:
                    Octavi(num);
                    break;
                case ConsoleKey.F5:
                    Octavi(num);
                    break;
                case ConsoleKey.F6:
                    Octavi(num);
                    break;
            }
        } while (num.Key != ConsoleKey.Escape);
    }
}