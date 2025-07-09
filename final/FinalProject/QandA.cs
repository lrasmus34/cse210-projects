public class QandA : Flashcard
{
    private string _answer;

    public QandA(string question, string answer)
    {
        SetQuestion(question);
        _answer = answer;
    }

    public string GetAnswerText()
    {
        return _answer;
    }

    public void SetAnswer(string value)
    {
        _answer = value;
    }

    public override string GetAnswer() => _answer;

    public override void Display()
    {
        Console.WriteLine("Q: " + GetQuestion());
    }
}