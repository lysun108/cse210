// YouTube Video Abstraction Program - Week 04 Foundation Project
// Name: Yang Liao
// Date: 09/26/2025

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("What is Abstraction?", "John Doe", 300);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Really helpful, thanks."));
        video1.AddComment(new Comment("Charlie", "Awesome content!"));
        videos.Add(video1);

        Video video2 = new Video("C# Basics", "Jane Smith", 450);
        video2.AddComment(new Comment("Dave", "Clear and concise."));
        video2.AddComment(new Comment("Eva", "Love the examples."));
        video2.AddComment(new Comment("Frank", "Very useful, thanks!"));
        videos.Add(video2);

        Video video3 = new Video("OOP Principles", "Mark Lee", 600);
        video3.AddComment(new Comment("Grace", "Super informative."));
        video3.AddComment(new Comment("Henry", "Helped me understand a lot."));
        video3.AddComment(new Comment("Ivy", "Keep it up!"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayInfo();
            Console.WriteLine();
        }
    }
}
