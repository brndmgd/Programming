using System;

class Lab3
{
    static void Main()
    {
        /* Дана последовательность из n элементов
        1. Подпоследовательность из одинаковых элементов
        2. Мин подпоследовательность из 0
        3. Определить макс сумму подпоследовательности из чётных чисел
        */
        /* Задача 1. Подпоследовательность из одинаковых элементов
        int n = Convert.ToInt32(Console.ReadLine());
        int maxlen = 0;
        int prev = 0;
        int curlen = 1;
        for (int i = 0; i < n; i++)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            if (i > 0)
            {
                if (number == prev) curlen++ ;
                else 
                {
                    maxlen = Math.Max(curlen, maxlen);
                    curlen = 1;
                }
            }
            prev = number;
        }
        maxlen = Math.Max(curlen, maxlen);
        Console.WriteLine(maxlen);
        */
        /* Задача 2. Мин подпоследовательность из 0
        int n = Convert.ToInt32(Console.ReadLine());
        int minlen = n;
        int curlen = 0;
        for (int i = 0; i < n; i++)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            if (number == 0) curlen++;
            else
            {
                minlen = curlen > 0 ? Math.Min(curlen, minlen) : minlen;
                curlen = 0;
            }
        }
        minlen = minlen > 0 ? Math.Min(curlen, minlen) : minlen;
        Console.WriteLine(minlen);
        */
        // Задача 3. Определить макс сумму подпоследовательности из чётных чисел
        int n = Convert.ToInt32(Console.ReadLine());
        int maxsum = 0;
        bool maxEmpty = true;
        int cursum = 0;
        bool curEmpty = true;

        for (int i = 0; i < n; i++)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            if (number % 2 == 0)
            {
                cursum += number;
                curEmpty = false;
            }
            else if (maxEmpty)
            {
                maxsum = cursum;
                cursum = 0;
                curEmpty = true;
            }
            else
            {
                maxsum = curEmpty ? maxsum : Math.Max(cursum, maxsum);
                cursum = 0;
                curEmpty = true;
            }
        }

        if (maxEmpty && curEmpty)
        {
            Console.WriteLine("Нет чётных");
        }
        else
        {
            maxsum = curEmpty ? maxsum : Math.Max(cursum, maxsum);
            Console.WriteLine(maxsum);
        }
    }
}