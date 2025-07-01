using System.IO;

namespace ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C#file4.txt";
            string text = "1 2 9 0 20 11 8 7 2";

            // создание файла и запись туда текста
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.Write(text);
            }

            // чтение файла и подсчет суммы
            int sum = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (string word in line.Split(' '))
                    {
                        sum += Convert.ToInt32(word);
                    }
                }
            }
            Console.WriteLine($"Сумма чисел = {sum}");
        }
    }
}