int[] arr = { 4, 6, 2, 1, 5, 3, 7, 3 };

int M = 10;
int f = 0, s = 0;
bool fl = false;

for (int i = 0; i < arr.Length; i++)
{
    for (int j = 0; j < arr.Length; j++)
    {
        if (i == j) continue;
        if (arr[i] + arr[j] == M)
        {
            f = arr[i];
            s = arr[j];
            fl = true;
        }
    }
    if (fl) break;
}

Console.WriteLine(f);
Console.WriteLine(s);