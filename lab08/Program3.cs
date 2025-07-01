using System;
using System.IO;

namespace ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C#file4.txt";
            int[] fileNumbers = { 2, -7, 8, -2, 5, -1, -5, 3, 9, -3 };

            // создание файла и запись туда данных
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (var el in fileNumbers)
                {
                    bw.Write(el);
                }
            }

            ////количество элементов
            byte[] bytes = File.ReadAllBytes(path);
            int[] array = new int[bytes.Length / sizeof(int)];

            //считывание элементов из файла
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = br.ReadInt32();
                }
            }

            //упорядочение последовательности
            int cntM = 0;
            int cntP = 0;

            foreach (var el in array)
            {
                if (el >= 0)
                {
                    cntP++;
                }
                else
                {
                    cntM++;
                }
            }

            int[] arrayP = new int[cntP];
            int[] arrayM = new int[cntM];

            cntP = 0;
            cntM = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    arrayP[cntP] = array[i];
                    cntP++;
                }
                else
                {
                    arrayM[cntM] = array[i];
                    cntM++;
                }
            }

            //запись элементов в новый файл
            cntP = 0; cntM = 0;
            string pathResult = @"C#file_res.txt";
            using (BinaryWriter bw = new BinaryWriter(File.Open(pathResult, FileMode.Create)))
            {
                
                while (cntP + cntM < array.Length)
                {
                    bw.Write(arrayP[cntP]);
                    bw.Write(arrayM[cntM]);
                    cntP++; cntM++;
                }

            }

            ////проверка результата
            using (BinaryReader br = new BinaryReader(File.Open(pathResult, FileMode.Open)))
            {
                while ((br.PeekChar() > -1))
                {
                    Console.WriteLine(br.ReadInt32());
                }
            }
        }
    }
}
