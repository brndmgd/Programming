using System;

class Program
{
    static void Main()
    {
        string[] inputMatrix = File.ReadAllLines("input.txt");
        int size = inputMatrix.Length;
        int[,] linkMatrix = new int[size, size];
        List<int> notVisited = new List<int>();
        List<int[]> linkedComponents = new List<int[]>();

        for (int i = 1; i < size + 1; i++)
        {
            string[] line = inputMatrix[i-1].Split();
            for (int j = 0; j < size; j++)
            {
                linkMatrix[i-1, j] = int.Parse(line[j]);
            }
            notVisited.Add(i);
        }
        
        while (notVisited.Count > 0)
        {
            List<int> curQueue = new List<int>();
            curQueue.Add(notVisited[0]);
            notVisited.RemoveAt(0);
            int k = 0;

            while (k < curQueue.Count)
            {
                for (int i = 0; i < notVisited.Count; i++)
                {
                    if (linkMatrix[curQueue[k]-1, notVisited[i]-1] == 1)
                    {
                        curQueue.Add(notVisited[i]);
                        notVisited.Remove(notVisited[i]);
                    }
                }
                k++;
            }

            linkedComponents.Add(curQueue.ToArray());
        }

        foreach (int[] i in linkedComponents)
        {
            foreach (int j in i)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
    }
}
