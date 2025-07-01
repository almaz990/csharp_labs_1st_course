using System;

namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C#file.txt";
            int[] source = { 10, 20, 25, 30, 45, 250 };

            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (var el in source)
                {
                    bw.Write(el);
                }
            }
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                bool flag = true;

                int last = br.ReadInt32();

                while (br.PeekChar() >  -1)
                {
                    int cur = br.ReadInt32();
                    if (cur < last) flag = false;
                    last = cur;
                }

                if (flag)
                {
                    Console.WriteLine("Последовательность возрастающая");
                } else
                {
                    Console.WriteLine("Последовательность невозрастающая");
                }
            }
        }
    }
}