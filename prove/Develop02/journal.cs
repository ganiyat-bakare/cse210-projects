using System;  
using System.Collections.Generic;  
using System.IO;  

public class Journal  
{  
    private List<Entry> _entries;  

    public Journal()  
    {  
        _entries = new List<Entry>();  
    }  

    public void AddEntry(Entry entry)  
    {  
        _entries.Add(entry);  
    }  

    public void DisplayEntries()  
    {  
        foreach (var entry in _entries)  
        {  
            entry.Display();  
        }  
    }  

    public void SaveToFile(string filename)  
    {  
        using (StreamWriter writer = new StreamWriter(filename))  
        {  
            foreach (var entry in _entries)  
            {  
                // Write each entry to the file with the date, prompt, response, and mood  
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}|{entry.Mood}");  
            }  
        }  
    }  

    public void LoadFromFile(string filename)  
    {  
        _entries.Clear(); // Clear current entries  
        string[] lines = File.ReadAllLines(filename); // Read all lines from the file  

        foreach (string line in lines)  
        {  
            var parts = line.Split('|');  
            if (parts.Length == 4)  // Expecting 4 parts: date, prompt, response, mood  
            {  
                AddEntry(new Entry(parts[0], parts[1], parts[2], parts[3]));  
            }  
        }  
    }  

    public void AddNewEntry(string prompt, string response, string mood)  
    {  
        // Get the current date as a string in short format  
        string date = DateTime.Now.ToShortDateString();  
        Entry newEntry = new Entry(date, prompt, response, mood);  
        AddEntry(newEntry);  
    }  
}