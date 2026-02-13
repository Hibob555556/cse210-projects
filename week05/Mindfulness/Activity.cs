namespace Mindfulness
{
    // activity base class, will be used in derived classes
    class Activity(string name, string description)
    {
        private readonly string _activityName = name;
        private readonly string _activityDescription = description;
        protected int duration;
        private const int OneSecondMs = 1000;

        public virtual void Run() { }

        protected void StartActivity()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_activityName}.\n");
            Console.WriteLine(_activityDescription);
            Console.Write("\nPlease enter a duration (seconds): ");
            duration = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("\nGet ready...");
            ShowSpinner(3);
            Console.WriteLine();
        }

        protected void EndActivity()
        {
            Console.WriteLine("\nWell done!!");
            ShowSpinner(2);

            Console.WriteLine($"\nYou have completed the {_activityName} for {duration} seconds.");
            ShowSpinner(3);
            Console.WriteLine();
        }

        protected void PauseWithCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(OneSecondMs);
                Console.Write("\b \b"); // overwrite number
            }
        }

        protected void ShowSpinner(int seconds)
        {
            string[] frames = ["|", "/", "-", "\\"];
            int totalTicks = seconds * 10;

            for (int i = 0; i < totalTicks; i++)
            {
                Console.Write(frames[i % frames.Length]);
                Thread.Sleep(100);
                Console.Write("\b \b");
            }
        }
    }
}