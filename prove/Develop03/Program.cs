// For creativity, I added a function that asks the user 
// how many words they wish to hide and memorize.
using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        string reference = "Proverbs 3:5-6";
        string text = "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to Him, and He will make your path straight.";
        
        Scripture scripture = new Scripture(reference, text);
        Console.WriteLine("Welcome to the Scripture Memorization Assistant!");
        Console.WriteLine("Here is your scripture:\n");
        Console.WriteLine(scripture.GetDisplayText());

        while (true)
        {
            Console.WriteLine("\nHow many words would you like to hide?");
            if (int.TryParse(Console.ReadLine(), out int numberToHide))
            {
                if (numberToHide < 0)
                {
                    Console.WriteLine("Please enter a positive number or zero to hide no words.");
                }
                else if (numberToHide == 0)
                {
                    Console.WriteLine("Exiting hiding mode. Thank you!");
                    break;
                }
                else
                {
                    int remainingWords = scripture.GetRemainingWordCount(); 

                    
                    if (numberToHide > remainingWords)
                    {
                        Console.WriteLine($"You can only hide {remainingWords} words. Please choose a smaller number.");
                        Console.WriteLine("\nCurrent display:");
                        Console.WriteLine(scripture.GetDisplayText()); 
                        
                        continue; 
                    }

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
                            return; 
                        }

                        Console.WriteLine("How many more words would you like to hide?");
                        if (!int.TryParse(Console.ReadLine(), out int additionalToHide) || additionalToHide < 0)
                        {
                            Console.WriteLine("Invalid input. Please enter a positive number of words to hide.");
                            continue;
                        }

                        remainingWords = scripture.GetRemainingWordCount(); 
                        if (additionalToHide > remainingWords)
                        {
                            Console.WriteLine($"You can only hide {remainingWords} more words. Please choose a smaller number.");
                            Console.WriteLine("\nCurrent display:");
                            Console.WriteLine(scripture.GetDisplayText()); 
                            continue; 
                        }

                        scripture.HideRandomWords(additionalToHide);
                    }

                    Console.WriteLine("Great job! You've tried to memorize the scripture.");
                    break; 
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number.");
            }
        }
    }
}