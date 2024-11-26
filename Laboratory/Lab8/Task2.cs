class Task2
{
    static void Main()
    {
        string input = Console.ReadLine();

        while (input != string.Empty)
        {
            int i = 0;
            int current = 0;
            int max = 0;

            while (i < input.Length)
            {
                if (i + 2 < input.Length)
                {
                    if (input[i] == 'a')
                    {
                        current++;
                        if (input[i+1] == 'b')
                        {
                            current++;
                            if (input[i+2] == 'c')
                            {
                                current++;
                                i += 3;
                            }
                            else
                            {
                                max = Math.Max(current, max);
                                current = 0;
                                i++;
                            }
                        }
                        else
                        {
                            max = Math.Max(current, max);
                            current = 0;
                            i++;
                        }
                    } 
                    else
                    {
                        max = Math.Max(current, max);
                        current = 0;
                        i++;
                    }
                }

                else if (i + 1 < input.Length)
                {
                    if (input[i] == 'a')
                    {
                        current++;
                        if (input[i + 1] == 'b')
                        {
                            current++;
                            i += 2;
                        }
                        else
                        {
                            max = Math.Max(current, max);
                            current = 0;
                            i++;
                        }
                    }
                    else
                    {
                        max = Math.Max(current, max);
                        current = 0;
                        i++;
                    }
                }

                else if (input[i] == 'a')
                {
                    current += 1;
                    i += 1;
                }

                else
                {
                    max = Math.Max(current, max);
                    current = 0;
                    i++;
                }
            }

            Console.WriteLine(Math.Max(current, max));
            input = Console.ReadLine();
        }
    }
}