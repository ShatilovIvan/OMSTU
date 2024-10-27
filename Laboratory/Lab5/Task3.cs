using System;

class Task3
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
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j]}\t");
            }

            Console.WriteLine();
        }
    }

    static void Main()
    {
        int[,] arr = FillArray();
        int minValue;
        int maxValue = int.MinValue;
        int minValueRow = int.MinValue;
        int minValueColumn = int.MinValue;
        int maxValueRow = int.MinValue;
        int maxValueColumn = int.MinValue;
        int seddlePoint = int.MinValue;

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            minValue = arr[i, 0];
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] <= minValue)
                {
                    minValue = arr[i, j];
                    minValueRow = i;
                    minValueColumn = j;
                }
            }

            for (int j = 0; j < arr.GetLength(0); j++)
            {
                if (arr[j, minValueColumn] >= maxValue)
                {
                    maxValue = arr[j, minValueColumn];
                    maxValueRow = j;
                    maxValueColumn = minValueColumn;
                }
            }

            if (minValue == maxValue)
            {
                seddlePoint = minValue;
                Console.WriteLine($"Точка минимакса (минимальный элемент строки и максимальный элемент столбца) = {seddlePoint}, и находится по индексу ({minValueRow}, {minValueColumn}) ");
            }
        }

        if (seddlePoint == int.MinValue)
        {
            Console.WriteLine($"В матрице отстуствует точка минимакса");
        }
    }
}