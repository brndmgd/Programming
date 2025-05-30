using System;

class OutOfRangeException : Exception
{
    public OutOfRangeException() : base() { }
}

class Something<T>
{
    public T[] Array;
    int Tail;
    int Size;

    public Something(int size)
    {
        Array = new T[size];
        Tail = 0;
        Size = size;
    }

    public void Add(T elem)
    {
        if (Tail >= Size || Tail < 0) throw new OutOfRangeException();
        Array[Tail] = elem;
        Tail++;
    }

    public void Remove(int index)
    {
        if (index >= Size || index < 0) throw new OutOfRangeException();
        for (int i = 0; i < Size - 1; i++)
        {
            if (i >= index)
            {
                Array[i] = Array[i + 1];
            }
        }
        Tail--;
    }

    public void Print(int index)
    {
        if (index >= Size || index < 0) throw new OutOfRangeException();
        Console.WriteLine(Array[index]);
    }

    public void PrintAll()
    {
        for (int i = 0; i < Size; i++)
        {
            Console.Write(Array[i] + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Something<int> ar = new Something<int>(5);
        ar.Add(5);
        ar.Add(100);
        ar.Add(50);
        ar.Add(30);
        ar.Add(40);
        ar.PrintAll();
        ar.Print(3);
        ar.Remove(3);
        ar.Print(3);
    }
}