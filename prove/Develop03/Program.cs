using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create a new Scripture object
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        // Display the complete scripture
        DisplayScripture(scripture);

        // Prompt the user to press enter or type quit
        Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
        string input = Console.ReadLine();

        while (input.ToLower() != "quit")
        {
            // Hide a few random words in the scripture
            scripture.HideRandomWords();

            // Clear the console and display the updated scripture
            Console.Clear();
            DisplayScripture(scripture);

            // Check if all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Press Enter to exit.");
                break;
            }

            // Prompt the user again
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            input = Console.ReadLine();
        }
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.WriteLine(scripture.GetDisplayText());
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(string reference, string text)
    {
        _reference = new Reference(reference);
        _words = new List<Word>();

        // Split text into words
        string[] words = text.Split(' ');

        // Create Word objects for each word
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, _words.Count / 2); // Hide up to half of the words
        int wordsHidden = 0;

        while (wordsHidden < wordsToHide)
        {
            int index = random.Next(0, _words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                wordsHidden++;
            }
        }
    }

    public string GetDisplayText()
    {
        string displayText = $"{_reference.GetDisplayText()}\n";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book)
    {
        _book = book;
        _chapter = 0; // Default chapter
        _verse = 0; // Default verse
        _endVerse = 0; // Default end verse
    }

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse == 0)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}


class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false; // By default, word is visible
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}
