using System;
using System.Net.Http.Headers;

class Program
{
    static void Main(string[] args)
    {
        Assignment hw1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(hw1.GetSummary());

        Math hw2 = new Math("Roberto Rodriguez", "Fraction", "7.3", "8-19,");
        Console.WriteLine(hw2.GetSummary());
        Console.WriteLine(hw2.GetHomeworkList());

        Writing hw3 = new Writing("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(hw3.GetSummary());
        Console.WriteLine(hw3.GetWritingInfo());
    }
}