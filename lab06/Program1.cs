using System;

namespace ex1;

class Program
{
    static void Main(string[] args)
    {
        int n = 10;
        Console.WriteLine(F(n));
    }

    static int F(int x)
    {
        if (x == 0 || x == 1) return x;
        return F(x - 1) + F(x - 2);
    }
}

