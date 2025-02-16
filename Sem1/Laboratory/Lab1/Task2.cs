using System;

class Task2
{
    static void Main()
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Наибольшее: {(a + b + Math.Abs(a - b)) / 2}\nНаименьшее: {(a + b - Math.Abs(a - b)) / 2}");
    }
}