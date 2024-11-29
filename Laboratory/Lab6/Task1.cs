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

    static void Main()
    {
        int[,] array = FillArray();

        int[] proizvedenieArr = new int[array.GetLength(0)];

        int rowCount = array.GetLength(0);
        int columnCount = array.GetLength(1);

        for (int i = 0; i < columnCount; i++)
        {
            int proizvedenie = 1;
            for (int j = 0; j < rowCount; j++)
            {
                proizvedenie *= array[j, i];
            }

            proizvedenieArr[i] = proizvedenie;
        }

        for (int i = 0; i < columnCount - 1; i++)
        {
            for (int j = 0; j < columnCount - i - 1; j++)
            {
                if (proizvedenieArr[j] < proizvedenieArr[j + 1])
                {
                    int tempProduct = proizvedenieArr[j];
                    proizvedenieArr[j] = proizvedenieArr[j + 1];
                    proizvedenieArr[j + 1] = tempProduct;

                    for (int k = 0; k < rowCount; k++)
                    {
                        int tempValue = array[k, j];
                        array[k, j] = array[k, j + 1];
                        array[k, j + 1] = tempValue;
                    }
                }
            }
        }

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }

    }
}