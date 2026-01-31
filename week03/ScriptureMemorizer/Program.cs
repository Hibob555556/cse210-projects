// Creative Addition: I added a "reset" command so if the user types reset they can restart memorization without restarting the program.

using System;
using ScriptureMemorizer;

class Program
{
    static void Main(string[] args)
    {
        const string scriptureText = "Then I turned, and lifted up mine eyes, and looked, and behold a flying roll.";
        Reference reference = new("Zechariah", 5, 1);
        Scripture scripture = new(reference, scriptureText);
        Console.Clear();

        while (true)
        {
            Console.Clear();
            string text = scripture.GetDisplayText();
            Console.WriteLine(text);
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nTo exit press enter or type 'reset' to restart");
                string userAction = Console.ReadLine();
                userAction ??= "";
                userAction = userAction.ToLower().Trim();
                if (userAction == "reset")
                    scripture.ResetWords();
                else
                    break;
            }
            else
            {
                Console.WriteLine("\nTo continue press enter, type 'quit' to exit, or type 'reset' to restart");
                string userAction = Console.ReadLine();
                userAction ??= "";
                userAction = userAction.ToLower().Trim();
                if (userAction == "quit")
                    break;
                else if (userAction == "reset")
                    scripture.ResetWords();
                else
                    scripture.HideRandomWords();
            }
        }
    }
}