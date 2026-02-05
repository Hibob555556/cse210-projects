namespace Homework
{
    class MathAssignment(string name, string topic, string section, string problems) : Assignment(name, topic)
    {
        private protected string _section = section;
        private protected string _problems = problems;

        public string GetHomeworkList()
        {
            return $"Section {_section} Problems {_problems}";
        }
    }
}