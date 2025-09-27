using System;
using System.Collections.Generic;

public class Video
{
    public string Title  { get; set; }
    public string Author { get; set; }
    public int    Length { get; set; } // seconds

    private readonly List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title  = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (Comment c in _comments)
        {
            c.Display();
        }
    }
}
