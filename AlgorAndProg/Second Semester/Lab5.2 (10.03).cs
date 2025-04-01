using System;

class TwoElements
{
    public double A { get; set; }
    public double B { get; set; }

    public TwoElements(double a, double b)
    {
        A = a;
        B = b;
    }

    public double Summ()
    {
        A = A + B;
        return A;
    }

    public double Diff()
    {
        A = A - B;
        return A;
    }

    public double Mult()
    {
        A = A * B;
        return A;
    }

    public double Frac()
    {
        if (B != 0) A = A / B;
        else A = double.NaN;
        return A;
    }
}

delegate double First();
delegate double Second();

class Program
{
    static void Main()
    {
        double a = Convert.ToInt32(Console.ReadLine());
        double b = Convert.ToInt32(Console.ReadLine());
        TwoElements obj = new TwoElements(a, b);
        First operation1 = (First)obj.Summ + obj.Diff + obj.Mult;
        Console.WriteLine(operation1());
        obj = new TwoElements(a, b);
        Second operation2 = (Second)obj.Mult + obj.Summ + obj.Frac;
        Console.WriteLine(operation2());
    }
}
