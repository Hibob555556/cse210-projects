namespace Mindfulness
{
    class ListingActivity(string name, string description) : Activity(name, description)
    {
        private readonly List<string> _prompts = [
            "Who are people that you appreciate?",
            "Who are people that you have helped this week?",
            "What are personal strengths of yours?",
            "Who are some of your personal heroes?",
        ];
        private readonly List<string> _entries = [];
        private Queue<string> _promptQueue = new();
        private readonly Random _rand = new();

        public override void Run()
        {
            StartActivity();

            Console.WriteLine(GetNextPrompt());


            Console.Write("You may begin in: ");
            PauseWithCountdown(3);

            _entries.Clear();

            var stopWatch = System.Diagnostics.Stopwatch.StartNew();
            int count = 0;
            while (stopWatch.Elapsed.TotalSeconds < duration)
            {
                string input = Console.ReadLine();

                // If user just hits enter, don’t count it.
                if (!string.IsNullOrWhiteSpace(input))
                {
                    _entries.Add(input);
                    count++;
                }
            }

            Console.WriteLine($"\nYou listed {count} item(s).");

            EndActivity();
        }

        private string GetNextPrompt()
        {
            if (_promptQueue.Count == 0)
            {
                var shuffled = _prompts.OrderBy(_ => _rand.Next()).ToList();
                _promptQueue = new Queue<string>(shuffled);
            }

            return _promptQueue.Dequeue();
        }
    }
}
