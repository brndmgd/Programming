using System;

class Title
{
    string Name;
}

interface IShape
{
    double GetPerimiter();
    double GetSurface();
}

class Square : Title, IShape
{
    double Side;
    string Name = "Square";

    public Square(double side)
    {
        Side = side;
    }
    public double GetPerimiter()
    {
        return 4 * Side;
    }

    public double GetSurface()
    {
        return Side * Side;
    }
}

class Triangle : Title, IShape
{
    double Side;

    public Triangle(double side)
    {
        Side = side;
    }
    public double GetPerimiter()
    {
        return Side * 3;
    }

    public double GetSurface()
    {
        return (Side * Side * Math.Sqrt(3)) / 4;
    }
}

class Circle : Title, IShape
{
    double Radius;

    public Circle(double radius)
    {
        Radius = radius;
    }
    public double GetPerimiter()
    {
        return 2 * Math.PI * Radius;
    }

    public double GetSurface()
    {
        return Math.PI * Radius * Radius;
    }
}

class Program
{
    static void Main()
    {
        double a = Convert.ToDouble(Console.ReadLine());
        Square square = new Square(a);
        Triangle triangle = new Triangle(a);
        Circle circle = new Circle(a);

        Console.WriteLine($"Периметр и площадь квадрата с длиной стороны {a}: {square.GetPerimiter()}, {square.GetSurface()}");
        Console.WriteLine($"Периметр и площадь равностороннего треугольника с длиной стороны {a}: {triangle.GetPerimiter()}, {triangle.GetSurface()}");
        Console.WriteLine($"Длина и площадь круга с радиусом {a}: {circle.GetPerimiter()}, {circle.GetSurface()}");
    }
}