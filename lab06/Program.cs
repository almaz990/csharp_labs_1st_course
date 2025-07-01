using System;

namespace ex1;

class Program
{   
    static void Main(string[] args)
    {
        int n = 5;
        Console.WriteLine(F(n));
    }

    static int F(int x)
    {
        if (x == 1) return 1;
        return x * F(x - 1);
    }
}

