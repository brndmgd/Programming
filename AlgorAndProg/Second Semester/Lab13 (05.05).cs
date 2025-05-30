using System;

/* Имеется база данных движения товаров на складе, которая хранит следующую информацию: сведение о товарах, 
 * сведение о поставщиках, отображение движения товаров на складе. 
 * связь между таблицу по номеру поставщика и номеру товара. 
 * движение товара отображает поступил товар или товар выдан. Если товар выдается, то поставщика нет.
 * Кол-во поступившего или выданного товара, цена поступления и цена выдачи за 1 единицу. Выдать поступление 
 * товаров, сгруппированные по дате. Поступление товаров, сгруппированные по поставщику и отсортированные по 
 * дате. Выдать список товаров, которые имеются на складе. Выдать список товаров сгруппипрованных по 
 * выдаче, внутри тоже сортировка по дате. Выдать на какую сумму был выдан товар (общая сумма). 
 * Прибыль которую получили на складе, тоже выдать */

class Product
{
    public int ID { get; set; }
    public string Name { get; set; }

    public Product(int id, string name)
    {
        ID = id;
        Name = name;
    }
}

class Supplier
{
    public int ID { get; set; }
    public string Name { get; set; }

    public Supplier(int id, string name)
    {
        ID = id;
        Name = name;
    }
}

class Movement
{
    public int ProductID { get; set; }
    public int SupplierID { get; set; }
    public int Quantity { get; set; }
    public bool isIncoming { get; set; }
    public double Price { get; set; }
    public string Date { get; set; }

    public Movement(string[] input)
    {
        ProductID = int.Parse(input[0]);
        SupplierID = int.Parse(input[1]);
        Quantity = int.Parse(input[2]);
        isIncoming = bool.Parse(input[3]);
        Price = double.Parse(input[4]);
        Date = input[5];
    }
}

class Store
{
    static void FilterIncoming(List<Movement> movements, List<Product> products)
    {
        var filtered = movements.Where(x => x.isIncoming).GroupBy(x => x.Date);

        foreach (var i in filtered)
        {
            Console.WriteLine($"Дата: {i.Key}");
            foreach (var j in i)
            {
                var curProduct = products.Find(x => x.ID == j.ProductID);
                Console.WriteLine($"Товар: {curProduct} Количество: {j.Quantity} Цена: {j.Price}");
            }
        }
    }

    static void FilterSuppliers(List<Movement> movements, List<Supplier> suppliers, List<Product> products)
    {
        var filtered = movements
            .Where(x => x.isIncoming && x.SupplierID != -1)
            .OrderBy(x => x.Date)
            .GroupBy(x => x.SupplierID);

        foreach (var i in filtered)
        {
            var curSupplier = suppliers.Find(x => x.ID == i.Key).Name;
            Console.WriteLine($"Поставщик: {curSupplier}");
            foreach (var j in i)
            {
                var curProduct = products.Find(x => x.ID == j.ProductID).Name;
                Console.WriteLine($"Товар: {curProduct} Дата: {j.Date}");
            }
        }
    }

    static void InStock(List<Movement> movements, List<Product> products)
    {
        Console.WriteLine("Сейчас на складе присутствуют следующие товары:");
        foreach (var product in products)
        {
            int incoming = movements
                .Where(x => x.ProductID == product.ID && x.isIncoming)
                .Sum(x => x.Quantity);
            int outgoing = movements
                .Where(x => x.ProductID == product.ID && !x.isIncoming)
                .Sum(x => x.Quantity);
            int stockQuantity = incoming - outgoing;
            if (stockQuantity > 0)
                Console.WriteLine($"Товар: {product.Name} Количество: {stockQuantity}");
        }
    }

    static void Income(List<Movement> movements)
    {
        double income = movements
            .Where(x => !x.isIncoming)
            .Sum(x => x.Quantity * x.Price);
        Console.WriteLine($"Сумма выданного товара составляет {income:c}");
    }

    static void Profit(List<Movement> movements)
    {
        double income = movements
            .Where(x => !x.isIncoming)
            .Sum(x => x.Quantity * x.Price);
        double loss = movements
            .Where(x => x.isIncoming)
            .Sum(x => x.Quantity * x.Price);
        Console.WriteLine($"Прибыль магазина составляет {income - loss:c}");
    }

    static void Continue()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения..");
        Console.ReadKey();
        Console.Clear();
    }

    static void Main()
    {
        List<Product> products = new List<Product>();
        List<Supplier> suppliers = new List<Supplier>();
        List<Movement> movements = new List<Movement>();

        Console.WriteLine("Введите товары:");
        string input = "";
        do
        {
            input = Console.ReadLine().Trim();
            if (input != "0")
            {
                string[] ar = input.Split();
                Product curProduct = new Product(int.Parse(ar[0]), ar[1]);
                products.Add(curProduct);

            }
        } while (input != "0");

        Console.WriteLine("Введите поставщиков:");
        do
        {
            input = Console.ReadLine().Trim();
            if (input != "0")
            {
                string[] ar = input.Split();
                Supplier curSupplier = new Supplier(int.Parse(ar[0]), ar[1]);
                suppliers.Add(curSupplier);
            }
        } while (input != "0");

        Console.WriteLine("Введите движение товаров:");
        do
        {
            input = Console.ReadLine().Trim();
            if (input != "0")
            {
                string[] ar = input.Split();
                Movement curMovement = new Movement(ar);
                movements.Add(curMovement);
            }
        } while (input != "0");

        do
        {
            Console.WriteLine("Меню");
            Console.WriteLine("1. Поступление товаров по дате");
            Console.WriteLine("2. Список товаров по поставщику");
            Console.WriteLine("3. Список товаров на складе");
            Console.WriteLine("4. Сумма выданного товара");
            Console.WriteLine("5. Прибыль");
            Console.WriteLine("6. Выход");
            input = Console.ReadLine();
            Console.Clear();
            switch (int.Parse(input))
            {
                case 1:
                    FilterIncoming(movements, products);
                    break;
                case 2:
                    FilterSuppliers(movements, suppliers, products);
                    break;
                case 3:
                    InStock(movements, products);
                    break;
                case 4:
                    Income(movements);
                    break;
                case 5:
                    Profit(movements);
                    break;
                case 6:
                    Console.WriteLine("Выход");
                    break;
                default:
                    Console.WriteLine("Неверная опция");
                    break;
            }
            Continue();
        } while (input != "6");
    }
}