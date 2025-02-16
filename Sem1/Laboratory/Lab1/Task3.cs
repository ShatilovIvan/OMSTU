using System;

class Task3
{
    static void Main()
    {
        int l, m, p, n;
        l = 3;
        m = 3;
        p = 5;

        Console.WriteLine("Введите n");
        n = Convert.ToInt32(Console.ReadLine());

        int perimeter = (2 * l + 2 * m) * n;
        int kolodec = 2 * p * n;
        int go = (n-1) * l * n;
        int sum = perimeter + kolodec + go;

        Console.WriteLine($"{sum}");
    }
}