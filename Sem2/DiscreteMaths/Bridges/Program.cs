using System;
class Program
{
    static void Bridges(int[,] graph)
    {
        int verticesCount = graph.GetLength(0);
        int connectivityComponents = Connectivity.SecondAlgorithm(graph);
        List<Edge> bridges = new();

        for (int i = 0; i < verticesCount; i++)
        {
            for (int j = i; j < verticesCount; j++)
            {
                if (graph[i, j] == 0)
                    continue;

                int[,] newGraph = (int[,])graph.Clone();
                newGraph[i, j] = 0;
                newGraph[j, i] = 0;
                int newConnectivityCount = Connectivity.SecondAlgorithm(newGraph);

                if (connectivityComponents != newConnectivityCount)
                {
                    Edge bridge = new Edge(i, j, 1);
                    bridges.Add(bridge);
                }
            }
        }

        if (bridges.Count == 0)
        {
            Console.WriteLine("Мостов нет!");
            return;
        }

        foreach(Edge bridge in bridges)
        {
            Console.WriteLine($"Ребро {bridge.StartVertex+1}-{bridge.FinishVertex+1} - мост!");
        }
        

    }
    static void Main()
    {
        int[,] graph = 
        {
            {0, 1, 0, 0, 0, 0, 0, 1}, 
            {1, 0, 0, 0, 0, 0, 0, 1}, 
            {0, 0, 0, 1, 1, 1, 0, 0}, 
            {0, 0, 1, 0, 0, 1, 0, 0}, 
            {0, 0, 1, 0, 0, 0, 0, 1}, 
            {0, 0, 1, 1, 0, 0, 0, 0}, 
            {0, 0, 0, 0, 0, 0, 0, 1}, 
            {1, 1, 0, 0, 1, 0, 1, 0}, 
        };

        Bridges(graph);
    }
}