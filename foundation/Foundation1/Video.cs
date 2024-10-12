using System;
using System.Transactions;

public class Video
{
    public string _title;
    public string _author;
    public int _lengthInSec;
    public List<Comment> _comments;

    public Video(string title, string author, int lengthInSec)
    {
        _title = title;
        _author = author;
        _lengthInSec = lengthInSec;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}
