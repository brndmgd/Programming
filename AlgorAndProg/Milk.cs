using System;


class Milk
{

    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        /* Пример формата ввода данных:
        2
        10 10 5 10 10 10 12.23 20.12
        5 15 20 7 8 9 43.28 16.99
        ЗАМЕЧАНИЕ! Использовать именно точку для написания дробей
        */
        Console.WriteLine("Пример формата ввода данных:\n2\n10 10 5 10 10 10 12.23 20.12\n5 15 20 7 8 9 43.28 16.99\nЗАМЕЧАНИЕ! Использовать именно точку для написания дробей\n");
        Console.WriteLine("Скопируйте входные данные из файла с названием input и вставьте:");

        int n = Convert.ToInt32(Console.ReadLine());
        double[,] input = new double[n, 8];
        for (int i = 0; i < n; i++)
        {
            string[] curInput = Console.ReadLine().Split();
            for (int j = 0; j < 8; j++)
            {
                input[i, j] = Convert.ToDouble(curInput[j]);
            }
        }

        double minCost = 0;
        int minLine = 0;
        for (int i = 0; i < n; i++)
        {
            double s1 = 2 * (input[i, 0] * input[i, 1] + input[i,0] * input[i, 2] + input[i, 1] * input[i, 2]);
            double s2 = 2 * (input[i, 3] * input[i, 4] + input[i,3] * input[i, 5] + input[i, 4] * input[i, 5]);
            double v1 = input[i, 0] * input[i, 1] * input[i, 2] / 1000;
            double v2 = input[i, 3] * input[i, 4] * input[i, 5] / 1000;

            double milkCost = (s1 * input[i, 7] - input[i, 6] * s2) / (s1 * v2 - s2 * v1);

            if (i == 0) minCost = milkCost;
            else if (milkCost < minCost)
            {
                minCost = milkCost;
                minLine = i;
            }
        }

        Console.WriteLine($"{minLine+1} {minCost:N2}");
    }
}
