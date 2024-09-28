using System;

class Task1
{
    static void Main()
    {
        Console.WriteLine("Введите число элементов: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n < 3)
            return;

        int left_number = 0, center_number = 0, right_number = 0, count = 0, buf = 0;

        for (int i = 0; i < n; i++)
        {
            int value = Convert.ToInt32(Console.ReadLine());

            if (i == 0)
            {
                left_number = value;
                continue;
            }

            if (i == 1)
            {
                center_number = value;
                continue;
            }

            if (i == 2)
            {
                right_number = value;
                if (center_number > left_number && center_number > right_number)
                    count++;
                continue;
            }

            left_number = center_number;
            center_number = right_number;
            right_number = value;

            if (center_number > left_number && center_number > right_number)
                count++;
        }

        Console.WriteLine($"Количество локальных максимумов: {count}");
    }
}