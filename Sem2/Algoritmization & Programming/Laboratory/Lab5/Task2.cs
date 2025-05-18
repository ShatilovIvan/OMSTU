using System;
class Operations
{
    public Operations(double a, double b)
    {
        A = a;
        B = b;
    }
    
    private double A { get; set; }
    private double B { get; set; }
    
    public double Sum() => A + B;
    public double Minus(double sum) => sum - B;
    public double Multiply(double minus) => minus * B;
    
    public double MultiplyTwo() => A * B;
    public double SumTwo(double multi) => multi + B;

    public double Divide(double sum)
    {
        if (B != 0)
        {
            return sum / B;
        }

        return double.NaN;
    }
}
class Program
{
    public delegate double FirstDelegate();
    public delegate double SecondDelegate();

    public static FirstDelegate First;
    public static SecondDelegate Second;
    static void Main(string[] args)
    {
        Operations two = new Operations(6, 0);

        First = two.Sum;
        First += () => two.Minus(two.Sum());
        First += () => two.Multiply(two.Minus(two.Sum()));

        Second = two.MultiplyTwo;
        Second += () => two.SumTwo(two.MultiplyTwo());
        Second += () => two.Divide(two.SumTwo(two.MultiplyTwo()));

        Console.WriteLine($"первый делегат {First.Invoke()}");
        Console.WriteLine($"второй делегат {Second.Invoke()}");
    }
}