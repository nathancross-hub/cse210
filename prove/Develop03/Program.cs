using System;

// Esceeding reqirements:
// The program only selects words that have not already been hidden
// which makes sure that each time the user presses enter, new words
// are hidden instead of possibly selecting words that are already hidden.

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";

        Scripture scripture = new Scripture(reference, text);

        string userInput = "";

        while (userInput != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();

            if (userInput != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        Console.Clear();

        if (scripture.IsCompletelyHidden())
        {
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}