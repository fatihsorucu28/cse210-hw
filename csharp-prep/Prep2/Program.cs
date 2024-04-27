using System;

class Program
{
    static void Main(string[] args)
    {
                    // Ask the user for their grade percentage
            Console.Write("Enter your grade percentage: ");
            string input = Console.ReadLine();
            int gradePercentage = int.Parse(input);

            // Determine the letter grade
            string letter;
            if (gradePercentage >= 90)
            {
                letter = "A";
            }
            else if (gradePercentage >= 80)
            {
                letter = "B";
            }
            else if (gradePercentage >= 70)
            {
                letter = "C";
            }
            else if (gradePercentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            // Determine if the user passed the course
            bool passed = gradePercentage >= 70;

            // Display the letter grade
            Console.WriteLine($"Your letter grade is: {letter}");

            // Display a message based on whether the user passed or not
            if (passed)
            {
                Console.WriteLine("Congratulations! You passed the course.");
            }
            else
            {
                Console.WriteLine("Keep working hard! You can do better next time.");
            }

    }
}