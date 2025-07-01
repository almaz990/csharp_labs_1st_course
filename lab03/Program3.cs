int[] arr = { 1, 2, 3, 3, 3, 4, 3, 5 };

int[] array = new int[arr.Length];


for (int i = 0; i < arr.Length; i++)
{
    if (i == 1) array[i] = arr[i];

    else
    {
        if (Array.IndexOf(array, arr[i]) == -1)
        {
            array[i] = arr[i];
        }
        else
        {
            continue;
        }
    }
}

foreach (int i in array)
{
    Console.Write(i);
    Console.Write(" ");
}