using System;

class Computer
{
    public string Name { get; set; }
    public int Year { get; set; }
    public string System { get; set; }
}
class User
{
    public string Name { get; set;}
    public int Year{ get; set;}
    public bool IsOwner { get; set;}
    public Computer Computer { get; set;}

    public override string ToString()
    {
        string value = "";

        if (IsOwner == false)
        {
            value += $"Имя: {Name}, Год рождения: {Year}, компьютера нет :(";
            return value;
        }

        value += $"Имя: {Name}, Год рождения: {Year}, Марка компьютера: {Computer.Name}, Год компьюьтера: {Computer.Year}, ОС: {Computer.System}";
        return value;
    }

}
class Program
{
    static void ShowNotOwners(List<User> users)
    {
        var owners = users.Where(x => x.IsOwner == false).ToList();
        foreach (var user in owners)
        {
            Console.WriteLine(user.ToString());
        }
    }

    static void ShowOwners(List<User> users)
    {
        var owners = users.Where(x => x.IsOwner == true).ToList();
        foreach (var user in owners)
        {
            Console.WriteLine(user.ToString());
        }
    }

    static void GroupByOS(List<User> users)
    {
        Console.Write("Введите название операционной системы: ");
        string system = Console.ReadLine();
        var owners = users.Where(x => x.IsOwner).Where(x => x.Computer.System == system).ToList();

        if (owners.Count == 0)
        {
            Console.WriteLine("Пользователи не найдены!");
            return;
        }

        foreach (var user in owners)
        {
            Console.WriteLine(user.ToString());
        }
    }

    static void GroupByBrand(List<User> users)
    {
        Console.Write("Введите название марки компьютера: ");
        string brand = Console.ReadLine();
        var owners = users.Where(x => x.IsOwner).Where(x => x.Computer.Name == brand).ToList();

        if (owners.Count == 0)
        {
            Console.WriteLine("Пользователи не найдены!");
            return;
        }

        foreach (var user in owners)
        {
            Console.WriteLine(user.ToString());
        }
    }

    static void CompareCount(List<User> users)
    {
        var owners = users.Where(x => x.IsOwner);
        var notOwners = users.Where(x => !x.IsOwner);

        if (owners.Count() > notOwners.Count())
        {
            Console.WriteLine("Количество человек, владеющих компьютерами, больше, чем количество людей без компьютеров!");
            return;
        }

        if (owners.Count() < notOwners.Count())
        {
            Console.WriteLine("Количество человек без компьютеров, больше, чем количество людей с компьютерами!");
            return;
        }

        if (owners.Count() == notOwners.Count())
        {
            Console.WriteLine("Количество человек, владеющих компьютерами, совпадает с количеством людей без компьютеров!");
            return;
        }
    }
    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Добро пожаловать в меню!\n1. Выдать всех пользователей без компьютера\n2. Выдать всех пользователей с компьютером \n3. Сгруппировать пользователей по наименованию ОС \n4. Сгруппировать пользователей по марке компьютера\n5. Определить каких пользователей больше с точки зрения наличия компьютера\n6. Выход\n\nВведите действие: ");
    }

    static void ReturnToMenu()
    {
        Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
        Console.ReadKey();
        ShowMenu();
    }
    static void Main()
    {
        ShowMenu();
        bool work = true;

        List<User> users = new List<User>();
        users.Add(new User {Name = "Ivan", Year = 2005, IsOwner = true, Computer = new Computer() { Name = "ASUS", Year = 2025, System = "Linux"}});
        users.Add(new User {Name = "Egor", Year = 2006, IsOwner = true, Computer = new Computer() { Name = "Lenovo", Year = 2020, System = "Windows 10"}});
        users.Add(new User {Name = "Vladimir", Year = 2005, IsOwner = false, Computer = null});
        users.Add(new User {Name = "Misha", Year = 2006, IsOwner = false, Computer = null});
        users.Add(new User {Name = "Nikita", Year = 2007, IsOwner = true, Computer = new Computer() { Name = "MSI", Year = 2022, System = "Windows 11"}});

        while (work)
        {
            int action;
            int.TryParse(Console.ReadLine(), out action);

            switch (action)
            {
                case 1:
                    ShowNotOwners(users);
                    ReturnToMenu();
                    break;
                case 2:
                    ShowOwners(users);
                    ReturnToMenu();
                    break;
                case 3:
                    GroupByOS(users);
                    ReturnToMenu();
                    break;
                case 4:
                    GroupByBrand(users);
                    ReturnToMenu();
                    break;
                case 5:
                    CompareCount(users);
                    ReturnToMenu();
                    break;
                case 6:
                    work = false;
                    break;
            }
        }
    }
}