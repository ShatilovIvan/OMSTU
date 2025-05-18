using System;
using System.Xml.Schema;

class Client
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Client(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

class Trainer
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Trainer(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

class Visit
{
    public int Id { get; set; }
    public int TrainerId { get; set; }
    public int ClientId { get; set; }
    public DateTime VisitDate { get; set; }
    public int DurationMinutes { get; set; }

    public Visit(int trainerId, int clientId, DateTime visitDate, int durationMinutes)
    {
        TrainerId = trainerId;
        ClientId = clientId;
        VisitDate = visitDate;
        DurationMinutes = durationMinutes;
    }
}

class Program
{
    static void Main()
    {
        List<Trainer> trainers = new()
        {
            new Trainer(1, "trainer1"),
            new Trainer(2, "trainer2"),
            new Trainer(3, "trainer3"),
        };

        List<Client> clients = new()
        {
            new Client(1, "client1"),
            new Client(2, "client2"),
            new Client(3, "client3"),
        };

        List<Visit> visits = new()
        {
            new Visit(1, 1, new DateTime(2025, 4, 1), 45),
            new Visit(2, 1, new DateTime(2025, 4, 1), 60),
            new Visit(3, 2, new DateTime(2025, 4, 2), 45),
            new Visit(1, 2, new DateTime(2025, 4, 3), 90),
            new Visit(2, 3, new DateTime(2025, 4, 3), 60),
            new Visit(1, 1, new DateTime(2025, 4, 4), 120),
            new Visit(3, 2, new DateTime(2025, 4, 5), 45),
        };

        //по дате
        var byDate = visits.GroupBy(v => v.VisitDate);

        foreach (var group in byDate)
        {
            Console.WriteLine($"\nДата: {group.Key.ToShortDateString()}");
            foreach (var visit in group)
            {
                var client = clients.First(c => c.Id == visit.ClientId);
                var trainer = trainers.First(t => t.Id == visit.TrainerId);
                Console.WriteLine($"  Клиент: {client.Name}, Тренер: {trainer.Name}, Время: {visit.DurationMinutes} мин");
            }
        }

        //по тренерам
        var byTrainer = visits.GroupBy(v => v.TrainerId);

        foreach (var group in byTrainer)
        {
            var trainer = trainers.First(t => t.Id == group.Key);
            Console.WriteLine($"\nТренер: {trainer.Name}");
            foreach (var visit in group)
            {
                var client = clients.First(c => c.Id == visit.ClientId);
                Console.WriteLine($"  Клиент: {client.Name}, Дата: {visit.VisitDate.ToShortDateString()}, Время: {visit.DurationMinutes} мин");
            }
        }

        //макс время

        var maxClient = visits
           .GroupBy(v => v.ClientId)
           .Select(g => new { ClientId = g.Key, TotalMinutes = g.Sum(v => v.DurationMinutes) })
           .FirstOrDefault();

        if (maxClient != null)
        {
            var client = clients.First(c => c.Id == maxClient.ClientId);
            Console.WriteLine($"Клиент с наибольшим временем: {client.Name}, всего {maxClient.TotalMinutes} минут");
        }
        else
        {
            Console.WriteLine("Нет данных о посещениях.");
        }

        //все посещения клиентов
        
        foreach (var client in clients)
        {
            Console.WriteLine($"\nКлиент: {client.Name}");
            var clientVisits = visits.Where(v => v.ClientId == client.Id);

            foreach (var visit in clientVisits)
            {
                Console.WriteLine($"  Дата посещения: {visit.VisitDate.ToShortDateString()} ({visit.DurationMinutes} мин)");
            }
        }
    }
}