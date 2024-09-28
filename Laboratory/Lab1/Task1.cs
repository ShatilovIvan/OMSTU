using System;
class Task1
{
    static void Main()
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine()); 

        Console.WriteLine($"{a}, {b}");

        a = a + b;
        b = a - b;
        a = a - b;

        Console.WriteLine($"{a}, {b}");
    }
}