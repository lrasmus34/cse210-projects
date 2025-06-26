using System.Runtime.CompilerServices;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }
    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            int earned = _goals[index].RecordEvent();
            _score += earned;
            CheckLevelUp();
            Console.WriteLine($"Congrats. You earned {earned} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }
    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i]}");
    }
    public int GetLevel()
    {
        return _level;
    }

    //Stretch. Level up every 1000 points
    private void CheckLevelUp()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"Level up! You are now level {_level}.");
        }
    }
    public int GetScore()
    {
        return _score;
    }
    public void SaveGoals(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Invalid filename. Save cancelled.");
            return;
        }
        
        using (StreamWriter writer = new StreamWriter(filename))//Creates a StreamWriter object to write text to a file specified by filename. If the file doesn’t exist, it will be created. If it does exist, it will be overwritten by default, unless you use an overload to append.


        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetSaveData());
            }
        }
    }
    public void LoadGoals(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename) || !File.Exists(filename))//check if a file path is invalid or the file doesn’t exist
        {
            Console.WriteLine("Invalid or missing file. Load cancelled.");
            return;
        }
        _goals.Clear();
        using StreamReader reader = new StreamReader(filename);
        _score = int.Parse(reader.ReadLine());

        while (!reader.EndOfStream)
        {
            string[] parts = reader.ReadLine().Split('|');//Splits line into parts
            string type = parts[0];//Tells what type of goal to create
            if (type == "SimpleGoal")
            {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                bool completed = bool.Parse(parts[4]);
                _goals.Add(new SimpleGoal(name, desc, points, completed));
            }
            else if (type == "EternalGoal")
            {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                _goals.Add(new EternalGoal(name, desc, points));
            }
            else if (type == "ChecklistGoal")
            {
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);
                int completedCount = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int currentCount = int.Parse(parts[6]);
                _goals.Add(new ChecklistGoal(name, desc, points, completedCount, bonus, currentCount));
            }
        }
    }
}