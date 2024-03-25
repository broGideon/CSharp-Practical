using System.Diagnostics.Tracing;

namespace Практос
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int menu;
            do
            {
                Console.WriteLine("Выберети действие");
                Console.WriteLine("1. 'Игра Угадай число'");
                Console.WriteLine("2. Таблица умножения");
                Console.WriteLine("3. Вывод делителей числа");
                Console.WriteLine("4. Выход");
                int.TryParse(Console.ReadLine(), out menu);
                switch (menu)
                {
                    case 1:
                        YgadaiChislo();
                        break;
                    case 2:
                        TablitsaYmnogenia();
                        break;
                    case 3:
                        DeliteliChisla();
                        break;
                }
            } while (menu != 4);
        }

        static void YgadaiChislo()
        {
            int Sravnenie;
            Random r = new Random();
            int random = r.Next(1, 100);
            do
            {
                Console.Write("Введите число: ");
                int.TryParse(Console.ReadLine(), out Sravnenie);
                if (random == Sravnenie)
                {
                    Console.WriteLine("В точку!!!");
                }
                else if (random > Sravnenie)
                {
                    Console.WriteLine("Больше");
                }
                else if (random < Sravnenie)
                {
                    Console.WriteLine("Меньше");
                }
            } while (Sravnenie != random);
        }
        static void TablitsaYmnogenia()
        {
            int[,] mas = new int[10, 10];
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    mas[i - 1, j - 1] = i * j;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(mas[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void DeliteliChisla()
        {
            int Chislo, Ostatok, menu;
            do
            {
                Console.Write("Введите число: ");
                int.TryParse(Console.ReadLine(), out Chislo);
                Console.Write("Делители: ");
                for (int i = 1; i <= Chislo; i++)
                {
                    Ostatok = Chislo % i;
                    if (Ostatok == 0)
                        Console.Write(i + " ");
                }
                Console.WriteLine("\n Продолжаем?" + "\n Для продолжения нажмите любую кнопку" + "\n Для выхода нажмите 7");
                int.TryParse(Console.ReadLine(), out menu);
            } while (menu != 7);
        }

    }
}