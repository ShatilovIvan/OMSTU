using System;

class Phone
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Provider { get; set; }
    public int Year { get; set; }

    public Phone(string name, string phoneNumber, string provider, int year)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Provider = provider;
        Year = year;
    }
}

class Program
{
    static void Main()
    {
        List<Phone> phones =
        [
            new Phone("name1", "number1", "provider1", 2005),
            new Phone("name2", "number2", "provider2", 2004),
            new Phone("name3", "number3", "provider1", 2003),
            new Phone("name4", "number4", "provider1", 2005),
            new Phone("name5", "number5", "provider2", 2004),
            new Phone("name6", "number6", "provider3", 2005),
        ];

        bool work = true;

        while (work)
        {
            Console.WriteLine("\n0 - группировка по году\n1 - группировка по оператору\n2 - выдать телефон по имени\n3 - выход");
            int value = int.Parse(Console.ReadLine());

            switch (value)
            {
                case 0:
                    SortByYear(phones);
                    break;
                case 1:
                    SortByProvider(phones);
                    break;
                case 2:
                    FindByName(phones);
                    break;
                case 3:
                    work = false;
                    break;
            }
        }
    }

    private static void SortByYear(List<Phone> phones)
    {
        var sorted = phones.GroupBy(x => x.Year);

        foreach (var group in sorted)
        {
            Console.WriteLine($"год: {group.Key}");
            foreach (var phone in group)
            {
                Console.WriteLine($"  номер: {phone.PhoneNumber}, имя: {phone.Name}, оператор: {phone.Provider}");
            }
        }
    }

    private static void SortByProvider(List<Phone> phones)
    {
        var sorted = phones.GroupBy(x => x.Provider);

        foreach (var group in sorted)
        {
            Console.WriteLine($"оператор: {group.Key}");
            foreach (var phone in group)
            {
                Console.WriteLine($"  номер: {phone.PhoneNumber}, имя: {phone.Name}, год подключения: {phone.Year}");
            }
        }
    }

    private static void FindByName(List<Phone> phones)
    {
        Console.Write("Введите имя владельца: ");
        string searchName = Console.ReadLine();

        var found = phones.Where(x => x.Name == searchName).ToList();

        if (found.Count == 0)
        {
            Console.WriteLine("Не найдено!");
            return;
        }

        foreach (Phone phone in found)
        {
            Console.WriteLine($"  номер: {phone.PhoneNumber}, имя: {phone.Name}, год подключения: {phone.Year}, оператор: {phone.Provider}");
        }
    }
}
