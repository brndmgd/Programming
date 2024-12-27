using System;
/*
Описать класс с именем «Поезд», содержащий поля:
название пункта назначения;
номер поезда;
время отправления.

Описать класс с именем «Станция», содержащий поля:
название станции;
список поездов, проходящих через станцию (список объектов класса «Поезд»).

Написать программу, выполняющую следующие действия:
ввод с клавиатуры данных класса типа «Поезд»;
вывод на экран информации о поездах, отправляющихся после введенного с клавиатуры времени, если таких поездов нет, вывести соответствующее сообщение;
*/
namespace Lab0912
{
    class Train
    {
        string Destination { get; set; }
        int Number { get; set; }
        public string Time{ get; set; }

        public Train(string destination, int number, string time)
        {
            Destination = destination;
            Number = number;
            Time = time;
        }

        public void Print()
        {
            Console.WriteLine($"Пункт назначения: {Destination}; Номер поезда: {Number}; Время отправления: {Time}");
        }
    }

    class Station
    {
        string Name { get; set; }
        public Train[] Trains { get; set; }

        public Station(string name, Train[] trains)
        {
            Name = name;
            Trains = trains;
        }

        public Station(string name)
        {
            Name = name;
        }
    }

    class Program
    {
        static void Continue()
        {
            Console.WriteLine("\nНажимте любую кнопку, чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main()
        {
            bool exit = false;
            Train[] trains = new Train[1];
            bool empty = true;
            while (!exit)
            {
                Console.WriteLine("Выберите одну из опций:");
                Console.WriteLine("\t1. Заполнение базы данных поездов");
                Console.WriteLine("\t2. Вывод всех поездов, отправляющихся после определённого времени");
                Console.WriteLine("\t3. Выход");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        if (!empty)
                        {
                            Console.WriteLine("База данных заполнена");
                            Continue();
                            break;
                        }
                        Console.WriteLine("Введите количество поездов:");
                        trains = new Train[Convert.ToInt32(Console.ReadLine())];
                        Console.WriteLine("Введите название пункта назначения, номер и время отправления поезда через \"/\"");
                        for (int i = 0; i < trains.Length; i++)
                        {
                            string[] input = Console.ReadLine().Split("/");
                            trains[i] = new Train(input[0], int.Parse(input[1]), input[2]);
                        }
                        empty = false;
                        Continue();
                        break;
                    case 2:
                        if (empty)
                        {
                            Console.WriteLine("База данных поездов пуста");
                            Continue();
                            break;
                        }
                        Console.WriteLine("Введите время в формате чч:мм");
                        string time = Console.ReadLine();
                        int minuteTime = int.Parse(time.Split(':')[0]) * 60 + int.Parse(time.Split(':')[1]);
                        Train[] onTime = new Train[trains.Length];
                        for(int i = 0; i < trains.Length; i++)
                        {
                            int minuteTrainTime = int.Parse(trains[i].Time.Split(':')[0]) * 60 + int.Parse(trains[i].Time.Split(':')[1]);
                            if (minuteTrainTime > minuteTime)
                            {
                                onTime[i] = trains[i];
                            }
                        }
                        if (onTime[0] != null)
                        {
                            Console.WriteLine("Поезда, приезжающие после этого времени");
                            foreach (var i in onTime) if(i != null) i.Print();
                        }
                        else Console.WriteLine("Таких поездов нет");
                        
                        Continue();
                        break;
                    case 3:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор");
                        Continue();
                        break;
                }
            }
        }
    }
}