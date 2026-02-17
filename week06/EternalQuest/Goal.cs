namespace EternalQuest
{
    public abstract class Goal(string name, string description, int points)
    {
        protected string _name = name;
        protected string _desc = description;
        protected int _points = points;

        public string GetName()
        {
            return _name;
        }

        public virtual string GetDetailsString()
        {
            return $"[ ] {_name} ({_desc})";
        }

        public abstract int RecordEvent();

        public abstract bool IsComplete();

        public abstract string GetStringRepresentation();
    }
}