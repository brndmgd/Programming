using System;

class Cockroach
{
    public int Number { set; get; }
    public double Speed { set; get; }
    public double Position { set; get; }

    public Cockroach(int number, double speed, double position)
    {
        Number = number;
        Speed = speed;
        Position = position;
    }

    public void Move()
    {
        Position += Speed;
    }
}

delegate void FinishHandler(int n);

class Finish
{
    public event FinishHandler FinishEvent;

    public void OnFinishEvent(int number)
    {
        FinishEvent(number);
    }
}

class Program
{
    static void Handler(int number)
    {
        Console.WriteLine($"Таракан номер {number} выиграл!");
        Environment.Exit(0);
    }

    static void Main()
    {
        Finish evt = new Finish();
        evt.FinishEvent += Handler;
        Cockroach ob1 = new Cockroach(1, 0, 0);
        Cockroach ob2 = new Cockroach(2, 0, 0);
        Cockroach ob3 = new Cockroach(3, 0, 0);
        Cockroach[] roaches = { ob1, ob2, ob3 };

        int interval = Convert.ToInt32(Console.ReadLine());
        int finish = Convert.ToInt32(Console.ReadLine());
        Random v = new Random();
        int curTime = 0;

        while (true)
        {
            foreach (var roach in roaches) {
                if (curTime % interval == 0) {
                    roach.Speed += v.NextDouble() * 10 - 5;
                }
                roach.Move();
                if (roach.Position >= finish) {
                    evt.OnFinishEvent(roach.Number);
                }
            }
            curTime++;
        }
    }
}
