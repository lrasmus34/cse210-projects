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
                    Console.Write("Question (or 0 to cancel): ");
                    string q = Console.ReadLine();
                    if (q == "0") break;

                    Console.Write("Answer (or 0 to cancel): ");
                    string a = Console.ReadLine();
                    if (a == "0") break;

                    deck.AddCard(new QandA(q, a));
                    break;

                case "2":
                    Console.Write("Statement (or 0 to cancel): ");
                    string s = Console.ReadLine();
                    if (s == "0") break;

                    Console.Write("Is it true or false? (t/f/true/false, or 0 to cancel): ");
                    string tfInput = Console.ReadLine().Trim().ToLower();
                    if (tfInput == "0") break;

                    if (tfInput != "true" && tfInput != "false" && tfInput != "t" && tfInput != "f")
                    {
                        Console.WriteLine("Invalid input. Must be 'true', 'false', 't', or 'f'. Returning to main menu.");
                        break;
                    }

                    bool isTrue = (tfInput == "true" || tfInput == "t");

                    deck.AddCard(new TrueFalseCard(s, isTrue));
                    break;

                case "3":
                    Console.Write("Question (or 0 to cancel): ");
                    string mcq = Console.ReadLine();
                    if (mcq == "0") break;

                    List<string> opts = new List<string>();
                    for (int i = 1; i <= 4; i++)
                    {
                        Console.Write($"Option {i} (or 0 to cancel): ");
                        string opt = Console.ReadLine();
                        if (opt == "0") break;
                        opts.Add(opt);
                    }
                    if (opts.Contains("0") || opts.Count < 4) break;

                    Console.Write("Number of correct option (1-4, or 0 to cancel): ");
                    string idxInput = Console.ReadLine();
                    if (idxInput == "0") break;

                    if (!int.TryParse(idxInput, out int idx) || idx < 1 || idx > 4)
                    {
                        Console.WriteLine("Invalid input. Must be 1, 2, 3, or 4. Returning to main menu.");
                        break;
                    }

                    deck.AddCard(new MultipleChoice(mcq, opts, idx - 1)); // store as zero-based index
                    break;

                case "4":
                    Console.WriteLine("\nDisplaying all flashcards:");
                    foreach (var card in deck.GetAllCards())//var - figure out the type automatically
                    {
                        card.Display();
                        Console.WriteLine($"Answer: {card.GetAnswer()}\n");
                    }
                    break;

                case "5":
                    Console.WriteLine("\nQuiz Mode: Answer each card. (Type 0 to exit quiz at any time.)");
                    foreach (var card in deck.GetAllCards())
                    {
                        card.Display();
                        Console.Write("Your answer (or 0 to quit quiz): ");
                        string answer = Console.ReadLine().Trim().ToLower();

                        if (answer == "0")
                        {
                            Console.WriteLine("Quiz canceled. Returning to main menu.\n");
                            break;
                        }

                        string correctAnswer = card.GetAnswer().ToLower();
                        bool isCorrect = false;

                        if (card is MultipleChoice mc)
                        {
                            if (answer == correctAnswer)
                            {
                                isCorrect = true;
                            }
                            else if (int.TryParse(answer, out int optionNumber))
                            {
                                if (optionNumber - 1 == mc.GetCorrect())
                                {
                                    isCorrect = true;
                                }
                            }
                        }
                        else if (card is TrueFalseCard)
                        {
                            if ((correctAnswer == "true" && (answer == "true" || answer == "t")) ||
                                (correctAnswer == "false" && (answer == "false" || answer == "f")))//Did the user’s input match the correct answer for a True or False card?
                            {
                                isCorrect = true;
                            }
                        }
                        else
                        {
                            if (answer == correctAnswer)
                            {
                                isCorrect = true;
                            }
                        }

                        if (isCorrect)
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