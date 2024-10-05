// For creativity, I added a function that asks the user 
// how many words they wish to hide and memorize.
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string reference = "John 3:16";
        string text = "For God so loved the world that He gave His Only Begotten Son, that whosoever believes in Him shall not perish but have everlasting life.";
        
        Scripture scripture = new Scripture(reference, text);
        Console.WriteLine("Welcome to the Scripture Memorization Assistant!");
        Console.WriteLine("Here is your scripture:\n");
        Console.WriteLine(scripture.GetDisplayText());

        Console.WriteLine("\nHow many words would you like to hide?");
        if (int.TryParse(Console.ReadLine(), out int numberToHide))
        {
            scripture.HideRandomWords(numberToHide);
            Console.WriteLine("\nWords hidden! Try to recall the scripture.");

            while (!scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nCurrent display:");
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("Press Enter to hide more words or type 'exit' to finish.");
                
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    break;
                }

                Console.WriteLine("How many more words would you like to hide?");
                if (int.TryParse(Console.ReadLine(), out int additionalToHide))
                {
                    scripture.HideRandomWords(additionalToHide);
                }
            }

            Console.WriteLine("Great job! You've tried to memorize the scripture.");
        }
        else
        {
            Console.WriteLine("Invalid number, please try again.");
            
        }
    }
}