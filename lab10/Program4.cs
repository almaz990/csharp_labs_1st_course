class Program
{
    static void Main()
    {
        string text = "Иванов Иван Иванович # iviviv@mail.ru\nПетров Петр Петрович # petr@mail.ru";
        string path = @"C#file5.txt";

        using (StreamWriter sw = new StreamWriter(File.Open(path, FileMode.Create))) { sw.Write(text); }

        string pathResult = @"C#fileRes.txt";
        using (StreamReader sr = new StreamReader(File.Open(path, FileMode.Open)))
        using (StreamWriter sw = new StreamWriter(File.Open(pathResult, FileMode.Create)))
        {
            string s = sr.ReadLine();
            while (s != null)
            {
                Searcher.SearchMail(ref s);
                sw.WriteLine(s);
                s = sr.ReadLine();
            }

        }
        using (StreamReader sr = new StreamReader(File.Open(pathResult, FileMode.Open))) { Console.WriteLine(sr.ReadToEnd()); }
    }
}
class Searcher
{
    public static void SearchMail(ref string s)
    {
        s = s.Split('#')[1].Trim();
        
    }
}