using System;

class Task2
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
    static void Main()
    {
        int[,] array = FillArray();
        int[] maxArray = new int[array.GetLength(0)];

        int max = array[0,0];

        for (int i =0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] > max)
                {
                    max = array[i, j];
                }
            }

            maxArray[i] = max;
            max = array[i, 0];
        }

        for (int i = 0; i < maxArray.Length; i++)
        {
            Console.Write($"{maxArray[i]} ");
        }

    }
}