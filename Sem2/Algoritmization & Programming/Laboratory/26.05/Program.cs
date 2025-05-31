using System;
using System.Runtime.InteropServices;

public unsafe struct Node
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Node* Left { get; set; }
    public Node* Right { get; set; }

    public Node(int id, string name)
    {
        Id = id;
        Name = name;
        Left = null;
        Right = null;
    }
}

public unsafe class Tree
{
    public Node* Root;

    public void Insert(int id, string name)
    {
        if (Root == null)
        {
            Root = CreateNode(id, name);
            return;
        }

        Node* current = Root;

        while (true)
        {
            if (id < current->Id)
            {
                if (current->Left == null)
                {
                    current->Left = CreateNode(id, name);
                    break;
                }
                current = current->Left;
            }
            else
            {
                if (current->Right == null)
                {
                    current->Right = CreateNode(id, name);
                    break;
                }
                current = current->Right;
            }
        }
    }

    private Node* CreateNode(int id, string name)
    {
        Node* node = (Node*)Marshal.AllocHGlobal(sizeof(Node));
        node->Id = id;
        node->Name = name;
        node->Left = null;
        node->Right = null;
        return node;
    }

    public void Free()
    {
        FreeNode(Root);
        Root = null;
    }

    private void FreeNode(Node* node)
    {
        if (node == null) return;

        FreeNode(node->Left);
        FreeNode(node->Right);
        Marshal.FreeHGlobal((IntPtr)node);
    }

    public void Print(Node* node)
    {
        if (node != null)
        {
            Print(node->Left);
            Console.WriteLine($"ID: {node->Id}, Name: {node->Name}");
            Print(node->Right);
        }
    }
}

public class Program
{
    public static unsafe void Main()
    {
        Tree tree = new Tree();
        
        tree.Insert(5, "Object 5");
        tree.Insert(3, "Object 3");
        tree.Insert(7, "Object 7");
        tree.Insert(2, "Object 2");
        tree.Insert(4, "Object 4");
        tree.Insert(6, "Object 6");
        tree.Insert(8, "Object 8");
        
        tree.Print(tree.Root);
        tree.Free();
    }
}
