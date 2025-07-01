using System;

namespace ex1;

class Program
{
    static void Main(string[] args)
    {
        int n = 4;
        int[] nums = new int[n];
        for (int i = 0; i < n; i++)
        {
            nums[i] = i + 1;
        }
        P(nums, 0);
    }

    static void P(int[] nums, int start)
    {
        if (start == nums.Length)
        {
            Console.WriteLine(string.Join(",", nums));
            return;
        }
        for (int i = start; i < nums.Length; i++)
        {
            Swap(ref nums[start], ref nums[i]);
            P(nums, start + 1);
            Swap(ref nums[start], ref nums[i]);
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}

