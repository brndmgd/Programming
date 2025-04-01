using System;
/*
3 класса: машина, гараж и автомойка. Машина содержит в себе поля год выпуска, марка, и бул помыта ли. Гараж
содержит в себе список машин. Автомойка содержит в себе метод помойки машин.
Нужно помыть машины, которые не помыты и вывести сообщение. Машины, которые уже помыты, не нужно мыть.
*/
class Car
{
    public string Brand;
    public int Year;
    public bool IsClean;

    public Car(string brand, int year, bool isClean)
    {
        Brand = brand;
        Year = year;
        IsClean = isClean;
    }
}

class Garage
{
    public List<Car> Cars;
}

class CarWash
{
    public void Wash(Car car)
    {
        if (car.IsClean)
        {
            Console.WriteLine($"Машина {car.Brand} {car.Year} чистая");
        }
        else
        {
            car.IsClean = true;
            Console.WriteLine($"Машина {car.Brand} {car.Year} была помыта");
        }
    }
}

delegate void Washer(Car car);

class Program
{
    static void Main()
    {
        CarWash carwash = new CarWash();
        Garage garage = new Garage();
        garage.Cars = new List<Car>();
        Washer Washing = carwash.Wash;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "0") break;
            string[] arInput = input.Split();
            Car curCar = new Car(arInput[0], int.Parse(arInput[1]), bool.Parse(arInput[2]));
            garage.Cars.Add(curCar);
        }

        foreach (var car in garage.Cars)
        {
            Washing(car);
        }
    }
}