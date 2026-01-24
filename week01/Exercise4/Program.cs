using System;

class Program
{
    static void Main(string[] args)
    {
        // initialize empty list
        List<int> nums = [];

        // get list of nums from user
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int entry = 1;
        while (entry != 0)
        {
            Console.Write("Enter number: ");
            entry = int.Parse(Console.ReadLine());
            if (entry != 0)
                nums.Add(entry);
        }

        // calc sum
        int sum = nums.Sum();
        Console.WriteLine($"\nThe sum is: {sum}");

        // calc average
        try
        {
            double avg = nums.Average();
            Console.WriteLine($"The average is: {avg}");
        }
        catch
        {
            Console.WriteLine("The average is: 0");
        }

        // calc max
        try
        {
            int max = nums.Max();
            Console.WriteLine($"The largest number is: {max}");
        }
        catch
        {
            Console.WriteLine("The largest number is: 0");
        }

        // calculate smallest number > 0
        List<int> minList = nums.FindAll(n => n > 0);
        int min = 0;
        if (minList.Count > 0)
        {
            min = minList.Min();
            Console.WriteLine($"The smallest positive number is: {min}");
        }
        else
        {
            Console.WriteLine("The smallest positive number is: (no positive numbers found)");
        }

        // sort and display list
        Console.WriteLine("The sorted list is:");
        nums.Sort();
        nums.ForEach((n) =>
        {
            Console.WriteLine(n);
        });
    }
}