using System;

class Connectivity
{
    public static int FirstAlgorithm(int[,] graph)
    {
        int verticesCount = graph.GetLength(0);
        List<int> vertices = new List<int>();
        List<List<int>> connectivityComponents = new List<List<int>>();

        for (int i = 0; i < verticesCount; i++)
        {
            vertices.Add(i);
        }

        while (vertices.Count > 0)
        {
            List<int> visitedVertices = new List<int>();
            Queue<int> queue = new Queue<int>();
            
            int startVertex = vertices[0];
            queue.Enqueue(startVertex);
            visitedVertices.Add(startVertex);
            vertices.Remove(startVertex);

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();
                
                for (int j = 0; j < verticesCount; j++)
                {
                    if (graph[currentVertex, j] != 0 && !visitedVertices.Contains(j))
                    {
                        visitedVertices.Add(j);
                        vertices.Remove(j);
                        queue.Enqueue(j);
                    }
                }
            }

            connectivityComponents.Add(visitedVertices);
        }

        return connectivityComponents.Count;
    }

    public static int SecondAlgorithm(int[,] graph)
    {
        int verticesCount = graph.GetLength(0);
        int[] parent = new int[verticesCount];

        for (int i = 0; i < verticesCount; i++)
            parent[i] = i;

        for (int i = 0; i < verticesCount; i++)
        {
            for (int j = 0; j < verticesCount; j++)
            {
                if (graph[i, j] != 0)
                {
                    Union(parent, i, j);
                }
            }
        }

        HashSet<int> connectivityComponents = new HashSet<int>();
        for (int i = 0; i < verticesCount; i++)
        {
            connectivityComponents.Add(Find(parent, i));
        }

        return connectivityComponents.Count;
    }

    private static int Find(int[] parent, int vertex)
    {
        if (parent[vertex] != vertex)
        {
            parent[vertex] = Find(parent, parent[vertex]); 
        }
        return parent[vertex];
    }

    private static void Union(int[] parent, int x, int y)
    {
        int rootX = Find(parent, x);
        int rootY = Find(parent, y);
        if (rootX != rootY)
        {
            parent[rootY] = rootX; 
        }
    }
}
class Program
{
    static void Main()
    {
        int[,] graph = 
        {
            {0, 1, 0, 0, 0, 0, 0, 1}, 
            {1, 0, 0, 0, 0, 0, 0, 1}, 
            {0, 0, 0, 1, 0, 1, 0, 0}, 
            {0, 0, 1, 0, 0, 1, 0, 0}, 
            {0, 0, 0, 0, 0, 0, 0, 1}, 
            {0, 0, 1, 1, 0, 0, 0, 0}, 
            {0, 0, 0, 0, 0, 0, 0, 1}, 
            {1, 1, 0, 0, 1, 0, 1, 0}
        };


        Console.WriteLine($"Число компонент связности = {Connectivity.FirstAlgorithm(graph)}");
        Console.WriteLine($"Число компонент связности = {Connectivity.SecondAlgorithm(graph)}");
    }
}
