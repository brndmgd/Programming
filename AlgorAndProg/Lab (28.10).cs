/* Двумерный массив NxM. 1) Необходимо переставить строку с минимальным элементом со строкой с максимальным элементом
 * (минимум и максимум только один)
 * 2) определить в массиве точки минимакса (макс строки мин столбца или наоборот)
 * 3) пары номеров строк, состоящих из одинаковых элементов (сортировать элементы в строках нельзя)
 */
using System;

class Lab281024
{
    public static void Main()
    {
        // 1 Задание
        /*
        int n = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());
        int[,] ar = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ar[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        
        PrintAr(ar);

        int maxPos = 0, minPos = 0;
        int maxAr = ar[0, 0], minAr = ar[0, 0];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (ar[i, j] > maxAr)
                {
                    maxAr = ar[i,j];
                    maxPos = i;
                }
                else if (ar[i, j] < minAr)
                {
                    minAr = ar[i, j];
                    minPos = i;
                }
            }
        }

        int temp;
        for (int i = 0; i < m; i++)
        {
            temp = ar[maxPos, i];
            ar[maxPos, i] = ar[minPos, i];
            ar[minPos, i] = temp;
        }

        PrintAr(ar);
        */
        // Задание 2.
        /*
        int n = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());
        int[,] ar = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ar[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        int c = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int lineCh = InLine(ar, i, ar[i, j]);
                int columnCh = InColumn(ar, j, ar[i, j]);
                if (lineCh != columnCh && lineCh != 0 && columnCh != 0)
                {
                    Console.WriteLine($"Минимакс {ar[i, j]} на позиции ({i},{j})");
                }
            }
        }
        */
        // задание 3
        int n = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());
        int[,] ar = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ar[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }


        int[,] check = new int[n, 3];
        for (int i = 0; i < n; i++)
        {
            check[i, 1] = 1;
            for (int j = 0; j < m; j++)
            {
                check[i, 0] += ar[i, j];
                check[i, 1] *= ar[i, j];
                if (ar[i, j] == 0) check[i, 2] += 1;
            }
        }
        
        for (int i = 0; i < n; i++)
        {
            for (int j = i+1; j < n; j++)
            {
                if (check[i, 0] == check[j, 0] && check[i, 1] == check[j, 1] && check[i, 2] == check[j, 2])
                {
                    Console.WriteLine($"Пара равных строк: {i}, {j}");
                }
            }
        }
    }
    
    static void PrintAr(int[,] ar)
    {
        for (int i = 0; i < ar.GetLength(0); i++)
        {
            for (int j = 0; j < ar.GetLength(1); j++)
            {
                Console.Write(ar[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    
    static int InLine(int[,] ar, int line, int elem)
    {
        bool max = true;
        bool min = true;
        for (int i = 0; i < ar.GetLength(1); i++)
        {
            if (elem > ar[line, i])
            {
                min = false;
            }
            if (elem < ar[line, i])
            {
                max = false;
            }
        }
        if (max) return 1;
        else if (min) return -1;
        else return 0;
    }
    
    static int InColumn(int[,] ar, int column, int elem)
    {
        bool max = true;
        bool min = true;
        for (int i = 0; i < ar.GetLength(0); i++)
        {
            if (elem > ar[i, column])
            {
                min = false;
            }
            if (elem < ar[i, column])
            {
                max = false;
            }
        }
        if (max) return 1;
        else if (min) return -1;
        else return 0;
    }
}
