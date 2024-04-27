using System;

class Program
{

            // Function to display welcome message
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        // Function to prompt user for name and return it
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        // Function to prompt user for favorite number and return it
        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        // Function to square a number and return the result
        static int SquareNumber(int number)
        {
            return number * number;
        }

        // Function to display the user's name and squared number
        static void DisplayResult(string userName, int squaredNumber)
        {
            Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
        }
    static void Main(string[] args)
    {
                    // Call DisplayWelcome function
            DisplayWelcome();

            // Call PromptUserName function and save the returned value
            string userName = PromptUserName();

            // Call PromptUserNumber function and save the returned value
            int userNumber = PromptUserNumber();

            // Call SquareNumber function and save the returned value
            int squaredNumber = SquareNumber(userNumber);

            // Call DisplayResult function with the user's name and squared number
            DisplayResult(userName, squaredNumber);
        }



    }
