using System;

class Program
{
    static int Djikstra(int[,] graph, int start, int finish)
    {
        int verticesCount = graph.GetLength(0);
        bool[] visited = new bool[verticesCount];
        int[] distance = new int[verticesCount];
        int currentVertex = start;

        for (int i = 0; i < verticesCount; i++)
        {
            visited[i] = false;
            distance[i] = int.MaxValue;
        }

        distance[start] = 0;

        for (int i = 0; i < verticesCount; i++)
        {
            int currentMin = int.MaxValue;

            for (int j = 0; j < verticesCount; j++)
            {
                if (!visited[j] && distance[j] < currentMin)
                {
                    currentMin = distance[j];
                    currentVertex = j;
                }
            }

            for (int j = 0; j < verticesCount; j++)
            {
                if (!visited[j] && graph[currentVertex, j] > 0)
                {
                    int newDistance = distance[currentVertex] + graph[currentVertex, j];
                    if (newDistance < distance[j])
                    {
                        distance[j] = newDistance;
                    }
                }
            }
            
            visited[currentVertex] = true;
        }

        return distance[finish];
    }
    static void Main()
    {
        int[,] graph = 
        {
            {0, 3, 6, 7},
            {0, 0, 1, 0}, 
            {0, 0, 0, 3}, 
            {0, 0, 0, 0} 
        };

        Console.WriteLine($"Наименьшее расстояние между вершинами 1 и 3 = {Djikstra(graph, 0, 2)}");
    }
}