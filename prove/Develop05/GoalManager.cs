
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nYou have {_score} points.");

        // Creativity: Players earn a new level every 500 points.
        int level = (_score / 500) + 1;
        Console.WriteLine($"Your current level is: {level}");
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        if (type != "1" && type != "2" && type != "3")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("How many points is it worth? ");
        if (!int.TryParse(Console.ReadLine(), out int points) || points < 0)
        {
            Console.WriteLine("Please enter a valid number of points.");
            return;
        }

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished? ");
            if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
            {
                Console.WriteLine("Please enter a positive target.");
                return;
            }

            Console.Write("What is the bonus for accomplishing it that many times? ");
            if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
            {
                Console.WriteLine("Please enter a valid bonus.");
                return;
            }

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nYou have no goals to record.");
            return;
        }

        ListGoals();

        Console.Write("Which goal did you accomplish? ");
        if (!int.TryParse(Console.ReadLine(), out int number) ||
            number < 1 || number > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[number - 1];
        int pointsEarned = goal.RecordEvent();

        if (pointsEarned > 0)
        {
            int oldLevel = (_score / 500) + 1;
            _score += pointsEarned;
            int newLevel = (_score / 500) + 1;

            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");

            if (newLevel > oldLevel)
            {
                Console.WriteLine($"LEVEL UP! You reached level {newLevel}!");
            }
        }
        else
        {
            Console.WriteLine("This goal is already complete.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What filename would you like to save to? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What filename would you like to load from? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            int loadedScore = int.Parse(lines[0]);
            List<Goal> loadedGoals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] typeAndData = lines[i].Split(':', 2);
                string type = typeAndData[0];
                string[] data = typeAndData[1].Split(',');

                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);

                if (type == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(data[3]);
                    loadedGoals.Add(new SimpleGoal(name, description, points, isComplete));
                }
                else if (type == "EternalGoal")
                {
                    loadedGoals.Add(new EternalGoal(name, description, points));
                }
                else if (type == "ChecklistGoal")
                {
                    int target = int.Parse(data[3]);
                    int bonus = int.Parse(data[4]);
                    int amountCompleted = int.Parse(data[5]);

                    loadedGoals.Add(new ChecklistGoal(
                        name, description, points, target, bonus, amountCompleted));
                }
            }

            _score = loadedScore;
            _goals = loadedGoals;

            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}
