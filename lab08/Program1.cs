using System;
using System.IO;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C#file2.txt";
            int[] fileNumbers = { 2, 7, 8, 2, 1, 5, 3, 9, 3 };

            // создание файла и запись туда данных
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (var el in fileNumbers)
                {
                    bw.Write(el);
                }
            }

            //количество элементов
            byte[] bytes = File.ReadAllBytes(path);
            int[] array = new int[bytes.Length / sizeof(int)];

            //нахождение минимального и максимального элемента и получение элементов файла
            int minNumber = 0;
            int maxNumber = 0;
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                int mn = 1000000;
                int mx = 0;
                int i = 0;
                while (br.PeekChar() > -1)
                {
                    int cur = br.ReadInt32();
                    array[i] = cur;
                    mx = cur > mx ? cur : mx;
                    mn = cur < mn ? cur : mn;
                    i++;
                }
                minNumber = mn; maxNumber = mx;
            }

            //смена максимального и минимального элемента
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == minNumber)
                {
                    array[i] = maxNumber;
                }
                else if (array[i] == maxNumber)
                {
                    array[i] = minNumber;
                }
            }

            //перезапись файла
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (var el in array)
                {
                    bw.Write(el);
                }
            }

            //проверка результата
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while ((br.PeekChar() > -1))
                {
                    Console.WriteLine(br.ReadInt32());
                }
            }
        }
    }
}
