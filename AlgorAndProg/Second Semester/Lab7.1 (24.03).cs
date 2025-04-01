using System;
using Microsoft.VisualBasic;

delegate void OutOfBoundsHandler();

class Dot {
    public double x {set; get;}
    public double y {set; get;}

    public Dot(double x, double y) {
        this.x = x;
        this.y = y;
    }
}

class OutOfBounds
{
    public event OutOfBoundsHandler OutOfBoundsEvent;

    public void OnOutOfBounds()
    {
        if (OutOfBoundsEvent != null)
        {
            OutOfBoundsEvent();
        }
    }
}

class Program
{
    static void Handler()
    {
        Console.WriteLine("Out Of Bounds");
        Console.ReadKey();
        Environment.Exit(0);
    }
    static void Main()
    {
        OutOfBounds evt = new OutOfBounds();
        evt.OutOfBoundsEvent += Handler;

        Console.WriteLine("Введите левый нижний и правый верхний углы прямоугольника");
        int[] lower = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] upper = Console.ReadLine().Split().Select(int.Parse).ToArray();
        
        Dot runningDot = new Dot((lower[0] + upper[0])/2d, (lower[1] + upper[1])/2d);
        Random coord = new Random();

        while (true)
        {
            runningDot.x += coord.NextDouble() * 2 - 1;
            runningDot.y += coord.NextDouble() * 2 - 1;
            if (runningDot.x < lower[0] || runningDot.x > upper[0] || runningDot.y < lower[1] || runningDot.y > upper[1])
            {
                evt.OnOutOfBounds();
            }
        }
    }
}
