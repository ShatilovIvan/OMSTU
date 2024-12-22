using System;

class Zombie
{
    public string Name { get; set; }
    public int Year { get; set; }
    public Zombie(string name, int year)
    {
        Year = year;
        Name = name;
    }
}

class ZombieFarmer : Zombie
{
    public string[] Gun { get; set; }

    public ZombieFarmer(string name, int year, string[] gun) : base(name, year)
    {
        Gun = gun;
    }
    public override string ToString()
    {
        string guns = string.Join(", ", Gun);

        return $"Имя: {Name}, год рождения: {Year}, виды оружия: {guns}";
    }
}

class ZombieDriver : Zombie
{
    public string[] Cars { get; set; }

    public ZombieDriver(string name, int year, string[] cars) : base(name, year)
    {
        Cars = cars;
    }

    public override string ToString()
    {
        string cars = string.Join(", ", Cars);

        return $"Имя: {Name}, год рождения: {Year}, виды транспорта: {cars}";
    }
}

class Program
{
    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Добро пожаловать в меню!\n1. Добавить зомби-колдуна\n2. Добавить зомби-водителя\n3. Выборка по году рождения\n4. Вывод всех зомби-колдунов\n5. Вывод всех зомби-водителей\n6. Выход\n\nВведите действие: ");
    }

    static void ReturnToMenu()
    {
        Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
        Console.ReadKey();
        ShowMenu();
    }

    static void AddZombieDriver(ref ZombieDriver[] zombieDrivers, ref int zombieDriversCount)
    {
        if (zombieDriversCount >= zombieDrivers.Length)
        {
            Console.WriteLine("Переполнение базы данных");
            return;
        }

        Console.Write("Введите ФИО: ");
        string name = Console.ReadLine();
        Console.Write("Введите год рождения: ");
        int year = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество транспорта: ");
        int n = Convert.ToInt32(Console.ReadLine());
        string[] cars = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите вид транспорта {i + 1}: ");
            cars[i] = Console.ReadLine();
        }

        zombieDrivers[zombieDriversCount] = new ZombieDriver(name, year, cars);
        zombieDriversCount++;

        Console.WriteLine("Зомби-водитель успешно добавлен!");
    }

    static void AddZombieFarmer(ref ZombieFarmer[] zombieFarmers, ref int zombieFarmersCount)
    {
        if (zombieFarmersCount >= zombieFarmers.Length)
        {
            Console.WriteLine("Переполнение базы данных");
            return;
        }

        Console.Write("Введите ФИО: ");
        string name = Console.ReadLine();
        Console.Write("Введите год рождения: ");
        int year = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество оружия: ");
        int n = Convert.ToInt32(Console.ReadLine());
        string[] guns = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите вид оружия {i + 1}: ");
            guns[i] = Console.ReadLine();
        }

        zombieFarmers[zombieFarmersCount] = new ZombieFarmer(name, year, guns);
        zombieFarmersCount++;

        Console.WriteLine("Зомби-колдун успешно добавлен!");
    }

    static void ShowAllFarmers(ZombieFarmer[] zombieFarmers, int zombieFarmersCount)
    {
        if (zombieFarmersCount == 0)
        {
            Console.WriteLine("База данных пуста");
            return;
        } 

        for (int i = 0; i < zombieFarmersCount; i++)
        {
            Console.WriteLine(zombieFarmers[i].ToString());
        }
        Console.WriteLine("Выборка закончена.");
    }

    static void ShowAllDrivers(ZombieDriver[] zombieDrivers, int zombieDriversCount)
    {
        if (zombieDriversCount == 0)
        {
            Console.WriteLine("База данных пуста");
            return;
        }

        for (int i = 0; i < zombieDriversCount; i++)
        {
            Console.WriteLine(zombieDrivers[i].ToString());
        }
        Console.WriteLine("Выборка закончена.");
    }

    static void QueryByYear(ZombieDriver[] zombieDrivers, int zombieDriversCount, ZombieFarmer[] zombieFarmers, int zombieFarmersCount)
    {
        Console.Write("Введите год рождения, по которому требуется осуществить выборку: ");
        int year = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < zombieDriversCount; i++)
        {
            if (zombieDrivers[i].Year == year)
            {
                Console.WriteLine(zombieDrivers[i].ToString());
            }
        }

        for (int i = 0; i < zombieFarmersCount; i++)
        {
            if (zombieFarmers[i].Year == year)
            {
                Console.WriteLine(zombieFarmers[i].ToString());
            }
        }

        Console.WriteLine("Выборка закончена.");
    }

    static void Main()
    {
        const int maxZombieDriversCount = 50;
        const int maxZombieFarmersCount = 50;
        ZombieDriver[] zombieDrivers = new ZombieDriver[maxZombieDriversCount];
        ZombieFarmer[] zombieFarmers = new ZombieFarmer[maxZombieFarmersCount];

        int zombieDriversCount = 0;
        int zombieFarmersCount = 0;

        ShowMenu();

        bool work = true;

        while (work)
        {
            int action = Convert.ToInt32(Console.ReadLine());

            switch (action)
            {
                case 1:
                    AddZombieFarmer(ref zombieFarmers, ref zombieFarmersCount);
                    ReturnToMenu();
                    break;
                case 2:
                    AddZombieDriver(ref zombieDrivers, ref zombieDriversCount);
                    ReturnToMenu();
                    break;
                case 3:
                    QueryByYear(zombieDrivers, zombieDriversCount, zombieFarmers, zombieFarmersCount);
                    ReturnToMenu();
                    break;
                case 4:
                    ShowAllFarmers(zombieFarmers, zombieFarmersCount);
                    ReturnToMenu();
                    break;
                case 5:
                    ShowAllDrivers(zombieDrivers, zombieDriversCount);
                    ReturnToMenu();
                    break;
                case 6:
                    work = false;
                    break;
            }
        }
    }
}