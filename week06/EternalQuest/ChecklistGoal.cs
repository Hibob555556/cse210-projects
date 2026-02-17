namespace EternalQuest
{
    public class ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus)
        : Goal(name, description, points)
    {
        private int _amountCompleted = 0;
        private int _target = target;
        private int _bonus = bonus;

        public override int RecordEvent()
        {
            if (IsComplete()) return 0;
            _amountCompleted++;
            int earnedPoints = _points;

            if (IsComplete()) earnedPoints += _bonus;
            return earnedPoints;
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            string checkbox = IsComplete() ? "[X]" : "[ ]";
            return $"{checkbox} {_name} ({_desc}) -- Completed {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal|{_name}|{_desc}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
        }
    }
}