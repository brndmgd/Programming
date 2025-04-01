using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string brackets = "(){}[]";
        string input = Console.ReadLine();
        bool isWrong = false;
        Stack<char> brSequence = new Stack<char>();

        foreach (var i in input)
        {
            if (brackets.IndexOf(i) % 2 == 0)
            {
                brSequence.Push(i);
            }
            else if (brackets.Contains(i) && brackets.IndexOf(i) % 2 != 0)
            {
                bool notEmpty = brSequence.TryPop(out char curBr);
                int difference = brackets.IndexOf(i) - brackets.IndexOf(curBr);
                if (!notEmpty || difference != 1)
                {
                    isWrong = true;
                    break;
                }
            }
        }

        if (isWrong)
        {
            Console.WriteLine("Последовательность неверна");
        }
        else
        {
            Console.WriteLine("Последовательность верна");
        }
    }
}