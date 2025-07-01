int[] arr = { 1, 6, 7, 3, -5, -6, 4, 0 };
int mx = arr.Max(), mn = arr.Min();

for (int i = 0; i < arr.Length; i++)
{
    if (arr[i] == mx)
    {
        mx = i;
    }
    else if (arr[i] == mn)
    {
        mn = i;
    }
}

int curr = arr[mn];
arr[mn] = arr[mx];
arr[mx] = curr;

foreach (int i in arr)
{
    Console.Write(i + " ");
}