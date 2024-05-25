using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public abstract class Goal
    {
        private string _shortName;
        private string _description;
        private int _points;

        protected Goal(string name, string description, int points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }

        public string Name => _shortName;
        public string Description => _description;
        public int Points => _points;

        public abstract void RecordEvent();
        public abstract bool IsComplete();
        public abstract string GetStringRepresentation();

        public virtual string GetDetailsString()
        {
            return $"{_shortName}: {_description} - Points: {_points}";
        }
    }

    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _isComplete = false;
        }

        public override void RecordEvent()
        {
            _isComplete = true;
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{Name},{Description},{Points},{_isComplete}";
        }
    }

    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override void RecordEvent()
        {
            // Eternal goals gain points every time they are recorded
        }

        public override bool IsComplete()
        {
            return false; // Eternal goals are never complete
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{Name},{Description},{Points}";
        }
    }

    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int target, int bonus)
            : base(name, description, points)
        {
            _amountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }

        public override void RecordEvent()
        {
            _amountCompleted++;
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{Name},{Description},{Points},{_amountCompleted},{_target},{_bonus}";
        }

        public override string GetDetailsString()
        {
            return $"{Name}: {Description} - Points: {Points}, Completed: {_amountCompleted}/{_target}, Bonus: {_bonus}";
        }

        public int GetBonusPoints()
        {
            return _bonus;
        }
    }

    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int totalPoints = 0;

        static void Main(string[] args)
        {
            LoadGoals();

            while (true)
            {
                Console.WriteLine("Eternal Quest");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. Record Event");
                Console.WriteLine("3. Show Goals");
                Console.WriteLine("4. Display Score");
                Console.WriteLine("5. Save Goals");
                Console.WriteLine("6. Load Goals");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewGoal();
                        break;
                    case "2":
                        RecordEvent();
                        break;
                    case "3":
                        ShowGoals();
                        break;
                    case "4":
                        DisplayScore();
                        break;
                    case "5":
                        SaveGoals();
                        break;
                    case "6":
                        LoadGoals();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void CreateNewGoal()
        {
            Console.WriteLine("Select Goal Type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");

            string type = Console.ReadLine();

            Console.Write("Enter Goal Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Goal Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Goal Points: ");
            int points = int.Parse(Console.ReadLine());

            Goal newGoal;

            switch (type)
            {
                case "1":
                    newGoal = new SimpleGoal(name, description, points);
                    break;
                case "2":
                    newGoal = new EternalGoal(name, description, points);
                    break;
                case "3":
                    Console.Write("Enter Target Number of Completions: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Enter Bonus Points: ");
                    int bonus = int.Parse(Console.ReadLine());
                    newGoal = new ChecklistGoal(name, description, points, target, bonus);
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    return;
            }

            goals.Add(newGoal);
        }

        static void RecordEvent()
        {
            Console.WriteLine("Select Goal to Record Event:");

            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].Name}");
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < goals.Count)
            {
                goals[index].RecordEvent();
                totalPoints += goals[index].Points;
                if (goals[index] is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
                {
                    totalPoints += checklistGoal.GetBonusPoints(); // Bonus points
                }
                Console.WriteLine("Event Recorded.");
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        static void ShowGoals()
        {
            foreach (var goal in goals)
            {
                string status = goal.IsComplete() ? "[X]" : "[ ]";
                Console.WriteLine($"{status} {goal.GetDetailsString()}");
            }
        }

        static void DisplayScore()
        {
            Console.WriteLine($"Total Points: {totalPoints}");
        }

        static void SaveGoals()
        {
            using (StreamWriter outputFile = new StreamWriter("goals.txt"))
            {
                outputFile.WriteLine(totalPoints);
                foreach (var goal in goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved.");
        }

        static void LoadGoals()
        {
            if (File.Exists("goals.txt"))
            {
                string[] lines = File.ReadAllLines("goals.txt");
                totalPoints = int.Parse(lines[0]);
                goals.Clear();

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(':');
                    string type = parts[0];
                    string[] details = parts[1].Split(',');

                    switch (type)
                    {
                        case "SimpleGoal":
                            goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2])));
                            break;
                        case "EternalGoal":
                            goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                            break;
                        case "ChecklistGoal":
                            goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[4])));
                            break;
                    }
                }

                Console.WriteLine("Goals loaded.");
            }
            else
            {
                Console.WriteLine("No saved goals found.");
            }
        }
    }
}
