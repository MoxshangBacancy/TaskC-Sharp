using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a sentence: ");
        string input = Console.ReadLine();

        string reversedSentence = ReverseWords(input);
        Console.WriteLine("Reversed Sentence: " + reversedSentence);
    }

    static string ReverseWords(string sentence)

    {
        //direct using function.

        //string[] words = sentence.Split(' ');
        //Array.Reverse(words);
        //return string.Join(" ", words);
        // Split the sentence into words
        string[] words = sentence.Split(' ');

        // Initialize an empty string to store the reversed sentence
        string reversed = "";

        // Iterate over the words array from the end to the beginning
        for (int i = words.Length - 1; i >= 0; i--)
        {
            reversed += words[i]; // Add each word in reverse order

            // Add space between words (except after the last word)
            if (i != 0)
            {
                reversed += " ";
            }
        }

        // Return the reversed sentence
        return reversed;
    }
}
