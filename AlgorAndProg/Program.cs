using System;

class PZ6
{
    static void FillArray(ref int[] ar)
    {
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < ar.Length; i++)
        {
            ar[i] = Convert.ToInt32(Console.ReadLine());
        }
    }

    static int SumMod3(int[] ar)
    {
        int result = 0;
        foreach (int i in ar)
        {
            if (i % 3 == 0) result += i;
        }
        return result;
    }

    static int MultOdd(int[] ar)
    {
        int result = 1;
        
        foreach (int i in ar)
        {
            if (i % 2 != 0) 
            {
                result *= i;
            }
        }
        return result;
    }

    static int CountZero(int[] ar)
    {
        int k = 0;
        foreach (int i in ar)
        {
            if (i == 0) k += 1;
        }
        return k;
    }

    static void Main()
    {
        /* Даны 3 массива размерностью n, m, p. В каждом массиве определить сумму элементов, кратных трём, произведение
         * нечётных элементов, количество нулевых элементов.
         * Заполнение массивов выполнить с помощью функции, нахождение количества, суммы, произведения тоже с
         * помощью функции
         */
        Console.Write("Введите длину n первого массива:\t");
        int[] arN = new int[Convert.ToInt32(Console.ReadLine())];
        FillArray(ref arN);
        Console.Write("Введите длину m первого массива:\t");
        int[] arM = new int[Convert.ToInt32(Console.ReadLine())];
        FillArray(ref arM);
        Console.Write("Введите длину p первого массива:\t");
        int[] arP = new int[Convert.ToInt32(Console.ReadLine())];
        FillArray(ref arP);

        Console.WriteLine($"Суммы делимых на 3 равны: {SumMod3(arN)}, {SumMod3(arM)}, {SumMod3(arP)}");
        Console.WriteLine($"Произведения нечётных равны: {MultOdd(arN)}, {MultOdd(arM)}, {MultOdd(arP)}");
        Console.WriteLine($"Количества нулевых: {CountZero(arN)}, {CountZero(arM)}{CountZero(arP)}");
    }
}