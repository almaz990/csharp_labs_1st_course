using System.IO;

namespace ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C#file3.txt";
            string text = "one two three\r\n1 2 3\r\nfour five six\r\n4 5 6\r\nseven eight nine\r\n7 8 9\r\nten 10";

            // создание файла и запись туда текста
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.Write(text);
            }

            // чтение файла и подсчет слов
            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                int countWords = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (string word in line.Split(' '))
                    {
                        countWords++;
                    }
                }
                Console.WriteLine($"В тексте {countWords} слов");
            }
            
        }
    }
}