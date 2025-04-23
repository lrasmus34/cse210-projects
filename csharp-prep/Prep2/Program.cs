using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int gradePercent = int.Parse(answer);

        string letter = "";
        string sign = "";

        if (gradePercent >= 90)
        {
            letter = "A";
        }
        else if (gradePercent > 80)
        {
            letter = "B";
        }
        else if (gradePercent >= 70)
        {
            letter = "C";
        }
        else if (gradePercent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int lastDigit = gradePercent % 10;
        if (letter != "A" && letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && gradePercent < 93)
        {
            if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (gradePercent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Keep trying");
        }
    }
}