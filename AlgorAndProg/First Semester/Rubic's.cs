using System;
class Rubic
{
    static void ClockRot(ref int[] coords, int size, int axis, int layer)
    {
        string ind = "012".Remove(axis, 1);

        int xCopy = coords[int.Parse(ind[0].ToString())];
        coords[int.Parse(ind[0].ToString())] = coords[int.Parse(ind[1].ToString())];
        coords[int.Parse(ind[1].ToString())] = size + 1 - xCopy;
    }

    static void CounterClockRot(ref int[] coords, int size, int axis, int layer)
    {
        string ind = "012".Remove(axis, 1);

        int yCopy = coords[int.Parse(ind[1].ToString())];
        coords[int.Parse(ind[1].ToString())] = coords[int.Parse(ind[0].ToString())];
        coords[int.Parse(ind[0].ToString())] = size + 1 - yCopy;
    }

    static void Main()
    {
        string[] inputSizeTurns = Console.ReadLine().Split();
        int size = Convert.ToInt32(inputSizeTurns[0]);
        int turns = Convert.ToInt32(inputSizeTurns[1]);

        string[] inputCoords = Console.ReadLine().Split();
        int[] coords = new int[3];
        for (int i = 0; i < 3; i++) coords[i] = Convert.ToInt32(inputCoords[i]);

        for (int i = 0; i < turns; i++)
        {
            string[] turn = Console.ReadLine().Split();
            int axis = "XYZ".IndexOf(turn[0]);
            int layer = Convert.ToInt32(turn[1]);
            int direction = Convert.ToInt32(turn[2]);

            if (coords[axis] == layer)
            {
                if (direction == 1) ClockRot(ref coords, size, axis, layer);
                else CounterClockRot(ref coords, size, axis, layer);
            }
        }

        foreach (int i in coords) Console.Write(i + " ");
    }
}
