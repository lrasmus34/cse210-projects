public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => _points;//(parameters) => expression or block
    public override bool IsComplete() => false;
    public override string GetStatus() => "[ ]";
    public override string GetSaveData() => $"EternalGoal|{_name}|{_description}|{_points}";
}