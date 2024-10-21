using System;


public class ReflectingActivity : Activity  
{  
    private List<string> _prompts;
    private List<string> _questions;  

    public ReflectingActivity(string name, string description, int duration) : base(name, description, duration) 
    {
        _prompts = new List<string>
        {
        "Think of a time when you stood up for someone else.",  
        "Think of a time when you did something really difficult.",  
        "Think of a time when you helped someone in need.",  
        "Think of a time when you did something truly selfless.",
        };

        _questions = new List<string>
        {
        "Why was this experience meaningful to you?",  
        "Have you ever done anything like this before?",  
        "How did you get started?",  
        "How did you feel when it was complete?",  
        "What made this time different than other times when you were not as successful?",  
        "What is your favorite thing about this experience?",  
        "What could you learn from this experience that applies to other situations?",  
        "What did you learn about yourself through this experience?",  
        "How can you keep this experience in mind in the future?" 
        };
    }  

    public override void Run()  
    {  
        DisplayStartingMessage();  

        DisplayPrompt(); 

        Console.WriteLine(); 

        DisplayQuestions();

        Console.WriteLine(); 

        DisplayEndingMessage();
        ShowSpinner(5);  
    }  

    private string GetRandomPrompt()  
    {  
        Random random = new Random();  
        int index = random.Next(_prompts.Count);  
        return _prompts[index];  
    }  

    private string GetRandomQuestion()  
    {  
        Random random = new Random();  
        int index = random.Next(_questions.Count);  
        return _questions[index];  
    }  

    private void DisplayPrompt()  
    {  
        string prompt = GetRandomPrompt();  
        Console.WriteLine($"Reflect on the following prompt:\n---{prompt}---");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadKey();   
    }  

    private void DisplayQuestions()  
    {  
        Console.Write("Now ponder on each of the following questions as they related to this experience.\nYou may begin in: ");
        ShowCountDown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)   
        {  
            string randomQuestion = GetRandomQuestion();

            Console.Write($">{randomQuestion}");
            ShowSpinner(10);  
        }  
    }  
}  