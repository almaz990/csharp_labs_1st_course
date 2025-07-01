using System;
namespace ex1;
public class Program
{

    static void Main(string[] args)
    {
        double[] z = { 10.0, 11.2, 10.5, 11.0, 12.2, 10.3, 9.9, 14.2, 13.2 };
        Array.Sort(z);
        for (int i = 0; i < team(z).Length; i++)
        {
            Console.WriteLine(team(z)[i]);
        }
        static double[] team(double[] r)
        {
            double[] res = new double[4];
            for (int i = 0; i < 4; i++)
            {
                res[i] = r[i];
            }
            return res;

        }
    }
}
