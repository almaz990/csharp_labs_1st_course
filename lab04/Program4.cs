using System;
namespace ex5;

class Program
{
    static void Main(string[] args)
    {
        int[,] nums = new int[5, 5];
        int rows = 5, columns = 5;
        int cnt = 0, top = 0, right = columns - 1, bottom = rows - 1, left = 0;

        while (true)
        {
            
            for (int i = top; i <= right; i++)
            {
                cnt++;
                nums[top, i] = cnt;
                
            }
            if (cnt == rows * columns) break;
            top++;

            for (int i = top; i <= bottom; i++)
            {
                cnt++;
                nums[i, right] = cnt;
            }
            if (cnt == rows * columns) break;
            right--;

            for (int i = right; i >= left; i--)
            {
                cnt++;
                
                nums[bottom, i] = cnt;
            }
            if (cnt == rows * columns) break;
            bottom--;

            for (int i = bottom; i >= top; i--)
            {
                cnt++;
                
                nums[i, left] = cnt;
            }
            if (cnt == rows * columns) break;
            left++;
            
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