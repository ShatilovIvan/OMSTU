using System;
using System.Collections.Generic;

unsafe class Program
{
    static void Main()
    {
        string input = @"apple
                        lenovo
                        lenovo
                        asus
                        msi
                        apple
                        apple";

        string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        int maxPossibleSize = lines.Length;
        int* counts = stackalloc int[maxPossibleSize];
        char** stringPointers = stackalloc char*[maxPossibleSize];
        int* stringLengths = stackalloc int[maxPossibleSize];
        int uniqueCount = 0;

        fixed (char* pInput = input)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                bool found = false;

                for (int j = 0; j < uniqueCount; j++)
                {
                    bool match = true;
                    if (stringLengths[j] != line.Length)
                    {
                        match = false;
                    }
                    else
                    {
                        for (int k = 0; k < line.Length; k++)
                        {
                            if (stringPointers[j][k] != line[k])
                            {
                                match = false;
                                break;
                            }
                        }
                    }

                    if (match)
                    {
                        counts[j]++;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    fixed (char* pLine = line)
                    {
                        stringPointers[uniqueCount] = pLine;
                        stringLengths[uniqueCount] = line.Length;
                        counts[uniqueCount] = 1;
                        uniqueCount++;
                    }
                }
            }
        }

        string[][] finalResult = new string[uniqueCount][];
        for (int i = 0; i < uniqueCount; i++)
        {
            finalResult[i] = new string[2];
            finalResult[i][0] = new string(stringPointers[i], 0, stringLengths[i]);
            finalResult[i][1] = counts[i].ToString();
        }

        foreach (var pair in finalResult)
        {
            Console.WriteLine($"{pair[0]}: {pair[1]}");
        }
    }
}
