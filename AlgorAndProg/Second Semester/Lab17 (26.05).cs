using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

unsafe class Node
{
    public int ID { get; set; }
    public string Name { get; set; }
    public Node* Left { get; set; }
    public Node* Right { get; set; }

    public Node(int id, string name)
    {
        ID = id;
        Name = name;
        Left = null;
        Right = null;
    }
}

unsafe class Tree
{
    public Node* Root { get; set; }

    public void Add(int id, string name)
    {
        Node* new_node = (Node*)Marshal.AllocHGlobal(sizeof(Node));
        *new_node = new Node(id, name);

        if (Root == null)
        {
            Root = new_node;
            return;
        }

        Node* cur_node = Root;

        while (true)
        {
            if (cur_node->ID > new_node->ID)
        {
            if (cur_node->Left == null)
            {
                cur_node->Left = new_node;
                return;
            }
            cur_node = cur_node->Left;
        }

        else
        {
            if (cur_node->Right == null)
            {
                cur_node->Right = new_node;
                return;
            }
            cur_node = cur_node->Right;
        }
        }
    }
}

unsafe class Program
{
    static void PrintTree(Node* node, int level)
    {
        if (node != null)
        {
            PrintTree(node->Left, level+1);
            for (int i = 0; i < level; i++) Console.Write("\t");
            Console.WriteLine($"ID: {node->ID}, Name: {node->Name}");
            PrintTree(node->Right, level+1);
        }
    }

    static void Main()
    {
        Tree tree = new Tree();
        Console.WriteLine("Введите пользователей:");
        string input = Console.ReadLine();
        Node cur_node;
        while (input != "-1")
        {
            string[] ar = input.Split();
            tree.Add(int.Parse(ar[0]), ar[1]);
            input = Console.ReadLine();
        }

        PrintTree(tree.Root, 0);
    }
}