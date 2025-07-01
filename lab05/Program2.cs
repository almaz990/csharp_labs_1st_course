using System;
namespace ex3;
class Program
{
    static void Main(string[] args)
    {
        int[] n2 = { 1, 5, 2, 9 };
        int[] n1 = { 1, 5, 6, 1, 2, 9, 7 };
        if (IsIncluded(n1, n2)) Console.WriteLine($"n1 содержит n2");
        else Console.WriteLine($"n1 не содержит n2");

    }

    static bool IsIncluded(int[] n1, int[] n2)
    {
        bool f = true;
        if (n1.Length >= n2.Length)
        {
            for (int i = 0; i < n2.Length; i++)
            {
                int c = 0;
                for (int j = 0; j < n1.Length; j++)
                {
                    if (n2[i] == n1[j])
                    { 
                        c++;
                    }
                }
                if (c == 0)
                {
                    f = false;
                }
            }
        }
        return f;
    }
}