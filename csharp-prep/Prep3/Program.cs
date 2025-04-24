using System;
using System.Net;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;
       
        do
        {
            //For part 1 and 2.
            //Console.Write("What is the magic number? ");
            //int magicNumber = int.Parse(Console.ReadLine());

            //Part 3
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);       

            int guess = 0;
            int guessCount = 0;

            Console.WriteLine("Guess a number between 1 and 100");

            while (guess != magicNumber)
            { 
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().Trim().ToLower();

        } while (playAgain =="yes");

        Console.WriteLine("Thanks for playing!");
    }
}