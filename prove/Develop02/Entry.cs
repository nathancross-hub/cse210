using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _weight;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Weight: {_weight} lbs - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
    }
}