using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;     
    private List<Word> _words; 

    public Scripture(string referenceText, string text)
    {
        _reference = Reference.CreateReference(referenceText);
        _words = text.Split(' ').Select(word => new Word(word)).ToList(); 
    }
    
    public int GetRemainingWordCount()
    {
        return _words.Count(w => !w.IsHidden());
    }

    public void HideRandomWords(int numberToHide)
    {
        int remainingWords = GetRemainingWordCount();

        if (numberToHide > remainingWords)
        {
            numberToHide = remainingWords;
        }

        if (numberToHide <= 0)
        {
            Console.WriteLine("No words to hide. Please enter a positive number.");
            return;
        }

        Random random = new Random();
        int count = 0;

        while (count < numberToHide)
        {
            int index = random.Next(_words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                count++;
            }
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}
