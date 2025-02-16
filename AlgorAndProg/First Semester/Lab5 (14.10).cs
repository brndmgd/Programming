using System;

class Lab5
{
    public static void Main()
    {
        /*
         * Дан массив из n элементов, состоящий из переменных целого типа. Необходимо определить:
         * 1. все ли элементы расположены в порядке возрастания
         * 2. определить количество элементов, значение которых оканчивается на тройку
         * 3. для каждого элемента найти сумму цифр
         * 4. определить среднее арифметическое чётных элементов массива
        */
        /* 1. все ли элементы расположены в порядке возрастания
        int n = Convert.ToInt32(Console.ReadLine());
        int[] ar = new int[n];
        bool isSorted = true;
        for (int i = 0; i < n; i++)
        {
            ar[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 1; i < n; i++)
        {
            isSorted = ar[i] > ar[i - 1];
            if (!isSorted) break;
        }
        Console.WriteLine(isSorted ? "Отсортирован по возрастанию" : "Не отсортирован по возрастанию");
        */
        /* 2. определить количество элементов, значение которых оканчивается на тройку
        int n = Convert.ToInt32(Console.ReadLine());
        int[] ar = new int[n];
        int k = 0;
        for (int i = 0; i < n; i++)
        {
            ar[i] = Convert.ToInt32(Console.ReadLine());
        }
        foreach (int i in ar)
        {
            if (Math.Abs(i % 10) == 3) k++;
        }
        Console.WriteLine(k);
        */
        /* 3. для каждого элемента найти сумму цифр
        int n = Convert.ToInt32(Console.ReadLine());
        int[] ar = new int[n];
        for (int i = 0; i < n; i++)
        {
            ar[i] = Convert.ToInt32(Console.ReadLine());
        }
        foreach (int i in ar)
        {
            int num = i;
            int sum = 0;
            while (num != 0)
            {
                sum += Math.Abs(num % 10);
                num /= 10;
            }
            Console.WriteLine(sum);
        }
        */
        /* 4. определить среднее арифметическое чётных элементов массива
        int n = Convert.ToInt32(Console.ReadLine());
        int[] ar = new int[n];
        int sum = 0;
        int k = 0;
        for (int i = 0; i < n; i++)
        {
            ar[i] = Convert.ToInt32(Console.ReadLine());
        }
        foreach (int i in ar)
        {
            if (i % 2 == 0)
            {
                k++;
                sum += i;
            }
        }
        Console.WriteLine(k == 0? sum/(double)k : "Нет чётных");
        */
    }
}
