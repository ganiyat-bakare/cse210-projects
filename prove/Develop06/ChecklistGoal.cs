using System;


public class ChecklistGoal : Goal  
{  
    private int _amountCompleted;  
    private int _target;  
    private int _bonus;  

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0) : base(name, description, points)  
    {  
        _amountCompleted = amountCompleted;  
        _target = target;  
        _bonus = bonus;  
    }  

    public override void RecordEvent()
    {
        _amountCompleted++;
        Console.WriteLine($"Progress made! Completed {_amountCompleted}/{_target}.");

        if (_amountCompleted >= _target)
        {
            Console.WriteLine($"Checklist goal completed! +{_bonus} bonus points!");
            _points += _bonus;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{(IsComplete() ? "[X]" : "[ ]")} {_shortName}  ({_description}) : {_points} points, --Currently completed {_amountCompleted}/{_target}, Bonus: {_bonus}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_amountCompleted}|{_target}|{_bonus}";
    }
}
