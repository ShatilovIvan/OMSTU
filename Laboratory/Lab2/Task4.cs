using System;

class Task4
{
    static void Main()
    {
        Console.WriteLine("Введите число элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int current = 0, max = 0;

        for (int i = 0; i < n; i++)
        {
            int value = Convert.ToInt32(Console.ReadLine());

            if (Math.Abs(value) % 2 == 0)
            {
                current++;
                
                if (current >= max)
                    max = current;
            }

            else
            {
                if (max <= current)
                {
                    max = current;
                }

                current = 0;
            }
        }

        Console.WriteLine($"Длина наибольшей подпоследовательности четных чисел: {max}");
    }
}