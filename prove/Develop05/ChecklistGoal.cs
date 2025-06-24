public class ChecklistGoal : Goal
{
    private int _completedCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int completedCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        _completedCount = completedCount;
        _bonus = bonus;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _completedCount)
        {
            _currentCount++;
            if (_currentCount == _completedCount)
                return _points + _bonus;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _currentCount >= _completedCount;//(parameters) => expression or block
    public override string GetStatus() => $"[{(_currentCount >= _completedCount ? "X" : " ")}]";//Ternary Operator(condition ? valueIfTrue : valueIfFalse)
    public override string ToString() => $"{_name}: {_description} -- Completed {_currentCount}/{_completedCount} ({_points})";
    public override string GetSaveData() => $"ChecklistGoal|{_name}|{_description}|{_points}|{_completedCount}|{_bonus}|{_currentCount}";
}
   