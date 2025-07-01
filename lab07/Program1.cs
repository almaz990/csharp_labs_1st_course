using System.IO;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C#file2.txt";
            string text = "one two three\r\n1 2 3\r\nfour five six\r\n4 5 6\r\nseven eight nine\r\n7 8 9\r\nten 10";


            Console.WriteLine("Введите слово которое хотите найти: ");
            string? target = Console.ReadLine();

            // создание файла и запись туда текста
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.Write(text);
            }

            // чтение файла и проверка на существование слова
            bool f = false;
            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (string word in line.Split(' '))
                    {
                        if (word == target)
                        { f = true; break; }
                    }
                }
            }

            if (f)
            {
                Console.WriteLine($"Слово {target} есть в тексте");
            }
            else
            {
                Console.WriteLine($"Слово {target} не находится в тексте");
            }
        }
    }
}