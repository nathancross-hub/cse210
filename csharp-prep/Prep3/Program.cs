using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);
        Console.WriteLine(number);
        int guess = -1;
        while (guess != number) {
        Console.WriteLine("Please guess the number: ");
        string gues = Console.ReadLine();
        guess = int.Parse(gues);
        if (guess < number)
        {
            Console.WriteLine("Higher!");
        }
        else if (guess > number)
        {
            Console.WriteLine("Lower!");
        }
        }
        Console.WriteLine("That was the number, congrats!");
    }
}