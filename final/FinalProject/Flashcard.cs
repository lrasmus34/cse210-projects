public abstract class Flashcard
{
    private string _question;

    public string GetQuestion()
    {
        return _question;
    }

    public void SetQuestion(string value)
    {
        _question = value;
    }

    public abstract string GetAnswer();
    public abstract void Display();
}