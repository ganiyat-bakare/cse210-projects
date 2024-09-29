// To exceed requirements, I introduced a mood tracker to 
//record user's emotional state alongside journal entries.

using System;  

class Program  
{  
    static void Main(string[] args)  
    {  
        Journal journal = new Journal();  
        PromptGenerator promptGenerator = new PromptGenerator();  
        string userInput;  
        
        do  
        {  
            Console.WriteLine("Journal Application");  
            Console.WriteLine("1. New Entry");  
            Console.WriteLine("2. Display Journal");  
            Console.WriteLine("3. Save Journal");  
            Console.WriteLine("4. Load Journal");  
            Console.WriteLine("5. Exit");  
            Console.Write("Choose an option: ");  
            userInput = Console.ReadLine();  

            switch (userInput)  
            {  
                case "1":  
                    string prompt = promptGenerator.GetRandomPrompt();  
                    Console.WriteLine(prompt);  
                    Console.Write("Your response: ");  
                    string response = Console.ReadLine();  
                    string date = DateTime.Now.ToShortDateString(); // Get current date  

                    // Mood selection  
                    Console.WriteLine("Select your mood:");  
                    Console.WriteLine("1. Happy");  
                    Console.WriteLine("2. Sad");  
                    Console.WriteLine("3. Anxious");  
                    Console.WriteLine("4. Excited");  
                    Console.WriteLine("5. Reflective");  
                    Console.Write("Choose a mood (1-5): ");  
                    string moodInput = Console.ReadLine();  
                    string mood = moodInput switch  
                    {  
                        "1" => "Happy",  
                        "2" => "Sad",  
                        "3" => "Anxious",  
                        "4" => "Excited",  
                        "5" => "Reflective",  
                        _ => "Unknown"  
                    };   
                    // Pass mood to Entry constructor now  
                    journal.AddEntry(new Entry(date, prompt, response, mood));  
                    break;  

                case "2":  
                    journal.DisplayEntries();  
                    break;  

                case "3":  
                    Console.Write("Enter filename to save journal: ");  
                    string saveFilename = Console.ReadLine();  
                    journal.SaveToFile(saveFilename);  
                    break;  

                case "4":  
                    Console.Write("Enter filename to load journal: ");  
                    string loadFilename = Console.ReadLine();  
                    journal.LoadFromFile(loadFilename);  
                    break;  

                case "5":  
                    Console.WriteLine("Exiting the program...");  
                    break;  

                default:  
                    Console.WriteLine("Invalid option. Please try again.");  
                    break;  
            }  
        } while (userInput != "5");  
    }  
}  