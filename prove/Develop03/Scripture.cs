using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(string referenceText, string text)
    {
        _reference = CreateReference(referenceText);
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    private Reference CreateReference(string referenceText)
    {
        string[] parts = referenceText.Split(' ');
        string book = parts[0];
        string[] chapterVerse = parts[1].Split(':');
        int chapter = int.Parse(chapterVerse[0]);
        string[] verseParts = chapterVerse[1].Split('-');

        int verse = int.Parse(verseParts[0]);
        int endVerse = verseParts.Length > 1 ? int.Parse(verseParts[1]) : -1;

        return new Reference(book, chapter, verse, endVerse);
    }

    public void HideRandomWords(int numberToHide)
    {
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
        string ScriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{ScriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}