public class Deck
{
    private List<Flashcard> _cards;
    private string _name;

    public Deck(string name)
    {
        _cards = new List<Flashcard>();
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void AddCard(Flashcard card) => _cards.Add(card);

    public List<Flashcard> GetAllCards() => _cards;
}