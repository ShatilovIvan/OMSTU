using System;
using System.Text.RegularExpressions;

class Algorithms
{
    public static int Kruskal(int[,] graph)
    {
        List<Edge> edges = Edge.ParseEdges(graph);
        edges = Edge.SortEdgesByWeight(edges);
        int verticesCount = graph.GetLength(0);
        List<Edge> minimalTree = new List<Edge>();
        int currentWeight = 0;

        int[] groups = new int[verticesCount];
        for (int i = 0; i < verticesCount; i++)
        {
            groups[i] = i;
        }

        for (int i = 0; minimalTree.Count != (verticesCount - 1); i++)
        {
            if (groups[edges[i].StartVertex] == groups[edges[i].FinishVertex])
                continue;

            minimalTree.Add(edges[i]);
            
            for (int j = 0; j < groups.Count(); j++)
            {
                if (groups[edges[j].FinishVertex] == groups[edges[i].FinishVertex])
                    groups[edges[j].FinishVertex] = Math.Min(groups[edges[i].FinishVertex], groups[edges[i].StartVertex]);

                if (groups[edges[j].StartVertex] == groups[edges[i].StartVertex])
                    groups[edges[j].StartVertex] = Math.Min(groups[edges[i].FinishVertex], groups[edges[i].StartVertex]);
            }
            
            currentWeight += edges[i].Weight;
        }

        return currentWeight;
    }

    public static int Prima(int[,] graph)
    {
        int currentWeight = 0;
        List<int> vertices = new List<int>();
        List<int> visitedVertices = new List<int>();
        List<Edge> edges = Edge.ParseEdges(graph);

        for (int i = 0; i < graph.GetLength(0); i++)
        {
            vertices.Add(i);
        }
        
        visitedVertices.Add(vertices[0]);
        vertices.RemoveAt(0);
        
        
        while (vertices.Count > 0)
        {
            Edge minEdge = null;
            int minWeight = int.MaxValue;

            foreach (var edge in edges)
            {
                if ((visitedVertices.Contains(edge.StartVertex) && vertices.Contains(edge.FinishVertex)) ||
                    (visitedVertices.Contains(edge.FinishVertex) && vertices.Contains(edge.StartVertex)))
                {
                    if (edge.Weight < minWeight)
                    {
                        minWeight = edge.Weight;
                        minEdge = edge;
                    }
                }
            }

            if (minEdge != null)
            {
                currentWeight += minWeight;

                if (vertices.Contains(minEdge.StartVertex))
                {
                    visitedVertices.Add(minEdge.StartVertex);
                    vertices.Remove(minEdge.StartVertex);
                }
                else if (vertices.Contains(minEdge.FinishVertex))
                {
                    visitedVertices.Add(minEdge.FinishVertex);
                    vertices.Remove(minEdge.FinishVertex);
                }
            }
        }
        
        return currentWeight;
    }
}
