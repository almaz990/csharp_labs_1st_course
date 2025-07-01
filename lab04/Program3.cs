using System;
namespace ex3;
class Program
{
    static void Main(string[] args)
    {
        int[,] nums = {
            { 5, 2, 2, 3, 2 },
            { 4, 1, 2, 6, 1 },
            { 3, 1, -2, 9, 2 },
            { 2, 2, 3, 4 , 2},
            { 2, 3, 4, 5 , 1}
        };

        int rows = nums.GetUpperBound(0) + 1;
        int columns = nums.GetUpperBound(1) + 1;

    
        for (int i = 0; i < rows; i++)
        {

            for (int j = 0; j < columns - 1; j++)
            {
                bool f = false;
                for (int l = j + 1; l < columns; l++)
                {
                    if (nums[i, j] == nums[i, l])
                    {
                        nums[i, 0] = 1;
                        f = true;
                        break;

                    }
                }
                if (f) break;
                else nums[i, 0] = 0;
            }
        }

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