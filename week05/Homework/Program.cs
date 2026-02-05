using System;
using Homework;

class Program
{
    static void Main(string[] args)
    {
        const string name = "Cayden Lunt";
        const string topic = "WDD231";
        const string mathSection = "10.2";
        const string mathProblems = "10-15";

        Console.WriteLine("Assignment");
        Console.WriteLine("--------------------------------------");
        Assignment assignment = new(name, topic);
        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine("--------------------------------------\n\n");

        Console.WriteLine("Math Assignment");
        Console.WriteLine("--------------------------------------");
        MathAssignment math = new(name, topic, mathSection, mathProblems);
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());
        Console.WriteLine("--------------------------------------\n\n");

        Console.WriteLine("Writing Assignment");
        Console.WriteLine("--------------------------------------");
        WritingAssignment writingAssignment = new(name, topic, "To Kill A Mocking Bird Essay");
        Console.WriteLine(writingAssignment.GetWritingInformation());
        Console.WriteLine("--------------------------------------\n");
    }
}