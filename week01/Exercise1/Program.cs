using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string fName = Console.ReadLine().Trim();
        if (!string.IsNullOrEmpty(fName))
            fName = char.ToUpper(fName[0]) + fName[1..];

        Console.Write("What is your last name? ");
        string lName = Console.ReadLine().Trim();
        if (!string.IsNullOrEmpty(lName))
            lName = char.ToUpper(lName[0]) + lName[1..];

        Console.WriteLine($"Your name is {lName}, {fName} {lName}.");
    }
}