using Newtonsoft.Json;
using pract___8;
using System.IO;
using System.Text;

class Program
{
    public static string name;
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.Write("Введите имя для таблицы рекордов: ");
        name = Console.ReadLine();
        Random r = new Random();
        int rand = r.Next(1, 4);
        if (rand == 1)
        {
            string text = "Тучу передернуло синим пламенем. Медленно загремел гром. Он то усиливался, то почти затихал. " +
                "И дождь, подчиняясь грому, начал временами идти сильнее и широко шуметь по листве, потом останавливался. " +
                "Вскоре сквозь тучи пробилось солнце. Старый пушкинский парк в Михайловском и крутые берега Сороти запылали " +
                "рыжей глиной и мокрой травой. Стройная радуга зажглась нал пасмурной далью. Она сверкала и дымилась, окруженная " +
                "космами пепельных туч. Радуга была похожа на арку, воздвигнутую на границе заповедной земли. С особенной силой " +
                "здесь, в пушкинских местах, возникали мысли о русском языке.";
            Test test = new Test();
            test.text = text;
            test.OutputText();
        }
        else if (rand == 2)
        {
            string text = "Когда восходит луна, ночь становится бледной и томной. Воздух прозрачен, свеж и тепел, всюду хорошо " +
                "видно и даже можно различить у дороги отдельные стебли бурьяна. Широкие тени ходят по равнине, как облака по небу, " +
                "а в непонятной дали высятся, громоздятся друг на друга туманные, причудливые образы. Немножко жутко. А взглянешь " +
                "на бледно-зеленое, усыпанное звездами небо, на котором ни облачка, ни пятна, и поймешь, почему теплый воздух недвижим, " +
                "почему природа боится шевельнуться. Ей жутко и жаль утерять хоть одно мгновение жизни.";
            Test test = new Test();
            test.text = text;
            test.OutputText();
        }
        else
        {
            string text = "Приближение грозы Солнце склонялось к западу и косыми жаркими лучами невыносимо жгло мне шею и щеки. Невозможно " +
                "было дотронуться до раскаленных краев брички. Густая пыль поднималась по дороге и наполняла воздух. Не было ни малейшего ветерка, " +
                "который относил бы ее. Все мое внимание было устремлено на верстовые столбы, которые я замечал издалека, и на облака, которые " +
                "собирались в одну большую, мрачную тучу. Изредка погромыхивал дальний гром. Гроза наводила на меня невыразимо тяжелое чувство тоски и страха.";
            Test test = new Test();
            test.text = text;
            test.OutputText();
        }
    }
}
public class Test
{
    public int result;
    public int error;
    public int num = 60;
    public string text;
    public void OutputText()
    {
        Console.Clear();
        Console.WriteLine(text + "\n-----------------\nНажмите Enter для запуска");
        Thread thread = new Thread(new ThreadStart(Timer));
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
        } while (key.Key != ConsoleKey.Enter);
        thread.Start();
        int line = 0;
        int column = 0;
        result = 0;
        error = 0;
        var w = Console.WindowWidth;
        foreach (var item in text)
        {
            if (num == 0)
            {
                break;
            }
            if (column % w == 0 && column != 0)
            {
                line++;
                column = 0;
            }
            var keyChar = Console.ReadKey(true).KeyChar;
            if (keyChar == item)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(column, line);
                Console.WriteLine(item);
                result++;
                column++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(column, line);
                Console.WriteLine(item);
                error++;
                column++;
            }
        }
        Final.InputResult(num, result, error);
    }
    private void Timer()
    {
        Console.SetCursorPosition(0, 7);
        Console.WriteLine("Оставшееся время: 1:00");
        do
        {
            if (text.Length == error + result)
            { 
                break;
            }
            num--;
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, 7);
            Console.ResetColor();
            Console.WriteLine("                            ");
            Console.SetCursorPosition(0, 7);
            Console.WriteLine($"Оставшееся время: 0:{num}");
        } while (num != 0);
    }
}
static class Final
{
    public static void InputResult(int num, int result, int error)
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        path = path + "\\test.json";
        int charMinute = num != 0 ? result * (num/60 + 1) : result;
        float charSecond = (float)result / (60 - num);
        Result res = new Result(Program.name, charMinute, charSecond, error);
        if (File.Exists(path))
        {
            try
            {
                string text = File.ReadAllText(path);
                List<Result> list = JsonConvert.DeserializeObject<List<Result>>(text);
                list.Add(res);
                string json = JsonConvert.SerializeObject(list);
                File.WriteAllText(path, json);
            }
            catch
            {
                List<Result> list = new List<Result>() { res };
                string json = JsonConvert.SerializeObject(list);
                File.AppendAllText(path, json);
            }
        }
        else
        {
            List<Result> list = new List<Result>() { res };
            string json = JsonConvert.SerializeObject(list);
            File.AppendAllText(path, json);
        }
        OutputResult(path);
    }
    private static void OutputResult(string path)
    {
        Console.Clear();
        string text = File.ReadAllText(path);
        List<Result> res = JsonConvert.DeserializeObject<List<Result>>(text);
        Console.ResetColor();
        Console.Clear();
        Console.WriteLine("Таблица рекордов\n----------------------");
        res.ForEach(item => { Console.WriteLine($"{item.Name}\t{item.CharMinute} - Символов в минуту\t{item.CharSecond} - Символов в секунду\t{item.Error} - Количество ошибок"); }); 
        ConsoleKeyInfo key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.Enter)
        {
            Program.Main();
        }
    }
}
