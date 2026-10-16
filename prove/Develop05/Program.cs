using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: I added a leveling system where the player
        // gains a level for every 500 points earned.
        // The program displays the player's current level
        // and celebrates whenever they reach a new level.
        // This adds an extra reward beyond the required points system.

        GoalManager manager = new GoalManager();
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine("\nWelcome to the Eternal Quest Program!");
            manager.DisplayScore();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;

                case "2":
                    manager.ListGoals();
                    break;

                case "3":
                    manager.SaveGoals();
                    break;

                case "4":
                    manager.LoadGoals();
                    break;

                case "5":
                    manager.RecordEvent();
                    break;

                case "6":
                    Console.WriteLine("Thanks for playing Eternal Quest!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
