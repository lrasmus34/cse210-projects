using System;
public class Program
{  
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflecting Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new Breathing().RunBreathing();
                    break;
                case "2":
                    new Reflecting().RunReflecting();
                    break;
                case "3":
                    new Listing().RunListing();
                    break;
                case "4":
                    //(Stretch)Log of all the different activities that were completed
                    Console.WriteLine("Thank you for taking time to be mindful!");
                    Console.WriteLine($"\nActivity Log:");
                    Console.WriteLine($"- Breathing Activity performed: {Breathing._count} time{(Breathing._count == 1 ? "" : "s")}");    //ternary operator's-->(condition) ? resultIfTrue : resultIfFalse;
                    Console.WriteLine($"- Reflecting Activity performed: {Reflecting._count} time{(Reflecting._count == 1 ? "" : "s")}");
                    Console.WriteLine($"- Listing Activity performed: {Listing._count} time{(Listing._count == 1 ? "" : "s")}");
                    Console.WriteLine("\nPress Enter to exit:");
                    Console.ReadLine();
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}