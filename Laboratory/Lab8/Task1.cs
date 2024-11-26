using System;

class Task1
{
    static void Main()
    {
        string input = Console.ReadLine();
        int result = 0;

        while (input != string.Empty)
        {
            int i = 0;

            while (i < input.Length)
            {
                if (i + 2 < input.Length && ((input[i] == 'a' && input[i + 2] == 'b') || (input[i] == 'A' && input[i + 2] == 'b')))
                {
                    result++;
                    break;
                }

                if (i + 1 < input.Length)
                    i++;
                else
                    break;

            }

            input = Console.ReadLine();
        }

        Console.WriteLine(result);
    }
}