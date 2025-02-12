using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            // Prompt user for input
            Console.WriteLine("Enter numbers separated by spaces:");
            string input = Console.ReadLine();

            // Convert input to a list of integers
            List<int> numbers = input.Split(' ')// gives array
                                     .Select(n => int.Parse(n.Trim()))// converets string to int types 
                                     .ToList();//returns list

            // Thread-safe collection for storing results
            ConcurrentDictionary<int, int> results = new ConcurrentDictionary<int, int>();

            // Parallel processing with exception handling inside
            Parallel.ForEach(numbers, number =>
            {
                try
                {
                    int squared = number * number; // Perform computation
                    results[number] = squared; // Store result safely
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing number {number}: {ex.Message}");
                }
            });

            // Ensure ordered output
            Console.WriteLine("Squared results:");
            foreach (var key in numbers) // Maintain input order
            {
                Console.WriteLine($"{key}^2 = {results[key]}");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter only numbers separated by spaces.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
