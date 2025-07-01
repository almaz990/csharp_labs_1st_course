using System;

namespace ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathFirst = @"C#file3_1.txt";
            string pathSecond = @"C#file3_2.txt";

            int[] arrayFirst = { 1, 2, 5, 9 };
            int[] arraySecond = { 3, 4, 10 };

            //запись элементов в файлы
            using (BinaryWriter bw = new BinaryWriter(File.Open(pathFirst, FileMode.Create)))
            {
                foreach (int el in arrayFirst)
                {
                    bw.Write(el);
                }
            }
            using (BinaryWriter bw = new BinaryWriter(File.Open(pathSecond, FileMode.Create)))
            {
                foreach (int el in arraySecond)
                {
                    bw.Write(el);
                }
            }

            //считывание количества элементов двух файлов
            byte[] bytesF = File.ReadAllBytes(pathFirst);
            byte[] bytesS = File.ReadAllBytes(pathSecond);

            int[] val = new int[bytesF.Length / sizeof(int) + bytesS.Length / sizeof(int)];

            // считывание всех элементов в массив
            using (BinaryReader br1 = new BinaryReader(File.Open(pathFirst, FileMode.Open)))
            using (BinaryReader br2 = new BinaryReader(File.Open(pathSecond, FileMode.Open)))
            {
                int i = 0;
                for (; i < bytesF.Length / sizeof(int); i++)
                {
                    val[i] = br1.ReadInt32();
                }
                for (int j = 0; j < bytesS.Length / sizeof(int); i++, j++)
                {
                    val[i] = br2.ReadInt32();
                }

            }

            // сортировка
            Array.Sort(val);

            //запись в итоговый файл
            string pathResult = @"C#file.txt";
            using (BinaryWriter bw = new BinaryWriter(File.Open(pathResult, FileMode.Create)))
            {
                foreach(int el in val)
                {
                    bw.Write(el);
                }
            }
            //проверка
            using (BinaryReader br = new BinaryReader(File.Open(pathResult, FileMode.Open)))
            {

                while (br.PeekChar() > -1)
                {
                    Console.WriteLine(br.ReadInt32());

                }
            }
        }
    }
}