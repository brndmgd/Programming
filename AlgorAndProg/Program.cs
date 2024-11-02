using System;

class Devil
{
    public static void Main()
    {
        int maxN = Convert.ToInt32(Console.ReadLine());
        double c = 0;
        int maxNc = maxN;
        int twoC = 2;
        while (maxNc > 0)
        {
            maxNc /= 2;
            c += maxN / (twoC-1);
            twoC *= 2;
        }
        Console.WriteLine(c);
    }
}