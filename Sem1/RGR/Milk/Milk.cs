using System;

class Milk
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int firma = 0;
        float min = float.MaxValue;

        if (n < 1 || n > 100)
            return;

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            int x1 = int.Parse(input[0]);
            int y1 = int.Parse(input[1]);
            int z1 = int.Parse(input[2]);
            int x2 = int.Parse(input[3]);
            int y2 = int.Parse(input[4]);
            int z2 = int.Parse(input[5]);
            float c1 = float.Parse(input[6]);
            float c2 = float.Parse(input[7]);

            float v1 = x1 * y1 * z1;
            float v2 = x2 * y2 * z2;

            float s1 = 2 * (x1 * y1 + y1 * z1 + x1 * z1);
            float s2 = 2 * (x2 * y2 + y2 * z2 + x2 * z2);

            float current = (s1 * c2 - s2 * c1) / (v2 * s1 - s2 * v1) * 1000;

            if (current < min)
            {
                min = current;
                firma = i;
            }
        }

        Console.WriteLine($"{firma + 1} {Math.Round(min, 2)}");
    }
}