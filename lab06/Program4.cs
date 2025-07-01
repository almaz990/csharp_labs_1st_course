using System;

namespace ex1;

class Program
{
    static void Main(string[] args)
    {
        int n = 4;
        Tower(n, 'a', 'c', 'b');
    }
        

    static void Tower(int n, char s, char t, char a)
    {
        
        if (n == 1)
        {
            Console.WriteLine($"1 от {s} на {t}");
            return;
        }
        Tower(n - 1, s, a, t);
        Console.WriteLine($"{n} от {s} на {t}");
        Tower(n - 1, a, t, s);
    }
}