namespace EternalQuest
{
    public class EternalGoal(string name, string description, int points)
        : Goal(name, description, points)
    {
        public override bool IsComplete()
        {
            return false;
        }
        public override int RecordEvent()
        {
            return _points;
        }
        public override string GetDetailsString()
        {
            return $"[ ] {_name} ({_desc})";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal|{_name}|{_desc}|{_points}";
        }
    }
}