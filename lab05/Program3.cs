using System;
namespace ex3;
class Program
{
    static void Main(string[] args)
    {
        int[,] n1 = {
            { 1, 2, 3 },
            { 4, 5, 6}
        };
        int[,] n2 = {
            { 7, 8 },
            { 9, 10 },
            { 11, 12 },
        };
        //Multiplication(n1, n2);
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write(Multiplication(n1, n2)[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static int[,] Multiplication(int[,] n1, int[,] n2)
    {
        int rows1 = n1.GetUpperBound(0) + 1;
        int columns1 = n1.GetUpperBound(1) + 1;

        int rows2 = n2.GetUpperBound(0) + 1;
        int columns2 = n2.GetUpperBound(1) + 1;

        int[,] res = new int[rows2, columns1];


        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < columns2; j++)
            {
                for (int k = 0; k < rows2; k++)
                {
                    res[i, j] += n1[i, k] * n2[k, j];
                }
            }
        }

        return res;
    }
}