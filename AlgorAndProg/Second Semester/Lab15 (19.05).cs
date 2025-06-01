using System;

class Program
{
    unsafe static void Main()
    {
        Console.WriteLine("Введите размер массива");
        int size = Convert.ToInt32(Console.ReadLine());
        int* array = stackalloc int[size];

        Console.WriteLine("Введите числа");
        for (int i = 0; i < size; i++)
        {
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        for (int i = 0; array[i] != 0; i++)
        {
            if (PalindromeCheck(array[i].ToString()))
                Console.WriteLine($"Число {array[i]} является палиндромом");
            else
                Console.WriteLine($"Число {array[i]} не являтся палиндромом");
        }
    }

    static bool PalindromeCheck(string number)
    {
        for (int i = 0; i < number.Length / 2; i++)
        {
            if (number[i] != number[number.Length - 1 - i]) return false;
        }

        return true;
    }
}