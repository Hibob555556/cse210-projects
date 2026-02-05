namespace Homework
{
    class WritingAssignment(string name, string topic, string title) : Assignment(name, topic)
    {
        private protected string _title = title;

        public string GetWritingInformation()
        {
            return $"{_title} by {_name}";
        }
    }
}