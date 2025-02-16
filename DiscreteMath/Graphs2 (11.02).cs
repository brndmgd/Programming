using System;

class Program
{
    static void Main()
    {
        string[] inputMatrix = File.ReadAllLines("input.txt");
        int size = inputMatrix.Length;
        int[,] linkMatrix = new int[size, size];
        int[] components = new int[size];

        for (int i = 1; i < size + 1; i++)
        {
            string[] line = inputMatrix[i - 1].Split();
            for (int j = 0; j < size; j++)
            {
                linkMatrix[i - 1, j] = int.Parse(line[j]);
            }
            components[i-1] = i;
        }

        int sameCounter;
        
        do
        {
            sameCounter = 0;
            int k = 1;

            for (int i = 1; i < size; i++)
            {
                bool changed = false;
                for (int j = 0; j < size; j++)
                {
                    if (linkMatrix[i, j] == 1 && components[i] > components[j])
                    {
                        changed = true;
                        components[i] = components[j];
                    }
                }

                if (!changed)
                {
                    sameCounter++;
                    if (components[i] > k && i != k)
                    {
                        k += 1;
                        components[i] = k;
                    }
                }
            }
        } while(sameCounter != 7);

        HashSet<int> differentComponents = components.ToHashSet();
        Console.WriteLine(differentComponents.Count);
    }
}
