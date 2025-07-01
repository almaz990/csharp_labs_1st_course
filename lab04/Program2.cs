using System;
namespace ex4;
class Program
{
    static void Main(string[] args)
    {
        int[,] nums = {
            { 1, 2, 2, 3, 2 },
            { 1, -1, 2, 6, 1 },
            { 2, 1, -2, 9, 0 },
            { 1, 2, 3, 4 , 2},
            { 2, 3, 4, 5 , 0}
        };

        int rows = nums.GetUpperBound(0) + 1;
        int columns = nums.GetUpperBound(1) + 1;

        int sm = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = i; j < columns; j++)
            {
                sm += nums[i, j];
                break;
            }
        }
        Console.WriteLine($"Сумма главной диагонали {sm}");

        int sm1 = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = columns - i - 1; j > -1; j--)
            {
                sm1 += nums[i, j];
                break;
            }
        }

        Console.WriteLine($"Сумма побочной диагонали {sm1}");
    }
}