using System;
using System.Reflection;
using System.Reflection.Metadata;
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine($"You have {manager.GetScore()} points. Level {manager.GetLevel()}"); //Stretch. Level up every 1000 points
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.DisplayGoals();
                    Pause();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    manager.SaveGoals(saveFile);
                    Console.WriteLine("Saved!");
                    Pause();
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    manager.LoadGoals(loadFile);
                    Console.WriteLine("Loaded!");
                    Pause();
                    break;
                case "5":
                    RecordGoal(manager);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    Pause();
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        if (!int.TryParse(Console.ReadLine(), out int points))//check if a string cannot be converted to an int
        {
            Console.WriteLine("Invalid points. Try again.");
            Pause();
            return;
        }

        if (type == "1")
        {
            manager.AddGoal(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            manager.AddGoal(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times to complete: ");
            if (!int.TryParse(Console.ReadLine(), out int completeCount))
            {
                Console.WriteLine("Invalid number. Try again.");
                Pause();
                return;
            }

            Console.Write("Bonus points: ");
            if (!int.TryParse(Console.ReadLine(), out int bonus))
            {
                Console.WriteLine("Invalid bonus. Try again.\n");
                Pause();
                return;
            }

            manager.AddGoal(new ChecklistGoal(name, description, points, completeCount, bonus));
        }

        Console.WriteLine("Goal Added!");
        Pause();
    }

    static void RecordGoal(GoalManager manager)
    {
        manager.DisplayGoals();
        Console.Write("Which goal did you accomplish? (Enter number): ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            manager.RecordEvent(index - 1);
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}