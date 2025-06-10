using System;
using System.Collections.Generic;

public class Listing : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who have you helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    public static int _count { get; private set; } = 0; //log of how many times listing activity was performed


    private List<string> _userInputs = new List<string>();

    public Listing() : base("Listing", "This activity will help you reflect on the good things in your life by listing as many items as you can in a given area.")
    { }

    public void RunListing()
    {
        _count++;

        Start();

        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine();

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"---{prompt}---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        AnimationHelper.Countdown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input)) // checks whether user's input is empty, white space, and tabs or newline characters
            {
                _userInputs.Add(input);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {_userInputs.Count} item{(_userInputs.Count == 1 ? "" : "s")}!");
        Console.WriteLine();

        End();
    }
}