// To show creativity, another menu option is added inside
// each activity to ask if the user wants to redo the activity,
// return to the main menu or to exit the program. 

using System;


class Program
{
    static void Main(string[] args)
    {  
        Console.WriteLine("Welcome to the Mindfulness Program!");  
        
        while (true)  
        {  
            Console.WriteLine("\nMindfulness Activities Menu:");  
            Console.WriteLine("1. Start breathing activity");  
            Console.WriteLine("2. Start reflecting activity");  
            Console.WriteLine("3. Start listing activity");  
            Console.WriteLine("4. Quit");  
            Console.Write("Select a choice from the menu: ");  

            string choice = Console.ReadLine();  
            Activity activity;  

            switch (choice)  
            {  
                case "1":  
                    activity = new BreathingActivity("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 0);  
                    break;  
                case "2":  
                    activity = new ReflectingActivity("Reflecting Activity","This activity will help you reflect on meaningful experiences by asking thought-provoking questions.", 0);  
                    break;  
                case "3":  
                    activity = new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0, 0);  
                    break;  
                case "4":  
                    Console.WriteLine("Thank you for using the Mindfulness Program! Goodbye.");  
                    return;  
                default:  
                    Console.WriteLine("Invalid choice, please try again.");  
                    continue;  
            }  

            // Loop for activity selection: redo, exit, or continue  
            bool continueActivity = true;  
            while (continueActivity)  
            {  
                activity.Run();  
                Console.WriteLine("\nChoose an option:");  
                Console.WriteLine("1. Retry this activity");  
                Console.WriteLine("2. Return to main menu");  
                Console.WriteLine("3. Exit program");  
                string option = Console.ReadLine();  

                switch (option)  
                {  
                    case "1":  
                        continue; 
                    case "2":  
                        continueActivity = false;  
                        break;  
                    case "3":  
                        Console.WriteLine("Thank you for using the Mindfulness Program! Goodbye.");  
                        return; 
                    default:  
                        Console.WriteLine("Invalid option, returning to main menu.");  
                        continueActivity = false;  
                        break;  
                }  
            }  
        }  
    }  
}
