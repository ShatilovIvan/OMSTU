using System;

class Task2
{
    static void Main()
    {
        Console.WriteLine("Введите число элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n < 2)
            return;

        int max = int.MinValue, premax = int.MinValue;

        for (int i = 0; i < n; i++)
        {
            int value = Convert.ToInt32(Console.ReadLine());
            if (i == 0)
            {
                max = value;
                continue;
            }

            if (value >= max && max >= premax)
            {
                premax = max;
                max = value;
            }

            if (value < max)
            {
                if (value > premax)
                    premax = value;
            }
        }

        Console.WriteLine($"Наибольшее: {max}, Второе наибольшее: {premax}");
    }
}