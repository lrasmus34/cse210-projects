public class Scoring
{
    private int _points = 0;
    private int _level = 1;

    public Scoring()
    {
        // default constructor — no extra setup needed for now
    }

    public int GetPoints()
    {
        return _points;
    }

    public int GetLevel()
    {
        return _level;
    }

    public void AddPoints(int amount)
    {
        _points += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        if (_points >= _level * 10)
        {
            _level++;
            Console.WriteLine($"Level up! You are now level {_level}.");
        }
    }
}