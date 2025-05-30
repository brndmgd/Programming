using System;
using System.Linq;

class Phone
{
    public string Number {set; get;}
    public string Name {set; get;}
    public string Provider {set; get;}
    public string Year {set; get;}

    public Phone(string[] input)
    {
        Number = input[0];
        Name = input[1];
        Provider = input[2];
        Year = input[3];
    }
}

class Program
{
    static void Continue() {
        Console.WriteLine("Нажмите любую кнопку");
        Console.ReadKey();
        Console.Clear();
    }
    static void Main()
    {
        List<Phone> phones = new List<Phone>();
        string? input;
        do {
            input = Console.ReadLine();
            if (input == null) continue;
            string[] ar = input.Split("/");
            Phone curPhone;
            try {
                curPhone = new Phone(ar);
                phones.Add(curPhone);
            }
            catch (IndexOutOfRangeException exc) {
                Console.WriteLine("Неверный формат ввода:\n" + exc.Message);
                return;
            }
        } while (input != "0");

        do {
            Console.WriteLine("Меню:\n\t1. Группа  по году подключения\n\t2. Группа по оператору связи\n\t3. Телефон по имени владельца");
            input = Console.ReadLine();
            switch (input) {
                case "1":
                    Console.WriteLine("Введите год");
                    string inputYear = Console.ReadLine();
                    var filterYear = phones.Where(x => x.Year == inputYear);
                    Console.WriteLine("Список телефонов, подключённых в этом году:");
                    foreach (var i in filterYear) {
                        Console.WriteLine($"{i.Name} {i.Number} {i.Provider}");
                    }
                    Continue();
                    break;
                case "2":
                    Console.WriteLine("Введите оператора связи");
                    string inputProvider = Console.ReadLine();
                    var filterProvider = phones.Where(x => x.Provider == inputProvider);
                    Console.WriteLine("Список телефонов данного оператора связи:");
                    foreach (var i in filterProvider) {
                        Console.WriteLine($"{i.Name} {i.Number} {i.Year}");
                    }
                    Continue();
                    break;
                case "3":
                    Console.WriteLine("Введите имя абонента");
                    string inputName = Console.ReadLine();
                    var filterName = phones.Where(x => x.Name == inputName);
                    Console.WriteLine("Список телефонов, зарегистрированных на данного абонента");
                    foreach (var i in filterName) {
                        Console.WriteLine($"{i.Number} {i.Year} {i.Provider}");
                    }
                    Continue();
                    break;
                case "4":
                    Console.WriteLine("Выход из приложения...");
                    Continue();
                    break;
                default:
                    Console.WriteLine("Неправильная опция");
                    Continue();
                    break;
            }
        } while (input != "4");
    }
}