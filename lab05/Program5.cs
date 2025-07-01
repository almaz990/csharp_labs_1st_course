using System;
namespace ex6;
class Program
{
    static void Main(string[] args)
    {
        int[] array = { 4, 5, 1, 3, 8, 1, 3, 9, 7, 11 };

        //sorted:       1, 1, 3, 3, 4, 5, 7, 8, 9, 11

        //result:       5, 6, 1, 3, 8, 2, 4, 9, 7, 10

        int[] currArray = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            currArray[i] = array[i];
        }
        Array.Sort(array);
        int[] sortedArray = array;

        
        for (int i = 0; i < GetSortedArray(currArray).Length; i++)
        {
            Console.Write(GetSortedArray(currArray)[i] + " ");
        }
        
        int[] GetSortedArray(int[] currArray)
        {
            int[] result = new int[currArray.Length];

            for (int i = 0; i < currArray.Length; i++)
            {
                result[i] = GetIndex(currArray[i]) + 1;
            }
            for (int i = 0; i < result.Length - 1; i++)
            {
                for (int j = i + 1; j < result.Length; j++)
                {
                    if (result[i] == result[j])
                    {
                        result[j]++;
                    }
                }
            }
            return result;
        }

        int GetIndex(int el)
        {
            int idx = -1;
            for (int i = 0; i < currArray.Length; i++)
            {
                if (sortedArray[i] == el)
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }
    }
}