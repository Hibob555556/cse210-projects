namespace Mindfulness
{
    class BreathingActivity(string name, string description) : Activity(name, description)
    {
        public override void Run()
        {
            StartActivity();
            int passed = 0;
            while (passed < duration)
            {
                Console.WriteLine("Breathe in...");
                PauseWithCountdown(2);
                Console.WriteLine("Breathe out...");
                PauseWithCountdown(2);
                passed += 4;
            }
            EndActivity();
        }
    }
}