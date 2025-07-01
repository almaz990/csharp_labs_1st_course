using System.IO;
namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C#file6.txt";
            string path1 = "result.txt";
            string text = "Иванов Иван Иванович, ГРУППА-101, 5 4 5 3 4\r\nПетрова Анна Сергеевна, ГРУППА-102, 5 5 4 5\r\nСидоров Алексей Петрович, ГРУППА-101, 3 4 3 4 3\r\nКозлова Елена Викторовна, ГРУППА-103, 5 5 5 5";
            // запись текста в файл
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.Write(text);
            }
            //чтение файла
            using (StreamReader sr = new StreamReader(path))
            using (StreamWriter sw = new StreamWriter(path1, false))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    double sum = 0.0;
                    for (int i = 0; i < Convert.ToDouble(line.Split(',')[2].Split(' ').Length); i++)
                    {
                        if (line.Split(',')[2].Split(' ')[i] == "") continue;
                        sum += Convert.ToDouble(line.Split(',')[2].Split(' ')[i]);
                    }
                    double res = sum / Convert.ToDouble(line.Split(',')[2].Split(' ').Length - 1);

                    //запись построчно в итоговый файл
                    string resLine = line.Split(',')[0] + "," + line.Split(',')[1] + ", " + Convert.ToString(res);
                    Console.WriteLine(resLine);
                    line = sr.ReadLine();
                }
            }
            // проверка
            using (StreamReader sr = new StreamReader(path1))
            {
                string? line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}