using System;

class Lab4
{
    public static void Main()
    {
        /* Дана последовательность положительных целых чисел, перевернуть чётные, нечётные убрать */
        do
        {
            int num = Convert.ToInt32(Console.ReadLine());
            if (num <= 0) break;
            int numCopy = 0;
            bool isOdd = true;
            while (num != 0)
            {
                if (num % 2 == 0)
                {
                    numCopy = numCopy * 10 + num % 10;
                    isOdd = false;
                }
                num /= 10;
            }
            Console.WriteLine(isOdd? "Нет чётных" : numCopy);
        } while (true);
    }
}
