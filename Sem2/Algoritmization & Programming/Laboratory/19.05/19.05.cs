using System;
using System.Runtime.Serialization.Formatters;

class Program
{
    static unsafe void Main()
    {
        int size = 10;
        int* p = stackalloc int[size];

        p[0] = 121;
        p[1] = 100;
        p[2] = 0;
        p[3] = 250;
        p[4] = 333;
        p[5] = 555;
        p[6] = 694;
        p[7] = 232;
        p[8] = 1089;
        p[9] = 1111;

        for (int i = 0; i < size; i++)
        {
            if (IsPalindrome(p[i]))
            {
                Console.WriteLine($"Элемент [{i}] = {p[i]}");
            }
        }
    }

    static bool IsPalindrome(int number)
    {
        string numStr = number.ToString();
        
        for (int i = 0; i < numStr.Length / 2; i++)
        {
            if (numStr[i] != numStr[numStr.Length - 1 - i])
                return false;
        }
        
        return true;
    }
}
