using System;

class Program
{
    static string CapitalizeString(string str) =>
        string.IsNullOrEmpty(str) ? str : char.ToUpper(str[0]) + str[1..];

    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string fName = CapitalizeString(Console.ReadLine()?.Trim() ?? "");

        Console.Write("What is your last name? ");
        string lName = CapitalizeString(Console.ReadLine()?.Trim() ?? "");

        Console.WriteLine($"Your name is {lName}, {fName} {lName}.");
    }
}