using System;  
using System.Collections.Generic;    
using System.IO;

public class GoalManager  
{  
    private List<Goal> _goals;  
    private int _score;  
    
    public GoalManager()  
    {  
        _goals = new List<Goal>();  
        _score = 0;  
    }  
    
    public void Start()  
    {  
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("Welcome to the Eternal Quest Program!");
        Console.WriteLine(new string('=', 50));  
        Console.WriteLine();  

        DisplayPlayerInfo();

        while (true)  
        {  
            Console.WriteLine("Quest Tracking Menu Options:");   
            Console.WriteLine("1. Create Goal");  
            Console.WriteLine("2. List Goals");  
            Console.WriteLine("3. Save Goals");  
            Console.WriteLine("4. Load Goals");  
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Show Statistics");  
            Console.WriteLine("7. Quit");  
            Console.Write("Select a choice from the menu: ");  
            string choice = Console.ReadLine();  
            switch (choice)  
            {  
                case "1":  
                    CreateGoal();  
                    break;  
                case "2":  
                    ListGoalDetails();  
                    break;  
                case "3":  
                    SaveGoals();  
                    break;  
                case "4":  
                    LoadGoals();  
                    break;  
                case "5":  
                    RecordEvent();  
                    break;
                case "6":
                    ShowStatistics();
                    break;  
                case "7":  
                    return;    
                default:  
                    Console.WriteLine("Invalid choice. Please try again.");  
                    break;  
            }  
            Console.WriteLine();

            DisplayPlayerInfo();   
        }  
    }  
    
    private void DisplayPlayerInfo()  
    {  
        Console.WriteLine($"You have {_score} points.");   
        Console.WriteLine();   
    }

    
    private void CreateGoal()  
    {  
        Console.WriteLine("The Goal types are:");   
        Console.WriteLine("1. Simple Goal");  
        Console.WriteLine("2. Eternal Goal");   
        Console.WriteLine("3. Checklist Goal");  
        Console.Write("What type of goal would you like to create? ");  

        string choice = Console.ReadLine();  

        Console.Write("What is the name of your goal? ");  
        string name = Console.ReadLine();  

        Console.Write("Write a short description of your goal? ");  
        string description = Console.ReadLine();  

        Console.Write("What is the amount of points associated with this goal? ");  
        int points = int.Parse(Console.ReadLine());  

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice. Goal creation failed.");
                break;
        }
        Console.WriteLine();
    }


    public void ListGoalDetails()
    {

         Console.WriteLine("Your goals are:");  
        for (int i = 0; i < _goals.Count; i++)  
        {  
            var goal = _goals[i];  
        
            Console.WriteLine($"{i + 1}. {goal.GetDetailsString()}");  
        }  
    }


    private void SaveGoals()  
    {  
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }


    public void LoadGoals()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _goals.Clear(); 

            using (StreamReader reader = new StreamReader(filename))
            {
                _score = int.Parse(reader.ReadLine()); 

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string goalType = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    if (goalType == "SimpleGoal")
                    {
                        bool isComplete = bool.Parse(parts[4]);
                        _goals.Add(new SimpleGoal(name, description, points, isComplete));
                    }
                    else if (goalType == "EternalGoal")
                    {
                        _goals.Add(new EternalGoal(name, description, points));
                    }
                    else if (goalType == "ChecklistGoal")
                    {
                        int amountCompleted = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int bonus = int.Parse(parts[6]);
                        _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                    }
                }
            }
            Console.WriteLine("Goals successfully loaded!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }


    public void RecordEvent()  
    {  
        Console.WriteLine();
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            Console.Write("Select a goal index to record an event:");
        }

        int choice = int.Parse(Console.ReadLine());

        if (choice > 0 && choice <= _goals.Count)
        {
            Goal goal = _goals[choice - 1];
            goal.RecordEvent();

            if (goal.IsComplete())  
            {  
                _score += goal.Points;  
                Console.WriteLine($"{goal.GetStringRepresentation()} has been completed.");  
            }  
        }
        else
        {
            Console.WriteLine("Invalid index selected.");
        }  
    }   


    private void ShowStatistics()  
    {  
        int completedCount = 0;  
        int totalPoints = 0;  

        foreach (var goal in _goals)  
        {  
            if (goal.IsComplete())  
            {  
                completedCount++;  
            }  
            totalPoints += goal.Points;  
        }  

        Console.WriteLine($"Total Goals: {_goals.Count}, Completed Goals: {completedCount}, Total Points: {totalPoints}");  
    }  

}