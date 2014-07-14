using System;
using System.Diagnostics;
using System.Linq;

internal class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array cannot be null!");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        for (int index = 0; index < arr.Length - 1; index++)
        {
            Debug.Assert(arr[index].CompareTo(arr[index + 1]) <= 0, "The array is not sorted!");
        }
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array cannot be null");
        Debug.Assert(value != null, "Searched value cannot be null!");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            Debug.Assert(arr[index].CompareTo(arr[index + 1]) <= 0, "The array is not sorted!");
        }

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
    
    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
       where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array cannot null!");
        Debug.Assert(startIndex >= 0 && startIndex <= endIndex, "Start index should be between 0 and length of the array - 1!");
        Debug.Assert(endIndex >= 0 && endIndex <= arr.Length - 1, "End index should be between 0 and length of the array - 1!");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;

            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array cannot be null!");
        Debug.Assert(startIndex >= 0 && startIndex <= endIndex, "Start index should be between 0 and length of the array - 1!");
        Debug.Assert(endIndex >= 0 && endIndex <= arr.Length - 1, "End index should be between 0 and length of the array - 1!");

        int minElementIndex = startIndex;

        for (int index = startIndex + 1; index <= endIndex; index++)
        {
            if (arr[index].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = index;
            }
        }

        for (int index = startIndex + 1; index < endIndex; index++)
        {
            Debug.Assert(
                arr[minElementIndex].CompareTo(arr[index]) <= 0, 
                string.Format("The element at index {0} => {1} is not the smallest", minElementIndex, arr[minElementIndex]));
        }

        return minElementIndex;
    }
}
