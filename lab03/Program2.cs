int[] arr = { 4, 6, 2, 9, 5, 7, 3, 8, 1 };
int mxcnt = 1;
for (int i = 0; i < arr.Length - 1; i++)
{
    char c = '-';
    int cnt = 1;
    for (int j = i; j < arr.Length - 1; j++)
    {
        if (c == 'b')
        {
            if (arr[j + 1] < arr[j])
            {
                cnt++;
                c = 'm';
            }
            else
            {
                cnt = 0;
            }
        }
        else if (c == 'm')
        {
            if (arr[j + 1] > arr[j])
            {
                cnt++;
                c = 'b';
            }
            else
            {
                cnt = 0;
            }
        }

        //1.
        if (arr[j + 1] > arr[j] && j == i)
        {
            cnt++;
            c = 'b';
        }
        else if (arr[j + 1] < arr[j] && j == i)
        {
            cnt++;
            c = 'm';
        }
        mxcnt = cnt > mxcnt ? cnt : mxcnt;
    }
}
Console.WriteLine(mxcnt);