using System;

    class Task2
    {
        static void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int curSum = 0;
            int maxSum = 0;

            for (int i = 0; i < n; i++)
            {
                int num = Convert.ToInt32(Console.ReadLine());

                if (num %2 == 0)
                {
                    curSum += num;

                    if (i == n - 1)
                    {
                        if (curSum > maxSum)
                        {
                            maxSum = curSum;
                        }
                    }
                }

                else
                {
                    if (curSum > maxSum && curSum != 0)
                        maxSum = curSum;

                    if (curSum < 0 && maxSum == 0)
                    {
                        maxSum = curSum;
                    }

                    curSum = 0;
                }
            }

            Console.WriteLine($"Максимальная сумма подпоследовательности четных чисел: {maxSum}");
        }
    }
