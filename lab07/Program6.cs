using System.IO;
using System.Runtime.Intrinsics.X86;
namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C#file7.txt";
            string text = "Программирование это процесс создания программ\r\nКод пишется разных языках\r\nСинтаксис важен";
            int mn;
            
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(text);
            }
            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                int minLength = 10000;
                while ((line = sr.ReadLine()) != null)
                {
                    for (int i = 0; i < line.Split(' ').Length; i++)
                    {
                        minLength = line.Split(' ')[i].Length < minLength ? line.Split(' ')[i].Length : minLength;
                    }
                }
                mn = minLength;
            }
            using (StreamReader sr = new StreamReader(path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    for (int i = 0; i < line.Split(' ').Length; i++)
                    {
                        if (line.Split(' ')[i].Length == mn)
                        { Console.WriteLine(line.Split(' ')[i]); }
                    }
                }
            }

        }
    }
}