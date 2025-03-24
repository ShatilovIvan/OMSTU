using System;
using System.Diagnostics.Tracing;

class Dot
{
    public double x { get; set; }
    public double y { get; set; }

    public Dot(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
}

delegate void RunOutHandler();

class RunOutEvent
{
    public event RunOutHandler Event;

    public void OnEvent()
    {
        if(Event != null)
            Event();
    }
}

class RunOutEventDemo
{
    public static void Handler()
    {
        Console.WriteLine("Точка вышла за пределы поля!\n");
        Environment.Exit(0);
    }
}

class Program
{
    static void Main()
    {
        Random r = new Random();
        Dot A = new Dot(0, 0);
        Dot B = new Dot(0, 10);
        Dot C = new Dot(10, 10);
        Dot D = new Dot(10, 0); 

        Dot check = new Dot(5, 5);

        RunOutEvent evt = new RunOutEvent();
        evt.Event += RunOutEventDemo.Handler;
        
        for (; ;)
        {
            check.x += r.NextDouble();
            check.y += r.NextDouble();

            if(check.x > 10 || check.x < 0 || check.y > 10 || check.y < 0)
                evt.OnEvent();

            Thread.Sleep(500);
        }
    }
}