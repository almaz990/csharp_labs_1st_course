using System;
namespace ex2;
class Program
{
    static void Main(string[] args)
    {
        int[,] nums = { { 1, 2, 2, 3 }, { 1, -1, 2, 6 }, { 2, 1, -2, 9 } };

        int rows = nums.GetUpperBound(0) + 1;
        int columns = nums.GetUpperBound(1) + 1;
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(nums[i, j] + " ");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns / 2; j++)
            {
                if (j == 0)
                {
                    int cur = nums[i, j];
                    nums[i, j] = nums[i, columns - 1];
                    nums[i, columns - 1] = cur;
                }
                else
                {
                    int cur = nums[i, j];
                    nums[i, j] = nums[i, columns - j - 1];
                    nums[i, columns - j - 1] = cur;
                }
            }
        }
        Console.WriteLine();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(nums[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}