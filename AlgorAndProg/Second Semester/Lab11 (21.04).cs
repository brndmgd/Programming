using System;
using System.IO;

class Program
{
    static void Main()
    {
        string[] input = File.ReadAllLines("input.txt");
        File.Create("output.txt");
        List<string> correctLines = new List<string>();
        foreach (var line in input) {
            string number = "";
            foreach (var c in line) {
                if (char.IsDigit(c)) {
                    number += c;
                }
                else if (int.Parse(number) % 2 == 0) {
                    correctLines.Add(line);
                    break;
                }
                else {
                    number = "";
                }
            }
        }
        File.WriteAllLines("output.txt", correctLines);
    }
}
