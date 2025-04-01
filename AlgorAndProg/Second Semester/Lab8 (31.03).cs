/*
Задание 1. Реализовать сложение, разность, умножение и деление на число с помощью лямбда-функций.
Предусмотреть деление на ноль.
Задание 2. Дан список текстовых переменных. Нужно вывести все элементы данного списка, которые начинаются
на а.
*/
using System;

delegate double Oper(double a, double b);

class Program()
{
    static void Main()
    {
        /* Задание 1
        double num1 = Convert.ToDouble(Console.ReadLine());
        double num2 = Convert.ToDouble(Console.ReadLine());

        Oper plus = (x, y) => x + y;
        Oper minus = (x, y) => x - y;
        Oper mult = (x, y) => x * y;
        Oper div = (x, y) => y == 0 ? double.NaN : x / y;

        Console.WriteLine($"{num1} + {num2} = {plus(num1, num2)}");
        Console.WriteLine($"{num1} - {num2} = {minus(num1, num2)}");
        Console.WriteLine($"{num1} * {num2} = {mult(num1, num2)}");
        Console.WriteLine($"{num1} / {num2} = {div(num1, num2)}");
        */
        // Задание 2
        List<string> text = new List<string>();
        string input;
        while (true) {
            input = Console.ReadLine();
            if (input == "0") break;
            text.Add(input);
        }

        Console.WriteLine("Слова, начинающиеся с а");
        var filter = text.Where(x => x[0] == 'a' || x[0] == 'а');
        foreach(var i in filter) {
            Console.WriteLine(i);
        }
    }
}