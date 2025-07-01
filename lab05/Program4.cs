using System;
namespace ex5;
class Program
{
    static void Main(string[] args)
    {
        string e = "x^3-6x^2+11x-6";
        int a0 = Int32.Parse(e.Substring(e.LastIndexOf('-')));

        GetRoots(a0);

        void GetRoots(int a0)
        {
            if (a0 > 0)
            {
                for (int i = 1; i < a0 + 1; i++)
                {
                    if (IsDivisor(i) && (i * i * i - 6 * i * i + 11 * i - 6) == 0)
                    {
                        Console.WriteLine($"{i} является корнем {e}");
                    }
                }
            }
            else
            {
                for (int i = a0; i < Math.Abs(a0) + 1; i++)
                {

                    if (i != 0 && IsDivisor(i) && (i * i * i - 6 * i * i + 11 * i - 6) == 0)
                    {
                        Console.WriteLine($"{i} является корнем {e}");
                    }
                }
            }

            bool IsDivisor(int d)
            {
                return Math.Abs(a0) % d == 0;
                
            }


        }


    }
}