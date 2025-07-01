using System.IO;
namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C#file.txt";
            using (StreamReader reader = new StreamReader(path))
            {

                int countLine = 0;
                while (reader.ReadLine() != null)
                {
                    countLine++;
                }
                Console.WriteLine(countLine);
            }
            
        }
    }
}