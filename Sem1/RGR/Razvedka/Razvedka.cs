using System;
class Razvedka
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int groupCount = CountGroups(n);
        Console.WriteLine(groupCount);
    }

    static int CountGroups(int n)
    {
        if (n < 3) return 0;
        if (n == 3) return 1;

        int evenCount = n / 2; 
        int oddCount = n - evenCount; 

        return CountGroups(evenCount) + CountGroups(oddCount);
    }
}