using System;
using System.Collections.Generic;

public class Reflecting : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public static int _count { get; private set; } = 0; //log of how many times reflecting activity was performed

    public Reflecting() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    { }

    public void RunReflecting()
    {
        _count++;

        Start();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"---{prompt}---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue"); ;
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience:");
        Console.Write("You may begin in: ");
        AnimationHelper.Countdown(5);
        Console.Clear();

        int timeUsed = 0;

        while (timeUsed < _duration)
        {
            string questions = _questions[rand.Next(_questions.Count)];
            Console.WriteLine($"> {questions}");

            int timeLeft = _duration - timeUsed;
            int reflectTime = Math.Min(10, timeLeft); // Use remaining time if less than 10

            AnimationHelper.Spinner(reflectTime);
            timeUsed += reflectTime;
        }

        End();
    }
}