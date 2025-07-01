int[] arr = { 10, 2, 5, 6, 7 };

for  (int i = 0; i < arr.Length; i++)
{
    int cntmin = 0, cntmax = 0;
    for (int j = 0; j < arr.Length; j++)
    {
        if (i == j) continue;

        if (arr[j] >= arr[i])
        {
            cntmax++;
        }
        else
        {
            cntmin++;
        }
    }
    if (cntmax - cntmin == 0 || cntmax - cntmin == 1)
    {
        Console.WriteLine(arr[i]);
    }
}