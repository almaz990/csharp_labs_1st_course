using System.IO;

namespace ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C#file5.txt";
            string firstM = "2 3\n1 2 3\n4 5 6\n";
            string secondM = "3 2\n7 8\n9 10\n11 12";
            // result = 58 64
            //          139 154

            // создание файла и запись туда текста
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.Write(firstM);
                sw.Write(secondM);
            }
            // чтение файла
            int[,] res;
            using (StreamReader sr = new StreamReader(path))
            {
                string? line = sr.ReadLine();
                //строки и столбцы 1 матрицы
                int rows1 = Convert.ToInt32(line.Split(' ')[0]);
                int columns1 = Convert.ToInt32(line.Split(' ')[1]);
                // запись 1 матрицы в массив
                int[,] first = new int[rows1, columns1];
                for (int i = 0; i < rows1; i++)
                {
                    line = sr.ReadLine();
                    for (int j = 0; j < columns1; j++)
                    {
                        first[i, j] = Convert.ToInt32(line.Split(' ')[j]);
                    }
                }

                //строки и столбцы 2 матрицы
                line = sr.ReadLine();
                int rows2 = Convert.ToInt32(line.Split(' ')[0]);
                int columns2 = Convert.ToInt32(line.Split(' ')[1]);
                // запись 2 матрицы в массив
                int[,] second = new int[rows2, columns2];
                for (int i = 0; i < rows2; i++)
                {
                    line = sr.ReadLine();
                    
                    for (int j = 0; j < columns2; j++)
                    {
                        second[i, j] = Convert.ToInt32(line.Split(' ')[j]);
                    }
                }
                // перемножение двух матриц
                int[,] result = new int[rows1, columns2];
                for (int i = 0; i < rows1; i++)
                {
                    for (int j = 0; j < columns2; j++)
                    {
                        for (int k = 0; k < rows2; k++)
                        {
                            result[i, j] += first[i, k] * second[k, j];
                        }
                    }
                }
                // запись результата
                res = result;

            }
            //запись в новый файл
            string path1 = "result.txt";
            using (StreamWriter sw = new StreamWriter(path1, false))
            {
                // запись размеров
                string line = Convert.ToString(res.GetLength(0)) + " " + Convert.ToString(res.GetLength(1));
                sw.WriteLine(line);
                // запись данных матрицы
                for (int i = 0; i < res.GetLength(0); i++)
                {
                    line = "";
                    for (int j = 0; j < res.GetLength(1); j++)
                    {
                        line = line + Convert.ToString(res[i, j]) + " ";
                    }
                    sw.WriteLine(line);
                }
            }
            // проверка 
            using (StreamReader sr = new StreamReader(path1))
            {
                string? line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
            }
        }
    }
}
