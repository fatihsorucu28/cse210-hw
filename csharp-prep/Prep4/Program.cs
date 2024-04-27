using System;

class Program
{
    static void Main(string[] args)
    {
                    // Create a list to store numbers
            List<int> numbers = new List<int>();

            // Ask the user for numbers until they enter 0
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            while (true)
            {
                Console.Write("Enter number: ");
                int input = int.Parse(Console.ReadLine());

                // Check if the input is 0, if yes, break the loop
                if (input == 0)
                    break;

                // Add the number to the list
                numbers.Add(input);
            }

            // Compute the sum of the numbers
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            // Compute the average of the numbers
            double average = (double)sum / numbers.Count;

            // Find the maximum number in the list
            int max = int.MinValue;
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            // Display the results
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");

            // Stretch challenge: Find the smallest positive number
            int minPositive = int.MaxValue;
            foreach (int number in numbers)
            {
                if (number > 0 && number < minPositive)
                {
                    minPositive = number;
                }
            }
            Console.WriteLine($"The smallest positive number is: {minPositive}");

            // Stretch challenge: Sort the list
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            } 
    }
}