using System;
using System.Numerics;

Console.OutputEncoding = System.Text.Encoding.UTF8;

int num, sum1, sum2;
double drobnoe1, drobnoe2;
do
{
    Console.WriteLine("Выберети действие");
    Console.WriteLine("1. Сложиь 2 числа");
    Console.WriteLine("2. Вычесть первое из второго");
    Console.WriteLine("3. Перемножить два числа");
    Console.WriteLine("4. Разделить первое на второе");
    Console.WriteLine("5. Возвести в степень N первое число");
    Console.WriteLine("6. Найти квадратный корень из числа");
    Console.WriteLine("7. Найти 1 процент от числа");
    Console.WriteLine("8. Найти факториал из числа");
    Console.WriteLine("9. Выход");
    int.TryParse(Console.ReadLine(), out num);
    switch (num)
    {
        case 1:
            Console.WriteLine("Введите первое число");
            double.TryParse(Console.ReadLine(), out drobnoe1);
            Console.WriteLine("Введите второе число");
            double.TryParse(Console.ReadLine(), out drobnoe2);
            Console.WriteLine("Ответ: " + (drobnoe1 + drobnoe2));
            break;
        case 2:
            Console.WriteLine("Введите первое число");
            double.TryParse(Console.ReadLine(), out drobnoe1);
            Console.WriteLine("Введите второе число");
            double.TryParse(Console.ReadLine(), out drobnoe2);
            Console.WriteLine("Ответ: " + (drobnoe1 - drobnoe2));
            break;
        case 3:
            Console.WriteLine("Введите первое число");
            double.TryParse(Console.ReadLine(), out drobnoe1);
            Console.WriteLine("Введите второе число");
            double.TryParse(Console.ReadLine(), out drobnoe2);
            Console.WriteLine("Ответ: " + (drobnoe1 * drobnoe2));
            break;
        case 4:
            Console.WriteLine("Введите первое число");
            double.TryParse(Console.ReadLine(), out drobnoe1);
            Console.WriteLine("Введите второе число");
            double.TryParse(Console.ReadLine(), out drobnoe2);
            if (drobnoe2 != 0)
            {
                Console.WriteLine("Ответ: " + (drobnoe1 / drobnoe2));
            }
            else
            {
                Console.WriteLine("Делить на ноль нельзя");
            }
            break;
        case 5:
            Console.WriteLine("Введите число");
            double.TryParse(Console.ReadLine(), out drobnoe1);
            Console.WriteLine("Введите степень");
            double.TryParse(Console.ReadLine(), out drobnoe2);
            Console.WriteLine("Ответ: " + (Math.Pow(drobnoe1, drobnoe2)));
            break;
        case 6:
            Console.WriteLine("Введите число");
            double.TryParse(Console.ReadLine(), out drobnoe1);
            Console.WriteLine("Ответ: " + (Math.Sqrt(drobnoe1)));
            break;
        case 7:
            Console.WriteLine("Введите число");
            double.TryParse(Console.ReadLine(), out drobnoe1);
            Console.WriteLine("Ответ: " + (drobnoe1 / 100));
            break;
        case 8:
            Console.WriteLine("Введите число");
            int.TryParse(Console.ReadLine(), out sum1);
            sum2 = 1;
            if (sum1 >= 0)
            {
                for (int i = 1; i <= sum1; i++)
                {
                    sum2 *= i;
                }
                Console.WriteLine("Ответ: " + sum2);
            }
            else
            {
                Console.WriteLine("Факториал начинается с нуля");
            }
            break;
    }
} while (num != 9);