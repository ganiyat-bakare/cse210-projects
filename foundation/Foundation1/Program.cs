using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold videos
        List<Video> videos = new List<Video>
        {
            new Video("Introduction to Programming", "Steven Gold", 300),
            new Video("Programming with Functions", "David Emrich", 450),
            new Video("Programming with Classes", "Duane Richards", 600),
            new Video("Web Fundamentals", "Ralph Borcherds", 480)
        };

        // Add comments to the videos
        videos[0].AddComment(new Comment("George", "Great introduction to Programming!"));
        videos[0].AddComment(new Comment("John", "I love the way you introduced the programming concept."));
        videos[0].AddComment(new Comment("Chloe", "Very helpful, thanks!"));
        
        videos[1].AddComment(new Comment("Lisa", "Can't wait for more content."));
        videos[1].AddComment(new Comment("Jane", "This cleared many doubts I had."));

        videos[2].AddComment(new Comment("Luis", "Loved the detailed explanation."));
        videos[2].AddComment(new Comment("Jack", "Next, could you cover Encapsulation?"));
        videos[2].AddComment(new Comment("Tatiana", "Very useful for my projects!"));

        videos[3].AddComment(new Comment("Celia", "Great introduction to Web development!"));
        videos[3].AddComment(new Comment("Precious", "Can you please share more contents on Web Fundamentals?"));
        videos[3].AddComment(new Comment("Luke", "Web Fundamentals is so interesting."));
        videos[3].AddComment(new Comment("Tyler", "Clear and coincise, thank you!"));

        //Display information about each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._lengthInSec}seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment._person}: {comment._text}");
            }

            Console.WriteLine();
        }
    }
}
