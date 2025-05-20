using System;

public class Product(int id, string name)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
}

public class Supplier(int id, string name)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
}

public class ProductMovement(int productId, int providerId, int count, bool isIncoming, double price, string date)
{
    public int ProductId { get; set; } = productId;
    public int ProviderId { get; set; } = providerId;
    public int Quantity { get; set; } = count;
    public bool IsIncoming { get; set; } = isIncoming;
    public double PricePerUnit { get; set; } = price;
    public string Date { get; set; } = date;
}

class Warehouse
{
    public static List<Product> Products { get; set; } = new();
    public static List<Supplier> Suppliers { get; set; } = new();
    public static List<ProductMovement> Movements { get; set; } = new();

    static void Main()
    {
        Product product1 = new Product(1, "Product1");
        Product product2 = new Product(2, "Product2");

        Supplier supplier1 = new Supplier(1, "Supplier1");
        Supplier supplier2 = new Supplier(2, "Supplier2");

        ProductMovement pm1 = new ProductMovement
        (
            product1.Id,
            supplier1.Id,
            10,
           true,
            50000,
            "2023:4:5"
        );

        ProductMovement pm2 = new ProductMovement
        (
            product2.Id,
            supplier2.Id,
            5,
            true,
            15000,
            "2023:4:5"
        );

        ProductMovement pm3 = new ProductMovement
        (
            product1.Id,
            supplier2.Id,
            5,
            true,
            48000,
            "2023:4:6"
        );

        ProductMovement pm4 = new ProductMovement
        (
            product1.Id,
            -1,
            8,
            false,
            100000,
            "2023:4:6"
        );

        Products.Add(product1);
        Products.Add(product2);

        Suppliers.Add(supplier1);
        Suppliers.Add(supplier2);

        Movements.Add(pm1);
        Movements.Add(pm2);
        Movements.Add(pm3);
        Movements.Add(pm4);

        bool work = true;

        while (work)
        {
            Console.WriteLine("\n1. сгруппировать выдачи по датам\n2. сруппировать по поставщику, отсортировать по дате\n3. список товаров на складе\n4. общая сумма выданных товаров\n5. прибыль склада\n6. выход");

            int action = int.Parse(Console.ReadLine());

            switch (action)
            {
                case 1:
                    GetIncomingByDate();
                    break;
                case 2:
                    GetProvidersByDate();
                    break;
                case 3:
                    GetAllProducts();
                    break;
                case 4:
                    GetAllIncomingSum();
                    break;
                case 5:
                    GetAllIncome();
                    break;
                case 6:
                    work = false;
                    break;
            }
        }
    }
    public static void GetIncomingByDate()
    {
        var grouped = Movements
            .Where(m => m.IsIncoming)
            .GroupBy(m => m.Date);

        Console.WriteLine("поступления сгруппированные по дате:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"дата: {group.Key}");
            foreach (var m in group)
            {
                Console.WriteLine($"товар: {m.ProductId}, количество: {m.Quantity}, цена: {m.PricePerUnit}");
            }
        }
    }

    public static void GetProvidersByDate()
    {
        var grouped = Movements
            .Where(m => m.IsIncoming && m.ProviderId != -1)
            .GroupBy(m => m.ProviderId);

        Console.WriteLine("поступления сгруппированные по поставщикам и дате:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"дата: {group.Key}");
            foreach (var m in group)
            {
                Console.WriteLine($"поставщик: {m.ProviderId}, товар: {m.ProductId}");
            }
        }
    }

    public static void GetAllProducts()
    {
        Console.WriteLine("остатки на складе:");
        foreach (var product in Products)
        {
            int incoming = Movements.Where(m => m.ProductId == product.Id && m.IsIncoming).Sum(m => m.Quantity);
            int outgoing = Movements.Where(m => m.ProductId == product.Id && !m.IsIncoming).Sum(m => m.Quantity);
            int stock = incoming - outgoing;

            if (stock > 0)
            {
                Console.WriteLine($"{product.Name}: {stock} штук");
            }
        }
    }
    
    public static void GetAllIncomingSum()
    {
        var total = Movements
            .Where(m => !m.IsIncoming)
            .Sum(m => m.Quantity * m.PricePerUnit);
        Console.WriteLine($"сумма выданного товара = {total}");
    }
    
    public static void GetAllIncome()
    {
        double profit = 0;

        var productGroups = Movements
            .GroupBy(m => m.ProductId);

        foreach (var group in productGroups)
        {
            var incoming = group.Where(m => m.IsIncoming).ToList();
            var outgoing = group.Where(m => !m.IsIncoming).ToList();

            double totalIncomingCost = incoming.Sum(m => m.Quantity * m.PricePerUnit);
            double totalOutgoingRevenue = outgoing.Sum(m => m.Quantity * m.PricePerUnit);

            profit += totalOutgoingRevenue - totalIncomingCost;
        }

        Console.WriteLine($"прибыль склада = {profit} руб.");
    }
}
