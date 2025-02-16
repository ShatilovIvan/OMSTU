using System;

class GoldFish
{
    public static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] words = new string[n];

        for (int i = 0; i < words.Length; i++)
        {
            string word = Console.ReadLine();
            if (word.Length > 15)
                return;

            words[i] = word;
        }

        int f = Convert.ToInt32(Console.ReadLine());
        if (f > 26 || f < 1)
            return;

        char[] firstLetters = new char[f];
        int[] firstLettersUsage = new int[f];

        for (int i = 0; i < f; i++)
        {
            string input = Console.ReadLine();
            firstLetters[i] = Convert.ToChar(input.Substring(0, 1));
            firstLettersUsage[i] = Convert.ToInt32(input.Substring(2));
        }

        int l = Convert.ToInt32(Console.ReadLine());
        if (l > 26 || l < 1)
            return;

        char[] lastLetters = new char[l];
        int[] lastLettersUsage = new int[l];

        for (int i = 0; i < f; i++)
        {
            string input = Console.ReadLine();
            lastLetters[i] = Convert.ToChar(input.Substring(0, 1));
            lastLettersUsage[i] = Convert.ToInt32(input.Substring(2));
        }

        int result = 0;

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < firstLetters.Length; j++)
            {
                if (words[i][0] != firstLetters[j])
                    continue;

                if (firstLettersUsage[j] < 1)
                    continue;

                for (int k = 0; k< lastLetters.Length; k++)
                {
                    if (words[i][words[i].Length-1] != lastLetters[j])
                        continue;

                    if (lastLettersUsage[j] < 1)
                        continue;

                    if (words[i][words[i].Length - 1] == lastLetters[j])
                    {
                        result++;
                        lastLettersUsage[k]--;
                        firstLettersUsage[j]--;
                    }
                }
            }
        }

        Console.WriteLine(result);
    }
}