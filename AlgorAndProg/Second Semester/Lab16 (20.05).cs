using System;

unsafe class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество строк:");
        int size = Convert.ToInt32(Console.ReadLine());
        char** text = stackalloc char*[size];
        string unique = "";

        Console.WriteLine("Введите текст");
        for (int i = 0; i < size; i++)
        {
            string line = Console.ReadLine();

            fixed (char* p = line)
            {
                text[i] = p;
                for (int j = 0; p[j] != 0; j++)
                {
                    if (!unique.Contains(p[j])) unique += p[j];
                }
            }
        }

        int** array2D = stackalloc int*[unique.Length];
        int count;
        for (int i = 0; i < unique.Length; i++)
        {
            count = 0;
            int* elem = stackalloc int[2];
            elem[0] = unique[i];
            for (int j = 0; j < size; j++)
            {
                for (int k = 0; text[j][k] != 0; k++)
                {
                    if (text[j][k] == unique[i]) count++;
                }
            }
            elem[1] = count;
            array2D[i] = elem;
        }

        Console.WriteLine("Количество вхождений каждого элемента в текст:");
        for (int i = 0; i < unique.Length; i++)
        {
            Console.WriteLine($"{(char)array2D[i][0]}: {array2D[i][1]}");
        }
    }
}