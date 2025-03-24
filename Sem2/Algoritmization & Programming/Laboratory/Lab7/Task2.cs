using System;

class Cockroach
{
    public string name { get; set; }
    public double position { get; set; }

    public Cockroach(string name, double pos)
    {
        this.name = name;
        position = pos;
    }
}

delegate void FinishHandler(string name);

class FinishEvent
{
    public event FinishHandler Event;

    public void OnEvent(string name)
    {
        if(Event != null)
            Event(name);
    }
}

class FinishEventDemo
{
    public static void Handler(string name)
    {
        Console.WriteLine($"{name} победил!\n");
        Environment.Exit(0);
    }
}

class Program
{
    static void Main()
    {
        FinishEvent evt = new FinishEvent();
        evt.Event += FinishEventDemo.Handler;

        Random r = new Random();
        double finish = 100;

        List<Cockroach> racers = new List<Cockroach>();
        racers.Add(new Cockroach("Таракан 1", 0)); 
        racers.Add(new Cockroach("Таракан 2", 0)); 
        racers.Add(new Cockroach("Таракан 3", 0)); 

        for (; ;)
        {
            foreach(Cockroach cockroach in racers)
            {
                cockroach.position += r.NextDouble();

                if (cockroach.position > finish)
                    evt.OnEvent(cockroach.name);

            }
        }
    }
}