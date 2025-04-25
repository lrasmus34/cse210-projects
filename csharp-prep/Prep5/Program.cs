using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = UserName();
        float number = Number();
        float squaredNumber = SquareNumber(number);
        Result(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string UserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static float Number()
    {
        Console.Write("What is you favorite number? ");
        float favNumber = float.Parse(Console.ReadLine());
        return favNumber;
    }

    static float SquareNumber(float number)
    {
        float square = number * number;
        return square;
    }

    static void Result(string name, float square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}