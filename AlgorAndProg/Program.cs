using System;

class Soldiers
{
    static void Main()
    {
        Console.Write("Введите количество солдат: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int i = 1;
        while (i * 2 < n)
        {
            i *= 2;
        }
        int a;
        if (n - i <= i / 2) a = n - i;
        else a = i*2 - n;
        Console.WriteLine("Количество групп по три: " + a);
    }
}
