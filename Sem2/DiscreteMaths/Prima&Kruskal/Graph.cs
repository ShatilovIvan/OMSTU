class Edge
{
    public int StartVertex { get; set; }
    public int FinishVertex { get; set; }
    public int Weight { get; set; }

    public Edge(int startVertex, int finishVertex, int weight)
    {
        StartVertex = startVertex;
        FinishVertex = finishVertex;
        Weight = weight;
    }

    public static List<Edge> ParseEdges(int[,] graph)
    {
        List<Edge> edges = new List<Edge>();
        int verticesCount = graph.GetLength(0);

        for (int i = 0; i < verticesCount; i++)
        {
            for (int j = i; j < verticesCount; j++)
            {
                if (graph[i,j] == 0)
                    continue;

                edges.Add(new Edge(i, j, graph[i,j]));
            }
        }

        return edges;
    }

    public static List<Edge> SortEdgesByWeight(List<Edge> edges)
    {
        List<Edge> edgesSorted = edges;

        Edge temp;
        for (int i = 0; i < edgesSorted.Count; i++)
        {
            for (int j = i + 1; j < edgesSorted.Count; j++)
            {
                if (edgesSorted[i].Weight > edgesSorted[j].Weight)
                {
                    temp = edgesSorted[i];
                    edgesSorted[i] = edgesSorted[j];
                    edgesSorted[j] = temp;
                }                   
            }            
        }

        return edgesSorted;
    }  
}