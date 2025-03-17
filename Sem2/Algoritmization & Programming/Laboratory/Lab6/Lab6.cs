using System;

class Car
{
    public int Year;
    public string Name;
    public bool IsWashed;

    public Car(int year, string name, bool isWashed)
    {
        Year = year;
        Name = name;
        IsWashed = isWashed;
    }
}

class Garage
{
    public List<Car> Cars;
}

class CarWash
{
    public static void Wash(Car car)
    {
        if (car.IsWashed == true)
        {
            Console.WriteLine($"Машина {car.Name} уже помыта!");
            return;
        }

        car.IsWashed = true;
        Console.WriteLine($"Машина {car.Name} была помыта!");
    }
}

delegate void WashCar(Car car);
class Program
{
    static void Main()
    {
        WashCar washCar = new WashCar(CarWash.Wash);

        Garage garage = new Garage();
        garage.Cars = new List<Car>();

        Console.Write("Введите количество машин: ");
        int count = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.Write("Введите год выпуска: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите название: ");
            string name = Console.ReadLine();
            Console.Write("Машина помыта? (введите 1, если да; 0, если нет): ");
            int isWashed = Convert.ToInt32(Console.ReadLine());

            Car car = new Car(year, name, Convert.ToBoolean(isWashed));
            garage.Cars.Add(car);
            Console.WriteLine($"Машина {i+1} добавлена!");
        }

        for (int i = 0; i < garage.Cars.Count; i++)
        {
            washCar(garage.Cars[i]);
        }
    }
}