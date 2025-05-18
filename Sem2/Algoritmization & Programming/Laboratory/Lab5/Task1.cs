using System;

public class Phone
{
    public string Number { get; private set; }
    public string Operator { get; private set; }

    public Phone(string number, string operatorString)
    {
        Number = number;
        Operator = operatorString;
    }
}

class Program
{
    static void Main()
    {
        List<Phone> phones = new List<Phone>();
        phones.Add(new Phone("+11111111111", "mts"));
        phones.Add(new Phone("+22222222222", "mts"));
        phones.Add(new Phone("+33333333333", "tele"));
        phones.Add(new Phone("+44444444444", "mts"));
        phones.Add(new Phone("+55555555555", "mts"));
        phones.Add(new Phone("+66666666666", "tele"));
        phones.Add(new Phone("+77777777777", "mts"));
        
        Dictionary<string, int> phoneDictionary = new Dictionary<string, int>();

        foreach (var p in phones)
        {
            if (!phoneDictionary.TryAdd(p.Operator, 1))
            {
                phoneDictionary[p.Operator] += 1;
            }
        }

        int a = 0;
        string op = "";
        
        foreach(var p in phoneDictionary)
        {
            if (p.Value > a)
            {
                op = p.Key;
                a = p.Value;
            }
        }
        
        Console.WriteLine($"итог: {op}  количество раз: {a}");
    }
}
