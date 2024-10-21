using System;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()  
    {  
        Console.Clear();  
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine(); 

        Console.WriteLine(_description); 
        Console.WriteLine(); 

        Console.Write($"How long, in seconds, would you like for your session? ");  
        _duration = int.Parse(Console.ReadLine());  
        Console.WriteLine(); 

        Console.WriteLine("Get ready...");  
        ShowSpinner(5);   
    }  
    public void DisplayEndingMessage()  
    {  
        Console.WriteLine("Well done!!");
        ShowSpinner(5); 

        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");  
        
        ShowSpinner(5); 
         
    }

    public void ShowSpinner(int seconds)  
    {  
        List<string> animationStrings = new List<string>  
        {  
            "|", "/", "-", "\\", "|", "/", "-", "\\"  
        };  

        DateTime endTime = DateTime.Now.AddSeconds(seconds);  
        int i = 0;  

        while (DateTime.Now < endTime)
        {  
            string s = animationStrings[i];  
            Console.Write(s);  
            Thread.Sleep(800);   
            Console.Write("\b \b");   

            i++;  
            if (i >= animationStrings.Count)  
            {  
                i = 0;  
            }  
        }  

        Console.WriteLine(); 
    }


    public void ShowCountDown(int seconds)  
    {  
        for (int i = seconds; i > 0; i--)  
        {  
            Console.Write(i);  
            Thread.Sleep(1500);  
            Console.Write("\b \b");   
        }  
        Console.WriteLine();  
    }

    public virtual void Run()
    {
    }  
}  