using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please Enter your grade percentage: ");
        string per = Console.ReadLine();
        float perc = float.Parse(per);
        string grade = "notDefined";
        if (perc >= 90)
        {
            grade = "A";
        }
        else if (perc >= 80)
        {
            grade = "B";
        }
        else if (perc >= 70)
        {
            grade = "C";
        }
        else if (perc >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }
        Console.WriteLine($"Your grade is {grade}.");
    }
}