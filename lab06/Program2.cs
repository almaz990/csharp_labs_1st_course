using System;

namespace ex1;

class Program
{
    static void Main(string[] args)
    {
        int n = 7;
        int k = 2;
        Console.WriteLine(C(n, k));
    }

    static int C(int n, int k)
    {
        if (k == 0 || k == n) { return 1; }
        if (k != 1) { return C(n - 1, k - 1) + C(n - 1, k); }
        return n;
    }
}

