using System;  

public class EternalGoal : Goal  
{  
    public EternalGoal(string name, string description, int points) : base(name, description, points)  
    {  
    }  

    public override void RecordEvent()  
    {  
        Console.WriteLine($"Eternal Goal recorded! +{_points} points.");
    }  

    public override bool IsComplete()  
    {  
        return false;  
    }

    public override string GetStringRepresentation()  
    {  
        return $"EternalGoal|{_shortName}|{_description}|{_points}";
    }  
}