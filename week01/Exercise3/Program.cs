using System;

class Program
{
    static void Main(string[] args)
    {
        bool replay = true;
        while (replay)
        {
            // generate random number
            var rand = new Random();
            int magicNumber = rand.Next(1, 101);

            // run loop til guessed
            bool playing = true;
            int guesses = 0;
            while (playing)
            {
                guesses++;
                Console.Write("What your guess? ");
                int guess = int.Parse(Console.ReadLine());

                string hint = String.Empty;
                if (guess < magicNumber)
                    hint = "Higher";
                else if (guess > magicNumber)
                    hint = "Lower";
                else
                {
                    Console.WriteLine($"\nYou guessed it!\nIt took you {guesses} {(guesses == 1 ? "guess" : "guesses")}");
                    Console.Write("Would you like to play again? (1 = yes, 0 = no) ");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice != 1)
                    {
                        replay = false;
                        break;
                    }
                    playing = false;
                    break;
                }

                Console.WriteLine(hint);
            }
        }
        Console.WriteLine("Goodbye!");
    }
}