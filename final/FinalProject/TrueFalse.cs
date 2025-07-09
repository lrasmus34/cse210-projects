public class TrueFalseCard : Flashcard
{
    private bool _isTrue;

    public TrueFalseCard(string question, bool isTrue)
    {
        SetQuestion(question);
        _isTrue = isTrue;
    }

    public bool GetIsTrue()
    {
        return _isTrue;
    }

    public void SetIsTrue(bool value)
    {
        _isTrue = value;
    }

    public override string GetAnswer() => _isTrue ? "True" : "False";

    public override void Display()
    {
        Console.WriteLine("Q: " + GetQuestion());
        Console.WriteLine("(True/False)");
    }
}