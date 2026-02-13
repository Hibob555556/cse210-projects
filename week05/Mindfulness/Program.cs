// Exceeding Requirements:
// ListingActivity uses a "no repeat until all used" prompt system.
// Prompts are shuffled and queued so each prompt appears once per cycle before any repeats.
using System;

namespace Mindfulness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting app...");

            const string divider = "~~~~~~~~~~~~~~~~~~~~~~~~~";
            string[] menuOpts = [
                "Start breathing Activity", "Start reflection activity",
            "Start listing activity", "Quit"
            ];

            while (true)
            {
                // keep console clean 
                Console.Clear();

                // write menu
                Console.WriteLine("Mindfulness App");
                Console.WriteLine(divider);

                int index = 1;
                foreach (var opt in menuOpts) Console.WriteLine($"{index++}. {opt}");
                Console.Write("Select a choice: ");
                string choice = Console.ReadLine();

                Activity activity = choice switch
                {
                    "1" => new BreathingActivity(
                        "Breathing Activity",
                        "This activity will walk you through breathing in and out to relax."
                    ),
                    "2" => new ReflectionActivity(
                        "Reflection Activity",
                        "This activity will have you reflect on different times in your life when you have demonstrated strength."
                    ),
                    "3" => new ListingActivity(
                        "Listing Activity",
                        "This activity will help you list good things which have happened in your life to reflect on the good."
                    ),
                    "4" => null,
                    _ => null
                };

                if (choice == "4") break;

                if (activity != null)
                {
                    activity.Run();
                    Console.WriteLine("\nPress Enter to return to menu...");
                    Console.ReadLine();
                }
            }
        }
    }
}