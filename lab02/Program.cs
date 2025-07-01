
Console.WriteLine("Введите x:");
int x = Convert.ToInt32(Console.ReadLine());
int res = 100;
if (x < 0)
{
    res = -1;
}
else if (x > 0)
{
    res = 1;
}
else
{
    res = 0;
}
Console.WriteLine($"Результат: {res}");