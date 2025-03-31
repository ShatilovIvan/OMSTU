using System;
using System.Collections;

class Program
{

public static void FordBellman(int[,] graph, int start)
{
    int INF = int.MaxValue / 2;

    int verticesCount = graph.GetLength(0);
    int[] distances = new int[verticesCount];
    
    for (int i = 0; i < verticesCount; i++)
        distances[i] = INF;

    distances[start] = 0;

    for (int k = 1; k < verticesCount; k++)
    {
        for (int i = 0; i < verticesCount; i++)
        {
            for (int j = 0; j < verticesCount; j++)
            {
                if (graph[i, j] != 0 && distances[i] != INF && 
                        distances[i] + graph[i, j] < distances[j])
                    {
                        distances[j] = distances[i] + graph[i, j];
                    }
            }
        }
    }

    foreach(int v in distances)
        Console.Write($"{v}\t");
}

static void Main()
    {
        int[,] graph = 
        {
            {0, 2, 0, 19, 25}, 
            {2, 0, 6, 14, 0}, 
            {21, 6, 0, 1, 13}, 
            {0, 6, 1, 0, 2}, 
            {7, 11, 6, 2, 0} 
        };

        FordBellman(graph, 0);
    }
}
