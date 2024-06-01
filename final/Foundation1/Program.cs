using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public override string ToString()
    {
        return $"{Name}: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // length in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int NumberOfComments()
    {
        return comments.Count;
    }

    public override string ToString()
    {
        return $"Title: {Title}\nAuthor: {Author}\nLength: {Length} seconds\nNumber of comments: {NumberOfComments()}";
    }

    public void DisplayComments()
    {
        foreach (var comment in comments)
        {
            Console.WriteLine(comment);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create video instances
        Video video1 = new Video("Python Tutorial", "John Doe", 600);
        Video video2 = new Video("Cooking Pasta", "Jane Smith", 300);
        Video video3 = new Video("Guitar Lesson", "Emily Davis", 1200);
        Video video4 = new Video("Travel Vlog", "Chris Brown", 900);

        // Create comment instances and add to videos
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Could you do one on OOP?"));

        video2.AddComment(new Comment("Dave", "Yummy recipe!"));
        video2.AddComment(new Comment("Eve", "I tried this and it was delicious."));
        video2.AddComment(new Comment("Frank", "Quick and easy to follow."));

        video3.AddComment(new Comment("Grace", "I love this lesson."));
        video3.AddComment(new Comment("Heidi", "Can you cover more songs?"));
        video3.AddComment(new Comment("Ivan", "The best guitar lesson ever!"));

        video4.AddComment(new Comment("Judy", "Amazing places!"));
        video4.AddComment(new Comment("Mallory", "Wish I could go there."));
        video4.AddComment(new Comment("Niaj", "Thanks for sharing!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display information about each video
        foreach (var video in videos)
        {
            Console.WriteLine(video);
            Console.WriteLine("Comments:");
            video.DisplayComments();
            Console.WriteLine("\n" + new string('-', 40) + "\n");
        }
    }
}
