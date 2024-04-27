using System;

class Program
{
    static void Main(string[] args)
    {
                    // Create a Random object to generate random numbers
            Random randomGenerator = new Random();

            // Generate a random magic number between 1 and 100
            int magicNumber = randomGenerator.Next(1, 101);

            // Initialize a variable to keep track of the number of guesses
            int numberOfGuesses = 0;

            // Start the game loop
            while (true)
            {
                // Ask the user for their guess
                Console.Write("What is your guess? ");
                int guess = int.Parse(Console.ReadLine());

                // Increment the number of guesses
                numberOfGuesses++;

                // Check if the guess matches the magic number
                if (guess == magicNumber)
                {
                    Console.WriteLine("You guessed it!");
                    break; // Exit the loop if the guess is correct
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Lower");
                }
            }

            // Display the number of guesses after the game is over
            Console.WriteLine($"Number of guesses: {numberOfGuesses}");

            // Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no) ");
            string playAgain = Console.ReadLine();

            // Check if the user wants to play again
            if (playAgain.ToLower() == "yes")
            {
                // Restart the game by generating a new magic number
                Main(null);
            }
            else
            {
                // End the program if the user does not want to play again
                Console.WriteLine("Thank you for playing!");
            }

    }
}