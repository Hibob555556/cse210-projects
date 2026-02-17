using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    internal class Program
    {
        private static void Main()
        {
            List<Activity> activities =
            [
                new Running(30, "03 Nov 2022", 3.0),
                new Cycling(45, "04 Nov 2022", 14.5),
                new Swimming(25, "05 Nov 2022", 30),
            ];

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}