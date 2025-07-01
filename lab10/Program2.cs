
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите имя файла: ");
        string fileName  = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(fileName, false))
        {
            sw.Write("abcdefgh");
        }

        if (File.Exists(fileName))
        {
            Console.WriteLine($"Файл {fileName} существует");
            string outFile = "C#file.txt";
            string text;
            using (StreamReader sr = new StreamReader(fileName)) { text = sr.ReadToEnd(); }
            using (StreamWriter sw = new StreamWriter(outFile, false)) { sw.Write(text.ToUpper()); }
            using (StreamReader sr = new StreamReader(outFile)) { Console.WriteLine(sr.ReadToEnd()); }
        }
        else
        {
            Console.WriteLine($"Файл {fileName} не существует");
        }
    }
}