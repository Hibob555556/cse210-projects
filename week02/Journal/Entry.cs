namespace Journal
{
    /// <summary>
    /// Used to create new Journal entries.
    /// </summary>
    class Entry
    {
        private string _date;
        private string _promptText;
        private string _entryText;

        /// <summary>
        /// Initializes a new entry with the given date, prompt, and entry.
        /// </summary>
        /// <param name="date">String</param>
        /// <param name="promptText">String</param>
        /// <param name="entryText">String</param>
        public Entry(string date, string promptText, string entryText)
        {
            _date = date;
            _promptText = promptText;
            _entryText = entryText;
        }

        /// <summary>
        /// Build and return a formatted entry text. 
        /// </summary>
        /// <returns name="text">String</returns>
        public string GetEntry()
        {
            string text = $"{_date.Trim()} - {_promptText.Trim()} {_entryText.Trim()}";
            return text;
        }

        /// <summary>
        /// Return a machine readable string for saving in a file.
        /// </summary>
        /// <returns name="machineReadText">String</returns>
        public string GetSaveEntry()
        {
            string machineReadText = $"{_date} | {_promptText} | {_entryText}";
            return machineReadText;
        }
    }
}