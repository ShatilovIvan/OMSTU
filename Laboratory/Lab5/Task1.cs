using System;
class Task1
{
    static int[,] FillArray()
    {
        Console.WriteLine("Введите кол-во строк m :");
        int m = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите кол-во столбцов n :");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] arr = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                arr[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.WriteLine("Массив заполнен!");

        return arr;
    }

    static void ArrayToConsole(int[,] arr)
    {
        for (int i = 0;i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j]}\t");
            }

            Console.WriteLine();
        }
    }

    static void SwapRows(ref int[,] arr, int firstIndex, int secondIndex)
    {
        if (firstIndex == secondIndex)
            return;

        int[] firstElements = new int[arr.GetLength(0)];
        int[] secondElements = new int[arr.GetLength(0)];

        for (int i = 0; i < arr.GetLength(0); i++) 
        {
            firstElements[i] = arr[firstIndex, i];
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            secondElements[i] = arr[secondIndex, i];
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            arr[firstIndex, i] = secondElements[i];
        }

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            arr[secondIndex, i] = firstElements[i];
        }
    }

    static void SwapColumns(ref int[,] arr, int firstIndex, int secondIndex)
    {
        if (firstIndex == secondIndex)
            return;

        int[] firstElements = new int[arr.GetLength(1)];
        int[] secondElements = new int[arr.GetLength(1)];

        for (int i = 0; i < arr.GetLength(1); i++)
        {
            firstElements[i] = arr[i, firstIndex];
        }

        for (int i = 0; i < arr.GetLength(1); i++)
        {
            secondElements[i] = arr[i, secondIndex];
        }

        for (int i = 0; i < arr.GetLength(1); i++)
        {
            arr[i, firstIndex] = secondElements[i];
        }

        for (int i = 0; i < arr.GetLength(1); i++)
        {
            arr[i, secondIndex] = firstElements[i];
        }
    }
    static void Main()
    {
        int[,] arr = FillArray();
        ArrayToConsole(arr);


        int maxValue = int.MinValue;
        int maxValueRow = 0;
        int maxValueColumn = 0;

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0;j < arr.GetLength(1); j++)
            {
                if (maxValue <= arr[i, j])
                {
                    maxValueRow = i; maxValueColumn = j;
                    maxValue = arr[i, j];
                }
            }
        }

        SwapRows(ref arr, maxValueRow, 0);
        SwapColumns(ref arr, maxValueColumn, arr.GetLength(1) - 1);

        Console.WriteLine("");
        ArrayToConsole(arr);

    }
}