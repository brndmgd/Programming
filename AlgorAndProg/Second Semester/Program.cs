using System;
using System.Text;

/*
выделяется список абонентов, у каждого абонента может быть несколько номеров. номер подключен к определенному оператору.
характеристики абонента: фио, номер телефона, оператор связи, год подключения, город. поиск по городу, по номеру телефона,
по оператору связи, по году подключения. реализация с меню. 2 класса: 1 абонентов, 2 телефонов. список из телефонов,
которве подключены к каждому абоненту
*/

namespace Mobile_Network
{
    class Phone
    {
        public string Number { get; }
        public string Provider { get; }
        public string Year { get; }

        public Phone(string number, string provider, string year)
        {
            Number = number;
            Provider = provider;
            Year = year;
        }
    }
    class Subscriber
    {
        public string Name { get; }
        public List<Phone> Phones { get; }
        public string City { get; }

        public Subscriber(string name, List<Phone> phones, string city)
        {
            Name = name;
            Phones = phones;
            City = city;
        }

    }

    class Program
    {
        static void Continue()
        {
            Console.WriteLine("\n Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }
        static void AddSubscriber(List<Subscriber> subs, string[] subInfo)
        {
            Console.WriteLine("Введите номера абонента с оператором и годом подключения. Для окончания заполнения введите 0.");
            string input;
            string name = $"{subInfo[0]} {subInfo[1]} {subInfo[2]}";
            List<Phone> phones = new List<Phone>();
            while (true)
            {
                input = Console.ReadLine();
                if (input == "0") break;
                string[] phone = input.Split();
                Phone curPhone = new Phone(phone[0], phone[1], phone[2]);
                phones.Add(curPhone);
            }
            Subscriber sub = new Subscriber(name, phones, subInfo[3]);
            subs.Add(sub);
        }

        static void Main()
        {
            Console.OutputEncoding = Console.InputEncoding = Encoding.Unicode;
            int choice;
            List<Subscriber> subscribers = new List<Subscriber>();
            do
            {
                Console.WriteLine("Выберите опции:");
                Console.WriteLine("\t 1. Заполнить/добавить абонентов");
                Console.WriteLine("\t 2. Фильтр по городу");
                Console.WriteLine("\t 3. Фильтр по номеру телефона");
                Console.WriteLine("\t 4. Фильтр по оператору связи");
                Console.WriteLine("\t 5. Фильтр по году подключения");
                Console.WriteLine("\t 6. Выход");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            Console.WriteLine("Введите ФИО и город абонента.");
                            string input = Console.ReadLine();
                            if (input == "0")
                            {
                                Continue();
                                break;
                            }
                            string[] subInfo = input.Split();
                            AddSubscriber(subscribers, subInfo);  
                        }
                        break;

                    case 2:
                        if (subscribers.Count == 0)
                        {
                            Console.WriteLine("Список абонентов пуст");
                            Continue();
                            break;
                        }
                        Console.WriteLine("Введите город");
                        string city = Console.ReadLine();
                        foreach (var i in subscribers)
                        {
                            if (i.City == city) Console.WriteLine(i.Name);
                        }
                        Continue();
                        break;

                    case 3:
                        if (subscribers.Count == 0)
                        {
                            Console.WriteLine("Список абонентов пуст");
                            Continue();
                            break;
                        }
                        Console.WriteLine("Введите номер телефона");
                        string number = Console.ReadLine();
                        foreach (var i in subscribers)
                        {
                            foreach (var j in i.Phones)
                            {
                                if (j.Number == number)
                                {
                                    Console.WriteLine($"{i.Name} {j.Number} {j.Provider} {j.Year}");
                                    break;
                                }
                            }
                        }
                        Continue();
                        break;

                    case 4:
                        if (subscribers.Count == 0)
                        {
                            Console.WriteLine("Список абонентов пуст");
                            Continue();
                            break;
                        }
                        Console.WriteLine("Введите оператора связи");
                        string provider = Console.ReadLine();
                        foreach (var i in subscribers)
                        {
                            foreach (var j in i.Phones)
                            {
                                if (j.Provider == provider)
                                {
                                    Console.WriteLine($"{i.Name} {j.Number} {j.Provider} {j.Year}");
                                    break;
                                }
                            }
                        }
                        Continue();
                        break;

                    case 5:
                        if (subscribers.Count == 0)
                        {
                            Console.WriteLine("Список абонентов пуст");
                            Continue();
                            break;
                        }
                        Console.WriteLine("Введите год подключения");
                        string year = Console.ReadLine();
                        foreach (var i in subscribers)
                        {
                            foreach (var j in i.Phones)
                            {
                                if (j.Year == year)
                                {
                                    Console.WriteLine($"{i.Name} {j.Number} {j.Provider} {j.Year}");
                                    break;
                                }
                            }
                        }
                        Continue();
                        break;

                    case 6:
                        break;

                    default:
                        Console.WriteLine("Неверный выбор.");
                        Continue();
                        break;
                }

            } while (choice != 6);
        }
    }
}