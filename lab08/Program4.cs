using System;
using System.IO;

namespace ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C#file5.txt";
            int[] fileNumbers = { 2, 7, 1, 2, 1, 7, 2, 9, 3 };

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

            //получение элементов в массив
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = br.ReadInt32();
                }
            }

            // исключение повторяющихся элементов            
            int len = 0;
            for (int i = 0; i != array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (i == j) continue;
                    if (array[i] == array[j])
                    {
                        array[j] = -1;
                    }
                }
                if (array[i] != -1)
                {
                    len++;
                }
            }

            //запись элементов в новый массив без повторяющихся
            int[] resultArray = new int[len];
            len = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != -1)
                {
                    resultArray[len] = array[i];
                    len++;
                    
                }
            }

            //перезапись файла
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                foreach (var el in resultArray)
                {
                    bw.Write(el);
                }
            }

            //проверка результата
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (br.PeekChar() > -1)
                {
                    Console.WriteLine(br.ReadInt32());
                }
            }
        }
    }
}
