using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

/*
 * Поиск минимального пути между 2 вершинами. Используется матрица весов и матрица, содержащая в себе длину пути. Для второй матрицы существует
 * вектор минимальных по столбцу и минимальных путей от одной вершины к другой.
 * 
 * 1. стек. на вход подаётся выражение, представляющее собой постфиксную польскую запись. необходимо вычислить выражение. раюотаем с положительными
 * элементами, разделёнными пробелами. Примеры 33 + 3 = 33 3 +, 3 * 2 + 5 = 3 2 * 5 +. Деление на ноль невозможно
 * 
 * 2. на вход подаётся список элементов. 1) определить элементы, с помщью которых составлен список. 2) выдать частоту появления каждого элемента
*/

class Program
{
    static double Operation(double first, double second, string operSign)
    {
        switch (operSign)
        {
            case "+":
                return first + second;

            case "-":
                return first - second;

            case "*":
                return first * second;

            case "/":
                if (second == 0)
                {
                    return double.NaN;
                }
                return first / second;
        }
        return 0;
    }

    static void Main()
    {
        string input = Console.ReadLine();
        string[] expression = input.Split();
        Stack<double> numbers = new Stack<double>();
        bool isValid = true;
        foreach (var i in expression)
        {
            bool isNumber = double.TryParse(i, out double num);
            if (isNumber)
            {
                numbers.Push(num);
            }
            else
            {
                bool hasSecond = numbers.TryPop(out double second);
                bool hasFirst = numbers.TryPop(out double first);

                if (!hasSecond || !hasFirst)
                {
                    isValid = false;
                    break;
                }
                else
                {
                    double res = Operation(first, second, i);

                    if (double.IsNaN(res))
                    {
                        isValid = false;
                        break;
                    }

                    numbers.Push(res);
                }
            }
        }

        if (isValid)
        {
            Console.WriteLine($"Результат: {numbers.Pop()}");
        }
        else
        {
            Console.WriteLine("Выражение неверно");
        }
    }
}
