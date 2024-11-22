/* Зубчатый массив. Необходимо с помощью функции организовать ввод каждой строки массива (размерность строк может
 * быть различной)
 * определить номера строк, элементы в которых образуют равномерно убывающую последовательность
*/
using System;

class Lab081124
{
    static int[] ConstructLine(int elem)
    {
        int[] output = new int[elem];
        for (int i = 0; i < elem; i++)
        {
            output[i] = Convert.ToInt32(Console.ReadLine());
        }
        return output;
    }

    public static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[][] ar = new int[n][];
        for (int i = 0; i < n; i++)
        {
            ar[i] = ConstructLine(Convert.ToInt32(Console.ReadLine()));
        }

        for (int i = 0; i < n; i++)
        {
            if (ar[i].Length == 1) continue;
            int diff = ar[i][0] - ar[i][1];
            if (diff <= 0) continue;
            bool flag = true;
            for (int j = 0; j < ar[i].Length-1; j++)
            {
                int check = ar[i][j] - ar[i][j+1];
                if (check != diff)
                {
                    flag = false;
                    break;
                }
            }
            if (flag) Console.WriteLine(i);
        }

        /*
        static int[] ConstructLine(string input)
        {
            string[] inputArray = input.Split(' ');
            int[] output = new int[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
            {
                output[i] = Convert.ToInt32(inputArray[i]);
            }
            return output;
        }
        */
    }
}