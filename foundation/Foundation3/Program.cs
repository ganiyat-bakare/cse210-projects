using System;  
using System.Collections.Generic;  

public class Program  
{  
    public static void Main(string[] args)  
    {  
        List<Activity> activities = new List<Activity>  
        {  
            new Running(DateTime.Parse("2022-11-03"), 30, 3.0),  
            new Cycling(DateTime.Parse("2022-11-04"), 45, 12.0),  
            new Swimming(DateTime.Parse("2022-11-05"), 30, 20)  
        };  

        foreach (Activity activity in activities)  
        {  
            Console.WriteLine(activity.GetSummary());  
        }  
    }  
}