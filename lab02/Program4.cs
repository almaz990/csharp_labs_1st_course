// A = 30000
// B = 30000

double smA = 30000.0 * 10.0;
double sum = 30000.0;
double res = 30000.0;
for (int i = 1; i < 10; i++)
{
    sum += sum * 0.03;
    res += sum;
}
Console.WriteLine($"{res - smA} потребуется студенту поверх стипендии");