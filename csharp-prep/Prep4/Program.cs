using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<float> numbers = new List<float>();
       
        float input = -1;
        Console.WriteLine("Enter a list of numbers, type 0 when finished");

        while (input != 0)
        {
            Console.Write("Enter number ");
            string userInput = Console.ReadLine();
            input = float.Parse(userInput);

            if (input != 0)
            {
                numbers.Add(input);
            }
        }

        //Compute sum
        float sum = 0;
        foreach (float number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        //Compute average
        float average = sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        //Max number
         if (numbers.Count > 0)
        {
            float max = numbers[0];

            foreach (float number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine($"The max is: {max}");

            //Smallest positive number(closest to 0)
            float smallestPositive = float.MaxValue;
            
            foreach (float number in numbers)
            {
                if (number > 0 && number < smallestPositive);
                {
                    smallestPositive = number;
                }
            }

            if (smallestPositive == float.MaxValue)
            {
                Console.WriteLine("There are no positive numbers in the list");
            }
            else
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            //Sort and display
            numbers.Sort();
            Console.WriteLine("The sorted list is:");

            foreach (float number in numbers)
            {
                Console.WriteLine(number);
            }

        }    
        else
        {
            Console.WriteLine("No numbers were added");
        }    

    }
}