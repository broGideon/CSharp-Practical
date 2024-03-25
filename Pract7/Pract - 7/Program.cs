using Pract___7;
using System.Diagnostics;
using System.Net;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Provodnik.drive();
    }
}
static class Provodnik
{
    static public void drive()
    {
        int position;
        do
        {
            Console.Clear();
            Console.SetCursorPosition(56, 0);
            Console.WriteLine("Диски");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("_________________________________________________________________________________________________________________________");
            Console.SetCursorPosition(65,4);
            Console.WriteLine("Для выхода из программы нажмите ESC");
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            Console.SetCursorPosition(0, 2);
            foreach (var item in allDrives)
            {
                Console.WriteLine($"  {item} - {item.TotalSize / 1024 / 1024 / 1024 - item.AvailableFreeSpace /1024 /1024/1024} Гб занято из {item.TotalSize / 1024 / 1024 / 1024} Гб");
            }
            position = Strelochki.menuDrive(2, allDrives.Length + 1);
            if (position != -1)
            {
                string path = allDrives[position - 2].Name;
                ShowPapka(path);
            }
        } while (position != -1);
        return;
    }
    static private void ShowPapka(string papka)
    {
        do
        {
            try
            {
                Console.Clear();
                Console.SetCursorPosition(56,0);
                Console.WriteLine("Папки");
                Console.SetCursorPosition(0,1);
                Console.WriteLine("_________________________________________________________________________________________________________________________");
                Console.SetCursorPosition(5,2);
                Console.WriteLine("Название");
                Console.SetCursorPosition(53,2);
                Console.WriteLine("Дата создания");
                Console.SetCursorPosition(93,5);
                Console.WriteLine("F1 - Создать папку");
                Console.SetCursorPosition(93, 6);
                Console.WriteLine("F2 - Удалить папку");
                Console.SetCursorPosition(93, 7);
                Console.WriteLine("F3 - Создать файл");
                Console.SetCursorPosition(93, 8);
                Console.WriteLine("F4 - Удалить файл");
                int position = 3;
                string[] path = Directory.GetDirectories(papka);
                string[] filePath = Directory.GetFiles(papka);
                var allFile = path.Concat(filePath).Distinct().ToArray();

                foreach (string item in allFile)
                {
                    Console.SetCursorPosition(2, position);
                    foreach (char item2 in item.Substring(item.LastIndexOf('\\')))
                    {
                        if (item2 != '\\')
                        {
                            Console.Write(item2);
                        }
                    }
                    Console.SetCursorPosition(50, position);
                    Console.WriteLine($"{File.GetCreationTime(item).ToString()}\t\t\t|");
                    position++;
                }
                Console.WriteLine("_________________________________________________________________________________________");
                position = Strelochki.menuDirectory(3, allFile.Length + 2, papka);
                if (position == -1)
                {
                    return;
                }
                else if (position == -2 )
                {
                    ShowPapka(papka);
                }
                FileAttributes attr = File.GetAttributes(allFile[position - 3]);
                if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                {
                    openFile(allFile[position - 3]);
                    ShowPapka(papka);
                }
                ShowPapka(path[position - 3]);
            }
            catch
            {
                return;
            }
        } while (true);
    }
    static private void openFile(string path)
    {
        Process.Start(new ProcessStartInfo {FileName = path, UseShellExecute = true });
        return;
    }
}
