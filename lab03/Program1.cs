int[] arr = { 4, 4, 5, 1, 1, 1, 0, 6, 4, 6, 4, 6, 8, 8, 5, 4, 1, 1, 1, 1 };

int[] narr = new int[arr.Length];
for (int i = 0; i < arr.Length; i++)
{
    int cnt = 1;
    for (int j = 0; j < arr.Length; j++)
    {
        if (j == i) continue;
        if (arr[j] == arr[i]) cnt++;
    }
    narr[i] = cnt;
}
int mx = narr.Max();
for (int i = 0; i  != narr.Length; i++)
{
    if (mx == narr[i])
    {
        mx = i;
        break;
    }
}
Console.WriteLine($"Наиболее часто встречающееся число {arr[mx]}");