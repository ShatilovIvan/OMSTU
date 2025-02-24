using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        string test1 = "() + []";
        string test2 = "([])";
        string test3 = "[(])";
        string test4 = "2 + 5";

        Stack<char> stack = new Stack<char>();

        foreach(char ch in input)
        {
            if (ch == '(' || ch == '{'  || ch == '[')
            {
                stack.Push(ch);
            }

            else if (ch == ')' || ch == '}' || ch == ']')
            {
                char previous;

                if (stack.Count > 0)
                    previous = stack.Peek();

                else {Console.WriteLine("Последовательность неправильная :("); return;}
                
                switch(ch)
                {
                    case ')':
                    if (previous == '(')
                    stack.Pop();
                    break;

                    case '}':
                    if (previous == '{')
                    stack.Pop();
                    break;

                    case ']':
                    if (previous == '[')
                    stack.Pop();
                    break;

                    default:
                    Console.WriteLine("Последовательность неправильная :(");
                    return;
                    break;
                }
            }
        }

        if (stack.Count == 0)
            Console.WriteLine("Последовательность правильная!");

        else
            Console.WriteLine("Последовательность неправильная :(");
    }
}
