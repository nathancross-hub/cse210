using System;
using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }
        string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }
        int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string number = Console.ReadLine();
            int favoriteNumber = int.Parse(number);
            return favoriteNumber;
        }
        void PromptUserBirthYear(out int birthYear)
        {
            Console.Write("Please enter your birth year: ");
            string year = Console.ReadLine();
            birthYear = int.Parse(year);
        }
        int SquareNumber(int number)
        {
            int squaredNumber = number * number;
            return squaredNumber;
        }
        void DisplayResult(string name, int squaredNumber, int birthYear)
        {
            int age = 2026 - birthYear;
            Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
            Console.WriteLine($"{name}, you will turn {age} this year.");
        }

        DisplayWelcome();
        string name = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int birthYear;
        PromptUserBirthYear(out birthYear);
        int squaredNumber = SquareNumber(favoriteNumber);
        DisplayResult(name, squaredNumber, birthYear);

    }
}


/*

DisplayResult - Accepts the user's name, the squared number, and the user's birth year. Display 
the user's name and squared number. Calculate hold many years old they will turn this year and 
display that.

*/