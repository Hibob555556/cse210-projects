// Exceeding requirements: Added a leveling system (1 level per 1000 points) displayed in the UI.

using EternalQuest;

class Program
{
    static void Main()
    {
        GoalManager manager = new();
        manager.Start();
    }
}
