using System;

delegate double Operation(double x, double y);

class Program
{
    static void Main()
    {
        double x = Convert.ToDouble(Console.ReadLine());
        double y = Convert.ToDouble(Console.ReadLine());

        Operation add = (x, y) => x + y;
        Operation subtract = (x, y) => x - y;
        Operation multiply = (x, y) => x * y;
        Operation divide = (x, y) => y == 0 ? double.NaN : x / y;

        Console.WriteLine(add(x,y));
        Console.WriteLine(subtract(x,y));
        Console.WriteLine(multiply(x,y));
        Console.WriteLine(divide(x,y));

        List<string> strings = new List<string>();
        List<string> sorted = new List<string>();
        string input = Console.ReadLine();

        while(input != "")
        {
            strings.Add(input);
            input = Console.ReadLine();
        }

        sorted = strings.Where(x => x.StartsWith('а')).ToList();

        for (int i = 0; i < sorted.Count; i++)
        {
            Console.WriteLine(sorted[i]);
        }
    }
}