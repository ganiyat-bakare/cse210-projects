using System;  

public abstract class Activity  
{  
    private DateTime date;  
    private int minutes;  

    public Activity(DateTime date, int minutes)  
    {  
        this.date = date;  
        this.minutes = minutes;  
    }  

    public string GetDate()  
    {  
        return date.ToString("dd MMM yyyy");  
    }  

    public int GetMinutes()  
    {  
        return minutes;  
    }  

    public abstract double GetDistance();  
    public abstract double GetSpeed();  
    public abstract double GetPace();  


    public virtual string GetSummary()  
    {  
        return $"{GetDate()} - Duration: {GetMinutes()} min, " +  
               $"Distance: {GetDistance():F1} miles, " +  
               $"Speed: {GetSpeed():F1} mph, " +  
               $"Pace: {GetPace():F2} min per mile";  
    }  
}