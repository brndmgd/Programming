using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine().Trim();
        string[] inList = input.Split();
        HashSet<string> unique = inList.ToHashSet();
        Dictionary<string, int> quantity = new Dictionary<string, int>();
        foreach (var i in inList)
        {
            if (!quantity.Keys.Contains(i))
            {
                quantity[i] = 1;
            }
            else
            {
                quantity[i]++;
            }
        }
        
        foreach (var i in unique)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
        foreach (var i in quantity.Keys)
        {
            Console.Write($"\"{i}\":{quantity[i]} ");
        }
    }
}
