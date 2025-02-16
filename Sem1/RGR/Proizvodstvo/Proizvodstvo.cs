using System;

class Proizvodstvo
{
    public static bool IsLeapYear(int year)
    {
        return (year % 4 == 0);
    }
    static int DaysInMonth(int month, int year)
    {
        if (month == 2)
        {
            return IsLeapYear(year) ? 29 : 28;
        }
        else if (month == 4 || month == 6 || month == 9 || month == 11)
        {
            return 30;
        }
        return 31;
    }
    public static int CalculateDays(int[] date)
    {
        int days = 0;

        for (int i = 0; i < date[2]; i++)
        {
            days += IsLeapYear(i) ? 366 : 365;
        }

        for (int j = 1; j < date[1]; j++)
        {
            days += DaysInMonth(j, date[2]);
        }

        days += date[0];
        return days;
    }
    public static void Main()
    {
        string firstDateString = Console.ReadLine();
        string secondDateString = Console.ReadLine();
        int p = Convert.ToInt32(Console.ReadLine());
        int result = p;

        if (p < 0 || p > 5000)
            return;

        int[] firstDate = new int[3];
        int[] secondDate = new int[3];

        firstDate[0] = int.Parse(firstDateString.Substring(0, 2));
        firstDate[1] = int.Parse(firstDateString.Substring(3, 2));
        firstDate[2] = int.Parse(firstDateString.Substring(6, 4));

        secondDate[0] = int.Parse(secondDateString.Substring(0, 2));
        secondDate[1] = int.Parse(secondDateString.Substring(3, 2));
        secondDate[2] = int.Parse(secondDateString.Substring(6, 4));

        int days1 = CalculateDays(firstDate);
        int days2 = CalculateDays(secondDate);

        int gap = days2 - days1;
        if (gap < 0 || gap < 1 || gap > 60000)
        {
            return;
        }
        
        for (int i = 0; i < gap; i++)
        {
            result += p + (i+1);
        }

        Console.WriteLine(result);
    }
}