using System;
namespace ex1;
public class Program
{

static void Main(string[] args)
{
    Console.Write("Введите число k: ");
        int k = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Результат {F(k)}");

    }
    static int F(int k)
    {
        if (k == 0) return 0;
        if (k == 1 || k == 2) return 1;
        return F(k - 2) + F(k - 1);
    }
}
