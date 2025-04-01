using System;
using System.Collections.Generic;

class Phone
{
    string Number;
    public string Provider { get; }

    public Phone(string number, string provider)
    {
        Number = number;
        Provider = provider;
    }
}

class Program
{
    static void Main()
    {
        List<Phone> phones = new List<Phone>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "0") 
                break;

            string[] arInput = input.Split();
            Phone curPhone = new Phone(arInput[0], arInput[1]);
            phones.Add(curPhone);
        }

        Dictionary<string, int> providers = new Dictionary<string, int>();
        foreach (var i in phones)
        {
            if (providers.Keys.Contains(i.Provider))
                providers[i.Provider]++;

            else
                providers[i.Provider] = 1;
        }

        int maxProvider = providers.Values.Max();
        foreach (var i in providers)
        {
            if (i.Value == maxProvider)
                Console.WriteLine(i.Key);
        }
    }
}