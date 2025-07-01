Console.WriteLine("Введите число: ");
int n = Convert.ToInt32(Console.ReadLine());
int res = 1;

while (n > 0)
{
    res *= n;
    n--;
}
Console.WriteLine(res);