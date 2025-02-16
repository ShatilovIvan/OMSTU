using System;

class Task2
{
    static int[] SortRow(int[] row)
    {
        for (int i = 0; i < row.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < row.Length; j++)
            {
                if (row[j] < row[min])
                {
                    min = j;
                }
            }
            int temp = row[min];
            row[min] = row[i];
            row[i] = temp;
        }

        return row;
    }
    static bool CompareRows(ref int[,] arr, int firstRow, int secondRow)
    {
        int[] firstRowArray = new int[arr.GetLength(1)];
        int[] secondRowArray = new int[arr.GetLength(1)];

        for (int i = 0; i < arr.GetLength(1); i++)
        {
            firstRowArray[i] = arr[firstRow, i];
        }

        for (int i = 0; i < arr.GetLength(1); i++)
        {
            secondRowArray[i] = arr[secondRow, i];
        }

        firstRowArray = SortRow(firstRowArray);
        secondRowArray = SortRow(secondRowArray);

        for (int i = 0; i < arr.GetLength(1); i++)
        {
            if (firstRowArray[i] != secondRowArray[i])
                return false;
        }

        return true;
    }
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

    static void Main()
    {
        int[,] arr = FillArray();

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0;j < arr.GetLength(0); j++)
            {
                if (i == j)
                    continue;

                if (CompareRows(ref arr, i, j) == true)
                {
                    Console.WriteLine($"Строчка {i + 1} эквивалентна строчке {j + 1}!");
                }
            }
        }
    }
}