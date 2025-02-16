using System;

class HelloWorld
{
    static void Main()
    {
        /* Дана последовательность элементов в количестве n не менее 3. Выполнить задачи:*/
        /* Задача 1. Определить количество элеменов меньших нуля */
        /*
        int n = Convert.ToInt32(Console.ReadLine());
        int k = 0;
        for (int i = 0; i < n; i++)
        {
            int readResult = Convert.ToInt32(Console.ReadLine());
            if (readResult < 0)
            {
                k++;
            }
        }
        */
        /* Задача 2. Определить среди элементов второй максимальный элемент */
        /*
        int n = Convert.ToInt32(Console.ReadLine());
        int firstMax = 0, secondMax = 0;
        for (int i = 0; i < n; i++)
        {
            int readResult = Convert.ToInt32(Console.ReadLine());
            if (i == 0)
            {
                firstMax = readResult;
            }
            else if (readResult >= firstMax)
            {
                secondMax = firstMax;
                firstMax = readResult;
            }
            else if (readResult > secondMax)
            {
                secondMax = readResult;
            }
        }
        Console.WriteLine(secondMax);
        */
        /* Задача 3. Определить количество элементов являющиеся локальными минимумами */
        /*
        int n = Convert.ToInt32(Console.ReadLine());
        int k = 0;
        int prev1Result = 0, prev2Result = 0;
        for (int i = 0; i < n; i++)
        {
            int readResult = Convert.ToInt32(Console.ReadLine());
            if (i >= 2)
            {
                if ((prev1Result < prev2Result) && (prev1Result < readResult))
                {
                        k++;
                }
            }
            prev2Result = prev1Result;
            prev1Result = readResult;
        }
        Console.WriteLine(k);
        */
    }
}
