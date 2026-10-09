using System;

class Program
{
    // EXCEEDING REQUIREMENTS:
    // I added a feature that tracks how many times each activity
    // has been completed. The user can view their activity
    // statistics from the main menu.

    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        string choice = "";

        while (choice != "5")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View activity statistics");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                breathingCount++;
            }
            else if (choice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();
                reflectingCount++;
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                listingCount++;
            }
            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("Activity Statistics");
                Console.WriteLine();
                Console.WriteLine($"Breathing activities completed: {breathingCount}");
                Console.WriteLine($"Reflecting activities completed: {reflectingCount}");
                Console.WriteLine($"Listing activities completed: {listingCount}");
                Console.WriteLine();
                Console.WriteLine($"Total activities completed: {breathingCount + reflectingCount + listingCount}");
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
            else if (choice != "5")
            {
                Console.WriteLine("Invalid choice. Press Enter to try again.");
                Console.ReadLine();
            }
        }

        Console.WriteLine("Goodbye!");
    }
}
