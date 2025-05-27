using System;
using System.Collections.Generic;

class Program
{
    private static int N;
    private static int INF = int.MaxValue / 2; 

    static void Main()
    {
        int[,] matrix =
        {
            { INF, 10, 8, 3 },
            { 10, INF, 1, 7 },
            { 8, 1, INF, 4 },
            { 3, 7, 4, INF }
        };

        Solve(matrix);
    }

    static int ReduceMatrix(ref int[,] matrix)
    {
        int cost = 0;

        for (int i = 0; i < N; i++)
        {
            int min = INF;
            for (int j = 0; j < N; j++)
                if (matrix[i, j] < min)
                    min = matrix[i, j];

            if (min != INF && min > 0)
            {
                cost += min;
                for (int j = 0; j < N; j++)
                    if (matrix[i, j] != INF)
                        matrix[i, j] -= min;
            }
        }

        for (int j = 0; j < N; j++)
        {
            int min = INF;
            for (int i = 0; i < N; i++)
                if (matrix[i, j] < min)
                    min = matrix[i, j];

            if (min != INF && min > 0)
            {
                cost += min;
                for (int i = 0; i < N; i++)
                    if (matrix[i, j] != INF)
                        matrix[i, j] -= min;
            }
        }

        return cost;
    }
    static int[,] CopyMatrix(int[,] original)
    {
        int n = original.GetLength(0);
        int[,] copy = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                copy[i, j] = original[i, j];
        return copy;
    }
    static (int row, int col, int penalty) CalculatePenalty(int[,] matrix)
    {
        int maxPenalty = -1;
        int row = -1, col = -1;

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (matrix[i, j] == 0)
                {
                    int rMin = INF;
                    for (int k = 0; k < N; k++)
                        if (k != j && matrix[i, k] < rMin)
                            rMin = matrix[i, k];

                    int cMin = INF;
                    for (int k = 0; k < N; k++)
                        if (k != i && matrix[k, j] < cMin)
                            cMin = matrix[k, j];

                    int penalty = rMin + cMin;
                    if (penalty > maxPenalty)
                    {
                        maxPenalty = penalty;
                        row = i;
                        col = j;
                    }
                }
            }
        }

        return (row, col, maxPenalty);
    }

    static void Solve(int[,] initialMatrix)
    {
        N = initialMatrix.GetLength(0);

        int[,] startMatrix = CopyMatrix(initialMatrix);
        int startBound = ReduceMatrix(ref startMatrix);

        var queue = new Queue<(int[,] Matrix, int LowerBound, int Level)>();
        queue.Enqueue((startMatrix, startBound, 0));

        while (queue.Count > 0)
        {
            var (matrix, bound, level) = queue.Dequeue();

            if (level == N - 1)
            {
                Console.WriteLine("Минимальная стоимость: " + bound);
                return;
            }

            var (i, j, penalty) = CalculatePenalty(matrix);

            int[,] newMatrix = CopyMatrix(matrix);
            newMatrix[i, j] = INF;

            int newBound = bound + penalty;
            int newLevel = level + 1;

            queue.Enqueue((newMatrix, newBound, newLevel));
        }
    }
}
