using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = -1;
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public static Reference CreateReference(string referenceText)
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

    public string GetDisplayText()
    {
        return _endVerse != -1 ? $"{_book} {_chapter}:{_verse}-{_endVerse}" : $"{_book} {_chapter}:{_verse}";
    }
}