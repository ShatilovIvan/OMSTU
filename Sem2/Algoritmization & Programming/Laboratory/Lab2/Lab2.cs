using System;

interface IShape
{
    double GetPerimeter();
    double GetSurface();
}

class Shape
{
    string Name { get; set; }
}

class Circle : Shape, IShape
{
    public double Radius { get; set; }
    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public double GetSurface()
    {
        return Math.PI * Radius * Radius;
    }
}

class Square : Shape, IShape
{
    public double Length { get; set; }

    public double GetPerimeter()
    {
        return 4 * Length;
    }

    public double GetSurface()
    {
        return Length*Length;
    }
}

class Triangle
{
    public double Length { get; set; }

    public double GetPerimeter()
    {
        return 3 * Length;
    }

    public double GetSurface()
    {
        return (Math.Sqrt(3) *  Length * Length) / 4;
    }
}

class Program
{
    static void Main()
    {
        Circle circle = new Circle();
        circle.Radius = 10;
        Console.WriteLine(circle.GetPerimeter());
        Console.WriteLine(circle.GetSurface() + "\n");

        Square square = new Square();
        square.Length = 10;
        Console.WriteLine(square.GetPerimeter());
        Console.WriteLine(square.GetSurface() + "\n");

        Triangle triangle = new Triangle();
        triangle.Length = 10;
        Console.WriteLine(triangle.GetPerimeter());
        Console.WriteLine(triangle.GetSurface());
    }
}
