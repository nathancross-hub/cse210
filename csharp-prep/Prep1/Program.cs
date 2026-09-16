using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string fname = Console.ReadLine();
        Console.Write("What is your last name? ");
        string lname = Console.ReadLine();
        Console.WriteLine(" ");
        Console.WriteLine($"Your name is {lname}, {fname} {lname}. ");
    }
}


/*
What is your first name? Scott
What is your last name? Burton

Your name is Burton, Scott Burton.
*/