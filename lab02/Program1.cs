Console.WriteLine("Введите число: ");
int n = Convert.ToInt32(Console.ReadLine());
int res = 0;
while (n / 10 > 0 || n % 10 > 0)
{
    res++;
    n /= 10;

}
Console.WriteLine(res);