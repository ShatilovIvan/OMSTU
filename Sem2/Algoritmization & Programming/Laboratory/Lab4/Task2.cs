using System;

class Task2
{
    static void Main()
    {
        List<string> list = Console.ReadLine().Split().ToList<string>();
        HashSet<string> set = list.ToHashSet();
        
        foreach(string str in set)
        {
            Console.Write($"{str} ");
        }

        Console.WriteLine("\n");

        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        foreach(string str in list)
        {
            if (!dictionary.Keys.Contains(str))
                dictionary[str] = 1;

            else
                dictionary[str]++;
        }

        foreach(string str in dictionary.Keys)
        {
            Console.Write($"\"{str}\" - {dictionary[str]}; ");
        }

        return;
    }
}