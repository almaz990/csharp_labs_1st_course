// в 1626 году был куплен остров
double res = 24.0;
for (int i = 1626; i <= 2024; i++)
{
    res += res * 0.06;
}
Console.WriteLine(res);