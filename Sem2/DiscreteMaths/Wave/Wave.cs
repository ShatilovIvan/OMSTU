using System;

class Program
{
    public static void Wave(string[,] map)
    {
        int rows = map.GetLength(0);
        int cols = map.GetLength(1);
        
        for (int step = 0; step < rows * cols; step++)
        {
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    int i;
                    
                    bool t = int.TryParse(map[x, y], out i);

                    if (t && i == step)
                    {
                        if (map[x + 1, y] != "x")
                        {
                            if (map[x + 1, y] == "e")
                            {
                                Console.WriteLine($"Путь: {step + 1}");
                                return;
                            }

                            if (map[x + 1, y] == "-")
                            {
                                int a = step + 1;
                                map[x + 1, y] = a.ToString();
                            }
                        }

                        if (map[x - 1, y] != "x")
                        {
                            if (map[x - 1, y] == "e")
                            {
                                Console.WriteLine($"Путь: {step + 1}");
                                return;
                            }

                            if (map[x - 1, y] == "-")
                            {
                                int a = step + 1;
                                map[x - 1, y] = a.ToString();
                            }
                        }

                        if (map[x, y + 1] != "x")
                        {
                            if (map[x, y + 1] == "e")
                            {
                                Console.WriteLine($"Путь: {step + 1}");
                                return;
                            }

                            if (map[x, y + 1] == "-")
                            {
                                int a = step + 1;
                                map[x, y + 1] = a.ToString();
                            }
                        }

                        if (map[x, y - 1] != "x")
                        {
                            if (map[x, y - 1] == "e")
                            {
                                Console.WriteLine($"Путь: {step + 1}");
                                return;
                            }

                            if (map[x, y - 1] == "-")
                            {
                                int a = step + 1;
                                map[x, y - 1] = a.ToString();
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine("Путь не существует");
    }
    public static void Main(string[] args)
    {
        string[,] map =
        {
            { "x", "x", "x", "x", "x", "x", "x" },
            { "x", "-", "-", "-", "x", "x", "x" },
            { "x", "-", "x", "-", "-", "-", "x" },
            { "x", "-", "x", "-", "x", "-", "x" },
            { "x", "-", "0", "-", "x", "e", "x" },
            { "x", "-", "-", "-", "x", "-", "x" },
            { "x", "x", "x", "x", "x", "x", "x" }
        };
        
        Wave(map);
    }
}