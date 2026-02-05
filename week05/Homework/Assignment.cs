namespace Homework
{
    class Assignment(string name, string topic)
    {
        private protected string _name = name;
        private protected string _topic = topic;

        public string GetSummary()
        {
            return $"{_name} - {_topic}";
        }
    }
}