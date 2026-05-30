using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    // =========================================================================
    // 1. COMMENT CLASS
    // =========================================================================
    public class Comment
    {
        public string CommenterName { get; set; }
        public string CommentText { get; set; }

        public Comment(string name, string text)
        {
            CommenterName = name;
            CommentText = text;
        }
    }

    // =========================================================================
    // 2. VIDEO CLASS
    // =========================================================================
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }

        // This video holds a list of Comment objects
        private List<Comment> _comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            _comments = new List<Comment>();
        }
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        // Return the total number of comments
        public int GetCommentCount()
        {
            return _comments.Count;
        }

        public List<Comment> GetComments()
        {
            return _comments;
        }
    }

    // =========================================================================
    // 3. PROGRAM CLASS
    // =========================================================================
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store our video objects
            List<Video> videoList = new List<Video>();

            // -----------------------------------------------------------------
            // VIDEO 1
            // -----------------------------------------------------------------
            Video video1 = new Video("C# Programming for Beginners", "CodeAcademy", 720);
            video1.AddComment(new Comment("Roman", "This explained object abstraction perfectly!"));
            video1.AddComment(new Comment("Anna", "Are there going to be more videos on inheritance?"));
            video1.AddComment(new Comment("Omar", "Great pacing, thank you."));
            videoList.Add(video1);

            // -----------------------------------------------------------------
            // VIDEO 2
            // -----------------------------------------------------------------
            Video video2 = new Video("How to Cook the Perfect Steak", "Chef Gordon", 450);
            video2.AddComment(new Comment("David", "Tried this tonight, it turned out amazing."));
            video2.AddComment(new Comment("Emma", "Mine got a bit charred, maybe my pan was too hot?"));
            video2.AddComment(new Comment("Jerome", "The butter basting technique is a game changer."));
            videoList.Add(video2);

            // -----------------------------------------------------------------
            // VIDEO 3
            // -----------------------------------------------------------------
            Video video3 = new Video("SpaceX Mars Mission Update 2026", "Cosmos Today", 1100);
            video3.AddComment(new Comment("Grace", "Unbelievable progress being made this year."));
            video3.AddComment(new Comment("Hank", "I hope we see a manned landing in my lifetime."));
            video3.AddComment(new Comment("Ivy", "The engineering behind these rockets is insane."));
            videoList.Add(video3);

            // -----------------------------------------------------------------
            
            Console.WriteLine("==================================================");
            Console.WriteLine("           YOUTUBE VIDEO TRACKING REPORT          ");
            Console.WriteLine("==================================================\n");

            foreach (Video video in videoList)
            {
                Console.WriteLine($"Title:  {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");

                // Nested loop to abstractly pull the comments belonging to this specific video
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"  - {comment.CommenterName}: \"{comment.CommentText}\"");
                }

                // Separation divider between videos
                Console.WriteLine("\n--------------------------------------------------\n");
            }
        }
    }
}