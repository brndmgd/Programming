using System;

class Zadanie1
{
    static void Main()
    {
        /*Задание 1. Заменить значения двух переменных без использования третьей*/
        /*int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        a = a + b;
        b = a - b;
        a = a - b;
        Console.WriteLine(a);
        Console.WriteLine(b);*/
        /*Задание 2. вывести минимум из двух переменных. */
        /*int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = (a + b - Math.Abs(a - b)) / 2;
        Console.WriteLine(c);*/
        /*Задание 3. Найти путь для полива грядок по определённому алгоритму */
        Console.WriteLine("Введите ширину грядки");
        int l = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите длину грядки");
        int m = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите расстояние от колодца до грядки");
        int k = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите количество грядок");
        int n = Convert.ToInt32(Console.ReadLine());
        int result = 2 * n * (k + m + l) + (n - 1) * n * l;
        Console.WriteLine(result);
    }
}
