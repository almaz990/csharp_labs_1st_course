using System;
namespace ex1;
class Program
{
    static void Main(string[] args)
    {
        int[,] nums = { { 1, 2, 2 }, { 1, -1, 2 }, { 2, 1, -2 } };

        int rows = nums.GetUpperBound(0) + 1;
        int columns = nums.GetUpperBound(1) + 1;

        int mx = 0;
        foreach(int i in nums)
        {
            mx = i > mx ? i : mx;
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (nums[i, j] == mx)
                {
                    nums[i, j] = 0;
                }
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