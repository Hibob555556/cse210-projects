namespace EternalQuest
{
    public class SimpleGoal(string name, string description, int points)
        : Goal(name, description, points)
    {
        private bool _isComplete = false;

        public override int RecordEvent()
        {
            if (_isComplete) return 0;
            _isComplete = true;
            return _points;
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetDetailsString()
        {
            string checkbox = _isComplete ? "[X]" : "[ ]";
            return $"{checkbox} {_name} ({_desc})";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal|{_name}|{_desc}|{_points}|{_isComplete}";
        }
    }
}