public class MultipleChoice : Flashcard
{
    private List<string> _options;
    private int _correct;

    public MultipleChoice(string question, List<string> options, int correct)
    {
        SetQuestion(question);
        _options = options;
        _correct = correct;
    }

    public List<string> GetOptions()
    {
        return _options;
    }

    public void SetOptions(List<string> options)
    {
        _options = options;
    }

    public int GetCorrect()
    {
        return _correct;
    }

    public void SetCorrect(int index)
    {
        _correct = index;
    }

    public override string GetAnswer() => _options[_correct];

    public override void Display()
    {
        Console.WriteLine("Q: " + GetQuestion());
        for (int i = 0; i < _options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_options[i]}");
        }
    }
}