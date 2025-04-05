class Connectivity
{
    public static int FirstAlgorithm(int[,] graph)
    {
        int verticesCount = graph.GetLength(0);
        List<int> vertices = new();
        List<int> visitedVertices = new();
        List<List<int>> connectivityComponents = new();

        for (int i = 0; i < verticesCount; i++)
        {
            vertices.Add(i);
        }

        vertices.Remove(0);
        visitedVertices.Add(0);

        while (vertices.Count > 0)
        {
            for (int i = 0; i < visitedVertices.Count; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    if (graph[visitedVertices[i],j] == 0)
                    continue;

                    int currentVertex = j;
                    if (!visitedVertices.Contains(currentVertex))
                    {
                        visitedVertices.Add(currentVertex);
                        vertices.Remove(currentVertex);
                    }
                }
            }

            connectivityComponents.Add(visitedVertices);
            visitedVertices.Clear();

            if (vertices.Count != 0)
            {
                visitedVertices.Add(vertices[0]);
                vertices.Remove(vertices[0]);
            }
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