using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Please enter a number. When you are finished, enter 0. ");
        int input = 1;
        while (input != 0) {
        Console.Write("Enter Number: ");
        string inp = Console.ReadLine();
        input = int.Parse(inp);
        numbers.Add(input);
        }
        int total = 0;
        int count = 0;
        int largest = -999999999;
        int smallest = 999999999;
        for (int i = 0; i < numbers.Count; i++)
        {
            total = total + numbers[i];
            count = count + 1;
            if (numbers[i] < smallest && numbers[i] != 0)
            {
                smallest = numbers[i];
            }
            if (numbers[i] > largest)
            {
                largest = numbers[i];
            }
        }
        count = count - 1;
        float avg = (float)total / count;
        Console.WriteLine(total);
        Console.WriteLine(avg);
        Console.WriteLine(count);
        Console.WriteLine(smallest);
        Console.WriteLine(largest);
        
    }
}