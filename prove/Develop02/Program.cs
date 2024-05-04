using System;
using System.Collections.Generic;
using System.IO;

// Class representing a single entry in the journal
class JournalEntry
{
    // Properties for prompt, response, and date
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    // Constructor to initialize the entry
    public JournalEntry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    // Override ToString() to format entry for display
    public override string ToString()
    {
        return $"{Date.ToShortDateString()}: {Prompt}\nResponse: {Response}\n";
    }
}

// Main Program class representing the journal
class Program
{
    // List to store journal entries
    private List<JournalEntry> entries = new List<JournalEntry>();

    // Method to write a new entry to the journal
    public void WriteNewEntry(string[] prompts)
    {
        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine();

        entries.Add(new JournalEntry(randomPrompt, response, DateTime.Now));
    }

    // Method to display all entries in the journal
    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    // Method to save the journal to a file
    public void SaveJournalToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }
    }

    // Method to load the journal from a file
    public void LoadJournalFromFile(string fileName)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                DateTime date = DateTime.Parse(parts[0]);
                string prompt = parts[1];
                string response = parts[2];
                entries.Add(new JournalEntry(prompt, response, date));
            }
        }
    }

    static void Main(string[] args)
    {
        Program journal = new Program();
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        // Main menu loop
        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                // Write a new journal entry
                case 1:
                    journal.WriteNewEntry(prompts);
                    break;
                // Display the journal
                case 2:
                    journal.DisplayJournal();
                    break;
                // Save the journal to a file
                case 3:
                    Console.Write("Enter file name to save: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveJournalToFile(saveFileName);
                    break;
                // Load the journal from a file
                case 4:
                    Console.Write("Enter file name to load: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadJournalFromFile(loadFileName);
                    break;
                // Exit the program
                case 5:
                    return;
                // Invalid choice
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
