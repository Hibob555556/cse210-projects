namespace Mindfulness
{
    class ReflectionActivity(string name, string description) : Activity(name, description)
    {
        private readonly List<string> _prompts = [
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
        ];

        private readonly List<string> _questions = [
            "How did you feel when it was complete?",
            "What could you learn from this experience that applies to other situations?",
            "What made this time different than other times when you were not as successful?",
            "How can you keep this experience in mind in the future?",
            "What did you learn about yourself through this experience?",
            "Have you ever done anything like this before?",
        ];

        public override void Run()
        {
            StartActivity();
            Random rand = new();
            int randInt = rand.Next(_prompts.Count);
            Console.WriteLine(_prompts[randInt]);
            int passed = 0;
            while (passed < duration)
            {
                int randQuestionIndex = rand.Next(_questions.Count);
                Console.WriteLine(_questions[randQuestionIndex]);
                PauseWithCountdown(3);
                passed += 3;
            }
            EndActivity();
        }
    }
}