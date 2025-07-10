/*
Flashcard Study App

This is a simple C# application for creating and studying digital flashcards.  
It demonstrates the four principles of Object-Oriented Programming:
- Abstraction
- Encapsulation
- Inheritance
- Polymorphism


What the program does

- Create Q&A, True/False, and Multiple Choice flashcards.
- Stores all flashcards in a single deck.
- Study your cards by quizzing yourself.
- Earn points for correct answers.
- Level up as you earn points.
- Safely cancel adding cards or quizzes anytime by typing "0".


How to run it

1. Open the project in Visual Studio or your C#.
2. Make sure all ".cs" files are in the same project:
   - "Program.cs"
   - "Flashcard.cs"
   - "QandA.cs"
   - "TrueFalseCard.cs"
   - "MultipleChoice.cs"
   - "Deck.cs"
   - "FlashcardManager.cs"
   - "Scoring.cs"
3. Build and run the program.
4. Follow the menu to add cards, display cards, or quiz yourself.


How to use it

Add Cards
- Pick the card type from the menu.
- Follow the prompts.
- For True/False cards, answers must be "true", "false", "t", or "f".
- For Multiple Choice, options must be filled 1–4. The correct option must be 1–4.


Quiz Yourself

- You can answer:
  - Q&A: by typing the full answer.
  - True/False: by typing "t", "f", "true", or "false".
  - Multiple Choice: by typing the option number or the full text.
- Type "0" to exit the quiz early.


Scoring

- Each correct answer adds 5 points.
- You level up every 10 points × current level.


Requirements

- Written in C#
- Runs as a console app
- No external libraries required


Extra features

- Fully demonstrates OOP principles:
  - "Flashcard" is an abstract base class.
  - "QandA","`TrueFalseCard", and "MultipleChoice" inherit from "Flashcard".
  - Uses polymorphism to quiz any card type.
  - Uses encapsulation with private fields and explicit "Getters" and Setters" methods.
- Uses safe input handling so the user cannot crash the program by entering invalid data.
*/