using System;

class Student
{
    public string Name { get; set; }
    public int Year { get; set; }
    public string Class { get; set; }
    public string PhoneNumber { get; set; }

    public override string ToString()
    {
        return $"Имя: {Name}, год рождения: {Year}, класс: {Class}, телефон: {PhoneNumber}";
    }
}

class Program
{
    static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Добро пожаловать в меню!\n1. Добавить студента в базу\n2. Выборка по году рождения\n3. Выборка по классу\n4. Выход\n\nВведите действие: ");
    }

    static void ReturnToMenu()
    {
        Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
        Console.ReadKey();
        ShowMenu();
    }

    static void AddStudent(ref Student[] students, ref int studentsCount)
    {
        if (studentsCount >= students.Length)
        {
            Console.WriteLine("Переполнение базы данных");
            return;
        }

        Console.Write("Введите ФИО: ");
        string name = Console.ReadLine();
        Console.Write("Введите год рождения: ");
        int year = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите класс: ");
        string classStr = Console.ReadLine();
        Console.Write("Введите номер телефона: ");
        string phoneNumber = Console.ReadLine();

        students[studentsCount] = new Student();
        students[studentsCount].Name = name;
        students[studentsCount].Year = year;
        students[studentsCount].Class = classStr;
        students[studentsCount].PhoneNumber = phoneNumber;
        studentsCount++;

        Console.WriteLine("Студент успешно добавлен!");
    }

    static void QueryByYear(Student[] students, int studentsCount)
    {
        if (studentsCount == 0)
        {
            Console.WriteLine("База данных пуста");
            return;
        }

        Console.Write("Введите год рождения, по которому требуется осуществить выборку: ");
        int year = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < studentsCount; i++)
        {
            if (students[i].Year == year)
            {
                Console.WriteLine(students[i].ToString());
            }
        }

        Console.WriteLine("Выборка закончена.");
    }

    static void QueryByClass(Student[] students, int studentsCount)
    {
        if (studentsCount == 0)
        {
            Console.WriteLine("База данных пуста");
            return;
        }

        Console.Write("Введите класс, по которому требуется осуществить выборку: ");
        string Class = Console.ReadLine();

        for (int i = 0; i < studentsCount; i++)
        {
            if (students[i].Class == Class)
            {
                Console.WriteLine(students[i].ToString());
            }
        }

        Console.WriteLine("Выборка закончена.");
    }
    static void Main()
    {
        const int maxStudentsCount = 50;
        Student[] students = new Student[maxStudentsCount];
        int studentsCount = 0;

        ShowMenu();

        bool work = true;

        while (work)
        {
            int action = Convert.ToInt32(Console.ReadLine());

            switch (action)
            {
                case 1:
                    AddStudent(ref students, ref studentsCount);
                    ReturnToMenu();
                    break;
                case 2:
                    QueryByYear(students, studentsCount);
                    ReturnToMenu();
                    break;
                case 3:
                    QueryByClass(students, studentsCount);
                    ReturnToMenu();
                    break;
                case 4:
                    work = false;
                    break;
            }
        }
    }
}