using System;



public class ListingActivity : Activity  
{  
    private int _count;  
    private List<string> _prompts;  

    public ListingActivity(string name, string description, int duration, int count) : base(name, description, duration)  
    {  
        _count = count;
        _prompts = new List<string>
        {
        "Who are people that you appreciate?",  
        "What are personal strengths of yours?",  
        "Who are people that you have helped this week?",  
        "When have you felt the Holy Ghost this month?",  
        "Who are some of your personal heroes?" 
        };
    }  

    public override void Run()  
    {  
        DisplayStartingMessage();
        

        string prompt = GetRandomPrompt();
        Console.WriteLine($"List as many responses as you can to the following prompt:\n---{prompt}---");
        Console.Write("You may begin in: ");
  
        ShowCountDown(5);  
  

        List<string> responses = GetListFromUser(); 

        Console.WriteLine(); 

        _count = responses.Count;   
        Console.WriteLine($"You listed {_count} items!");

        Console.WriteLine(); 
        
        DisplayEndingMessage();
    }  

    private string GetRandomPrompt()  
    {  
        Random random = new Random();  
        int index = random.Next(_prompts.Count);  
        return _prompts[index];  
    }  

    private List<string> GetListFromUser()  
    {  
        List<string> responses = new List<string>();  
        
        DateTime endTime = DateTime.Now.AddSeconds(_duration);   

        while (DateTime.Now < endTime)  
        {  
            Console.Write(">");  
            string userInput = Console.ReadLine();  
            responses.Add(userInput);  
        }  

        return responses;   
    }  
}

