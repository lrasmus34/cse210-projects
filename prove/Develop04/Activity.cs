using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks.Dataflow;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine($"\n{_description}");
        Console.Write("\nHow long, in seconds, would you like your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        AnimationHelper.Spinner(3);
    }

    public void End()
    {
        Console.WriteLine("\nWell done!");
        AnimationHelper.Spinner(3);

        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name} Activity");
        AnimationHelper.Spinner(3);
    }
}