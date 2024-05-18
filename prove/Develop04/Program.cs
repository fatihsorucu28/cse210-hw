using System;
using System.Threading;

// Base class for Mindfulness Activities
public abstract class MindfulnessActivity
{
    protected string name;
    protected string description;
    protected int duration;

    public void StartActivity()
    {
        Console.WriteLine($"Starting {name}...");
        Console.WriteLine(description);
        Console.Write("Enter duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Pause(3);
        RunActivity();
        EndActivity();
        LogActivity();
    }

    protected void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected abstract void RunActivity();

    private void EndActivity()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {name} for {duration} seconds.");
        Pause(3);
    }

    private void LogActivity()
    {
        string log = $"{DateTime.Now}: Completed {name} for {duration} seconds.\n";
        System.IO.File.AppendAllText("activity_log.txt", log);
    }
}

// Breathing Activity class
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        name = "Breathing Activity";
        description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void RunActivity()
    {
        int halfDuration = duration / 2;
        for (int i = 0; i < halfDuration; i++)
        {
            Console.WriteLine("Breathe in...");
            Pause(2);
            Console.WriteLine("Breathe out...");
            Pause(2);
        }
    }
}

// Reflection Activity class
public class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        name = "Reflection Activity";
        description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    protected override void RunActivity()
    {
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Length)];
        Console.WriteLine(prompt);
        Pause(5);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string question = Questions[random.Next(Questions.Length)];
            Console.WriteLine(question);
            Pause(5);
        }
    }
}

// Listing Activity class
public class ListingActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        name = "Listing Activity";
        description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void RunActivity()
    {
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Length)];
        Console.WriteLine(prompt);
        Pause(5);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int count = 0;

        Console.WriteLine("Start listing items:");
        while (DateTime.Now < endTime)
        {
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"You listed {count} items.");
    }
}

// Main program class
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            string choice = Console.ReadLine();
            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please select again.");
                    continue;
            }

            activity.StartActivity();
        }
    }
}
