using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction();
        Random random = new Random();
        for (int i = 1; i <= 20; i++)
        {
            int top = random.Next(1, 11);
            int bottom = random.Next(1, 11);
        
            fraction.SetTop(top);
            fraction.SetBottom(bottom);
        
            Console.WriteLine($"Fraction {i}: string: {fraction.GetFractionString()} Number: {fraction.GetDecimalValue()}");
        }
    }
}