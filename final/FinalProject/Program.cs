public class Program
{
    public static void Main(string[] args)
    {
        Deck deck = new Deck("MasterDeck");
        FlashcardManager manager = new FlashcardManager();
        Scoring score = new Scoring();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nFlashcard Menu:");
            Console.WriteLine("1. Add Q&A Card");
            Console.WriteLine("2. Add True/False Card");
            Console.WriteLine("3. Add Multiple Choice Card");
            Console.WriteLine("4. Display All Cards");
            Console.WriteLine("5. Quiz Yourself");
            Console.WriteLine("6. Exit");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Question: ");
                    string q = Console.ReadLine();
                    Console.Write("Answer: ");
                    string a = Console.ReadLine();
                    deck.AddCard(new QandA(q, a));
                    break;

                case "2":
                    Console.Write("Statement: ");
                    string s = Console.ReadLine();
                    Console.Write("Is it true or false? (true/false): ");
                    bool isTrue = Console.ReadLine().Trim().ToLower() == "true";
                    deck.AddCard(new TrueFalseCard(s, isTrue));
                    break;

                case "3":
                    Console.Write("Question: ");
                    string mcq = Console.ReadLine();
                    List<string> opts = new List<string>();
                    for (int i = 1; i <= 4; i++)
                    {
                        Console.Write($"Option {i}: ");
                        opts.Add(Console.ReadLine());
                    }
                    Console.Write("Number of correct option (1-4): ");
                    int idx = int.Parse(Console.ReadLine()) - 1;
                    deck.AddCard(new MultipleChoice(mcq, opts, idx));
                    break;

                case "4":
                    Console.WriteLine("\nDisplaying all flashcards:");
                    foreach (var card in deck.GetAllCards())
                    {
                        card.Display();
                        Console.WriteLine($"Answer: {card.GetAnswer()}\n");
                    }
                    break;

                case "5":
                    Console.WriteLine("\nQuiz Mode: Answer each card.");
                    foreach (var card in deck.GetAllCards())
                    {
                        card.Display();
                        Console.Write("Your answer: ");
                        string answer = Console.ReadLine();
                        if (answer.Trim().ToLower() == card.GetAnswer().ToLower())
                        {
                            Console.WriteLine("Correct!\n");
                            score.AddPoints(5);
                        }
                        else
                        {
                            Console.WriteLine($"Incorrect. Correct answer: {card.GetAnswer()}\n");
                        }
                    }
                    Console.WriteLine($"Total Points: {score.GetPoints()}, Level: {score.GetLevel()}");
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}