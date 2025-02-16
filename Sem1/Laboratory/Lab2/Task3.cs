using System;

class Task3
{
    static void Main()
    {
        Console.WriteLine("Введите число элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            int value = Convert.ToInt32(Console.ReadLine());
            
            if (Math.Abs(value) % 10 == 4)
                count++;
        }

        Console.WriteLine($"Количество чисел, окончивающихся на 4: {count}");
    }
}