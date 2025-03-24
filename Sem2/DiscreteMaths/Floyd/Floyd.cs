using System;

class Program
{
    static int[,] Floyd(int[,] graph)
    {
        int verticesCount = graph.GetLength(0);

        for (int k = 0; k < verticesCount; k++)
        {
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    if (graph[i, k] != int.MaxValue && graph[k, j] != int.MaxValue)
                    {
                        graph[i, j] = Math.Min(graph[i, k] + graph[k, j], graph[i, j]);
                    }
                }
            }
        }

        return graph;
    }

    static void Print(int[,] graph)
    {
        int verticesCount = graph.GetLength(0);

        for (int i = 0; i < verticesCount; i++)
        {
            for (int j = 0; j < verticesCount; j++)
            {
                Console.Write($"{graph[i,j]}\t");
            }

            Console.WriteLine();
        }   
    }

    static void Main()
    {
        int[,] graph = 
        {
            {0, 5, 10, int.MaxValue},
            {int.MaxValue, 0, 3, 13},
            {int.MaxValue, int.MaxValue, 0, 8},
            {7, 15, 20, 0}
        };

        Print(Floyd(graph));
    }
}