using System;

class User {
    public string Name { get; set; }
    public string Date { get; set; }
    public bool HasComputer { get; set; }
    public Computer? Computer { get; set; }

    public User(string name, string date, bool hasComputer, Computer? computer = null) {
        Name = name;
        Date = date;
        HasComputer = hasComputer;
        Computer = computer;
    }
}

class Computer {
    public string Brand { get; set; }
    public string Year { get; set; }
    public string OS { get; set; }

    public Computer(string brand, string year, string os) {
        Brand = brand;
        Year = year;
        OS = os;
    }
}

class Program {
    static void Continue() {
        Console.WriteLine("Нажмите любую кнопку для продолжения");
        Console.ReadKey();
        Console.Clear();
    }
    
    static List<User> ComputerFilter(List<User> users, bool hasComputer) {
        List<User> filtered = users.Where(x => x.HasComputer == hasComputer).ToList();
        return filtered;
    }

    static void Main() {
        List<User> users = new List<User>();
        users.Add(new User("A", "1", true, new Computer("Asus", "2020", "Windows")));
        users.Add(new User("B", "1", false));
        users.Add(new User("C", "1", true, new Computer("Asus", "2014", "Linux")));
        users.Add(new User("D", "1", true, new Computer("Apple", "2023", "Windows")));
        users.Add(new User("E", "1", false));
        users.Add(new User("F", "1", true, new Computer("Irbis", "2026", "MacOS")));
        string? choice = "";
        do {
            Console.WriteLine("1. Пользователи без компьютера");
            Console.WriteLine("2. Фильтер пользователей по ОС");
            Console.WriteLine("3. Фильтер по марке компьютера");
            Console.WriteLine("4. Сравнение количества пользователей");
            Console.WriteLine("0. Выход");
            choice = Console.ReadLine();
            switch (choice) {
                case "1":
                    Console.WriteLine("Пользователи без компьютера:");
                    foreach (var i in ComputerFilter(users, false)) 
                        Console.WriteLine($"Имя: {i.Name}, Год рождения: {i.Date}");
                    Continue();
                    break;
                case "2":
                    Console.WriteLine("Введите OS");
                    string inputOS = Console.ReadLine();
                    List<User> filterOS = ComputerFilter(users, true).Where(x => x.Computer.Brand == inputOS).ToList();
                    foreach (var i in filterOS)
                        Console.WriteLine($"Имя: {i.Name}, Год рождения: {i.Date}, Марка: {i.Computer.Brand}, Год выпуска: {i.Computer.Year}");
                    Continue();
                    break;
                case "3":
                    Console.WriteLine("Введите марку");
                    string inputBrand = Console.ReadLine();
                    List<User> filterBrand = ComputerFilter(users, true).Where(x => x.Computer.Brand == inputBrand).ToList();
                    foreach (var i in filterBrand)
                        Console.WriteLine($"Имя: {i.Name}, Год рождения: {i.Date}, OS: {i.Computer.OS}, Год выпуска: {i.Computer.Year}");
                    Continue();
                    break;
                case "4":
                    int countNoComputers = ComputerFilter(users, false).Count();
                    int countComputers = ComputerFilter(users, true).Count();
                    Console.WriteLine($"Количество пользователей с компьютером: {countComputers}, Без компьютера: {countNoComputers}");
                    Continue();
                    break;
                    
            }
        } while (choice != "0");
    }
}