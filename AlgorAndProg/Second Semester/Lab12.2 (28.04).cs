using System;
using System.Globalization;

class Client
{
    public int ID { get; set; }
    public string Name { get; set; }

    public Client(int id, string name)
    {
        ID = id;
        Name = name;
    }
}

class Coach
{
    public int ID { get; set; }
    public string Name { get; set; }

    public Coach(int id, string name)
    {
        ID = id;
        Name = name;
    }
}

class Visit
{
    public int CoachID { get; set; }
    public int ClientID { get; set; }
    public string Date { get; set; }
    public int Duration { get; set; }

    public Visit(int coachId, int clientId, string date, int duration)
    {
        CoachID = coachId;
        ClientID = clientId;
        Date = date;
        Duration = duration;
    }

    public Visit(string[] ar)
    {
        CoachID = int.Parse(ar[0]);
        ClientID = int.Parse(ar[1]);
        Date = ar[2];
        Duration = int.Parse(ar[3]);
    }
}

class Program
{
    static void Main()
    {
        List<Client> clients = new List<Client>();
        List<Coach> coaches = new List<Coach>();
        List<Visit> visits = new List<Visit>();

        string input = "";
        Console.WriteLine("Введите клиентов");
        do
        {
            input = Console.ReadLine();
            if (input != "0")
            {
                Client curClient = new Client(int.Parse(input.Split()[0]), input.Split()[1]);
                clients.Add(curClient);
            }
        } while (input != "0");

        Console.WriteLine("Введите тренеров");
        do
        {
            input = Console.ReadLine();
            if (input != "0")
            {
                Coach curCoach = new Coach(int.Parse(input.Split()[0]), input.Split()[1]);
                coaches.Add(curCoach);
            }
        } while (input != "0");

        Console.WriteLine("Введите посещения");
        do
        {
            input = Console.ReadLine();
            if (input != "0")
            {
                Visit curVisit = new Visit(input.Split());
                visits.Add(curVisit);
            }
        } while (input != "0");

        var groupDate = visits.GroupBy(x => x.Date);
        foreach (var i in groupDate)
        {
            Console.WriteLine($"Дата: {i.Key}");
            foreach (var j in i)
            {
                string curClient = clients.Find(x => x.ID == j.ClientID).Name;
                string curCoach = coaches.Find(x => x.ID == j.CoachID).Name;
                Console.WriteLine($"\tКлиент: {curClient} Тренер: {curCoach} Время: {j.Duration} минут");
            }
        }
        Console.WriteLine();

        var groupCoach = visits.GroupBy(v => v.CoachID);
        foreach (var i in groupCoach)
        {
            var curCoach = coaches.Find(x => x.ID == i.Key).Name;
            Console.WriteLine($"Тренер: {curCoach}");
            foreach (var j in i)
            {
                var curClient = clients.First(x => x.ID == j.ClientID);
                Console.WriteLine($"\tКлиент: {curClient.Name}, Дата: {j.Date}, Время: {j.Duration} минут");
            }
        }
        Console.WriteLine();

        var maxDuration = visits
           .GroupBy(x => x.ClientID)
           .Select(x => new { ClientID = x.Key, TotalTime = x.Sum(y => y.Duration) })
           .OrderBy(x => x.TotalTime)
           .First();
        var maxClient = clients.Find(x => x.ID == maxDuration.ClientID).Name;
        Console.WriteLine($"Клиент {maxClient} имеет наибольшее время посещения ({maxDuration.TotalTime} минут)");

        foreach (var client in clients)
        {
            Console.WriteLine($"Клиент: {client.Name}");
            var curVisits = visits.Where(x => x.ClientID == client.ID);
            foreach (var visit in curVisits)
            {
                Console.WriteLine($"\tДата: {visit.Date} Время: {visit.Duration} минут");
            }
        }
    }
}