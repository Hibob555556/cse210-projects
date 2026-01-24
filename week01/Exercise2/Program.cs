using System;

class Program
{
    static char getPlusMinus(float grade)
    {
        // prevent F-/+ and A+
        if (grade >= 60.0 && grade <= 93.0)
        {
            int truncatedGrade = (int)Math.Truncate(grade);
            char part = ' ';
            int last = truncatedGrade % 10;
            if (last >= 7)
                part = '+';
            else if (last < 3)
                part = '-';
            return part;
        }
        return ' ';
    }

    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        float gradePercentage = float.Parse(Console.ReadLine());

        if (gradePercentage > 100.0 || gradePercentage < 0.0)
            throw new Exception("Invalid Grade Entered.");

        char letter = ' ';
        if (gradePercentage >= 90)
            letter = 'A';
        else if (gradePercentage >= 80)
            letter = 'B';
        else if (gradePercentage >= 70)
            letter = 'C';
        else if (gradePercentage >= 60)
            letter = 'D';
        else
            letter = 'F';

        char sign = getPlusMinus(gradePercentage);

        if (gradePercentage >= 70)
            Console.WriteLine($"Letter Grade: {letter}{sign}\nCongratulations on passing your class!");
        else
            Console.WriteLine($"Letter Grade: {letter}\nBetter luck next time!");
    }
}