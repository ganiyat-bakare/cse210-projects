using System;

public class BreathingActivity : Activity  
{  
    public BreathingActivity(string name, string description, int duration) : base(name, description, duration)  
    {  
    }

    public override void Run()  
    {  
        DisplayStartingMessage(); 
        DateTime startTime = DateTime.Now;  
        DateTime endTime = startTime.AddSeconds(_duration);  
        while (DateTime.Now < endTime)  
        {  
            Console.Write("Breathe in...");  
            ShowCountDown(4); 

            Console.Write("Now breathe out...");  
            ShowCountDown(4); 

            Console.WriteLine(); 

        }  
        DisplayEndingMessage(); 
    }
} 
