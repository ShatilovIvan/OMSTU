using System;

class Numbers
{
    public string Provider { get; set; }
    public int Year { get; set; }
    public string Number { get; set; }

    public Numbers(string provider, int year, string number)
    {
        Provider = provider;
        Year = year;
        Number = number;
    }
}
class Abonent
{
    public List<Numbers> Number { get; set; }
    public string Name { get; set; }
    public string City { get; set; }

    public override string ToString()
    {
        string numbersInfo = "";

        for (int i = 0; i < Number.Count; i++)
        {
            numbersInfo += $"оператор связи[{i+1}]: {Number[i].Provider}, год подключения[{i + 1}]: {Number[i].Year}, номер[{i + 1}]: {Number[i].Number}\n";
        }

        string abonentInfo;

        if (numbersInfo == "")
            abonentInfo = $"Имя: {Name}, город: {City}, номеров нет";
        else
            abonentInfo = $"Имя: {Name}, город: {City}, {numbersInfo}";

        return abonentInfo;
    }
}

class Program
{
    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Добро пожаловать в меню!\n1. Добавить абонента в базу\n2. Поиск абонента по городу \n3. Поиск абонента по номеру телефона \n4. Поиск абонента по оператору связи \n5. Поиск абонента по году подключения\n6. Выход\n\nВведите действие: ");
    }

    static void ReturnToMenu()
    {
        Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
        Console.ReadKey();
        ShowMenu();
    }

    static void FindByCity(List<Abonent> abonents)
    {
        Console.Write("Введите город, по которому требуется осуществить поиск: ");
        string city = Console.ReadLine();
        for (int i = 0; i < abonents.Count; i++)
        {
            if (abonents[i].City == city)
                Console.WriteLine(abonents[i].ToString());
        }
    }

    static void FindByNumber(List<Abonent> abonents)
    {
        Console.Write("Введите номер, по которому требуется осуществить поиск: ");
        string number = Console.ReadLine();
        for (int i = 0; i < abonents.Count; i++)
        {
            for (int j = 0; j < abonents[i].Number.Count; j++)
            {
                if (abonents[i].Number[j].Number == number)
                {
                    Console.WriteLine(abonents[i].ToString());
                    break;
                }
            }
        }
    }
    static void FindByProvider(List<Abonent> abonents)
    {
        Console.Write("Введите оператора связи, по которому требуется осуществить поиск: ");
        string provider = Console.ReadLine();
        for (int i = 0; i < abonents.Count; i++)
        {
            for (int j = 0; j < abonents[i].Number.Count; j++)
            {
                if (abonents[i].Number[j].Provider == provider)
                {
                    Console.WriteLine(abonents[i].ToString());
                    break;
                }
            }
        }
    }

    static void FindByYear(List<Abonent> abonents)
    {
        Console.Write("Введите оператора связи, по которому требуется осуществить поиск: ");
        int year = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < abonents.Count; i++)
        {
            for (int j = 0; j < abonents[i].Number.Count; j++)
            {
                if (abonents[i].Number[j].Year == year)
                {
                    Console.WriteLine(abonents[i].ToString());
                    break;
                }
            }
        }
    }

    static void AddAbonent(ref List<Abonent> abonents)
    {
        Abonent abonent = new Abonent();

        Console.Write("Введите ФИО: ");
        abonent.Name = Console.ReadLine();
        Console.Write("Введите город: ");
        abonent.City = Console.ReadLine();
        abonent.Number = new List<Numbers>();

        string input = "";
        do
        {
            Console.Write("Введите наименование оператора связи: ");
            string provider = Console.ReadLine();
            Console.Write("Введите год подключения номера: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите номер телефона: ");
            string number = Console.ReadLine();

            Numbers newNumber = new Numbers(provider, year, number);
            abonent.Number.Add(newNumber);

            Console.WriteLine("Введите непустую строку, чтобы добавить еще один номер.");
        }
        while ((input = Console.ReadLine()) != "");

        abonents.Add(abonent);
    }

    static void Main()
    {
        ShowMenu();
        bool work = true;

        List<Abonent> abonents = new List<Abonent>();

        while (work)
        {
            int action = Convert.ToInt32(Console.ReadLine());

            switch (action)
            {
                case 1:
                    AddAbonent(ref abonents);
                    ReturnToMenu();
                    break;
                case 2:
                    FindByCity(abonents);
                    ReturnToMenu();
                    break;
                case 3:
                    FindByNumber(abonents);
                    ReturnToMenu();
                    break;
                case 4:
                    FindByProvider(abonents);
                    ReturnToMenu();
                    break;
                case 5:
                    FindByYear(abonents);
                    ReturnToMenu();
                    break;
                case 6:
                    work = false;
                    break;
            }
        }
    }
}