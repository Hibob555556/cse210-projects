using System;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // build empty list to store videos
            var videos = new List<Video>();

            // build videos
            Video videoOne = new("Introduction to Programming and Computer Science - Full Course", "freeCodeCamp.org", 6500);
            videoOne.AddComment(new Comment("DevLearner", "This course really helped me start coding!"));
            videoOne.AddComment(new Comment("Anna", "Great overview of core concepts."));
            videoOne.AddComment(new Comment("Leo", "Perfect for beginners."));
            videos.Add(videoOne);

            var videoTwo = new Video("Learn How to Code - Programming for Beginners Tutorial", "freeCodeCamp.org", 3000);
            videoTwo.AddComment(new Comment("Coder99", "Very clear explanations!"));
            videoTwo.AddComment(new Comment("Jamie", "Loved the Python + C# intro."));
            videoTwo.AddComment(new Comment("Sam", "Good pace and examples."));
            videos.Add(videoTwo);

            var videoThree = new Video("How to Code in 30 Minutes - For Absolute Beginners", "Coding Tutorial", 1800);
            videoThree.AddComment(new Comment("Newbie", "Excellent intro."));
            videoThree.AddComment(new Comment("Chris", "Easy to follow."));
            videoThree.AddComment(new Comment("Alex", "Short but useful."));
            videos.Add(videoThree);

            var videoFour = new Video("C Programming Full Course for Beginners", "Programming Academy", 10800);
            videoFour.AddComment(new Comment("CoderFan", "Lots of detail here."));
            videoFour.AddComment(new Comment("DevPro", "Good explanations of concepts."));
            videoFour.AddComment(new Comment("Kim", "Helpful for C basics."));
            videos.Add(videoFour);

            foreach (Video vid in videos)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"Title:  {vid.Title}");
                Console.WriteLine($"Author: {vid.Author}");
                Console.WriteLine($"Length: {vid.Length} seconds");
                Console.WriteLine($"Comments ({vid.GetNumberOfComments()}):");

                foreach (var comment in vid.GetComments())
                {
                    Console.WriteLine($"  - {comment.Name}: {comment.Text}");
                }

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            }
        }
    }
}