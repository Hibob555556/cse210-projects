namespace Journal
{
    /// <summary>
    /// The journal class will keep track of and display entries in your journal. 
    /// </summary>
    class Journal
    {
        private List<Entry> _entries;

        /// <summary>
        /// This constructor will initialize with no parameters and creates an empty list of 
        /// entries which can be interacted with through the DisplayEntries() and AddEntry()
        /// methods. 
        /// </summary>
        public Journal()
        {
            _entries = [];
        }

        /// <summary>
        /// When called this function will iterate over all entries and display them.
        /// </summary>
        /// <remarks>
        /// <i> If there are no entries the function will display "There are no entries". </i>
        /// </remarks>
        public void DisplayEntries()
        {
            // don't loop if there are not any entires
            if (!(_entries.Count > 0))
                Console.WriteLine("There are no entries");
            else
            {
                // loop over and display each entry
                foreach (Entry entry in _entries)
                {
                    Console.WriteLine(entry.GetEntry());
                }
            }
        }

        /// <summary>
        /// When provided a variable of type Entry this will add an entry to your entries list. 
        /// </summary>
        /// <param name="entry">Entry</param>
        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        /// <summary>
        /// This function will prompt the user for a file name and save each journal entry on 
        /// its own line in a .txt file.
        /// </summary>
        public void Save()
        {
            // get the users desired file name
            Console.Write("Please enter journal name: ");
            string fileName = Console.ReadLine();

            // ensure the .\out directory exists and create it if it does not.
            if (!Directory.Exists(".\\out\\")) Directory.CreateDirectory(".\\out\\");
            if (!File.Exists($".\\out\\{fileName}.txt"))
                File.Create($".\\out\\{fileName}.txt").Close();

            // prepare a string to store all machine readable journal entries
            string entries = string.Empty;
            foreach (Entry entry in _entries)
            {
                // get the text of the entry and concatenate the string with new lines in 
                // between each entry
                string _text = entry.GetSaveEntry();
                entries += $"{_text}\r\n";
            }

            // write all entries to a file. 
            try
            {
                File.WriteAllText($".\\out\\{fileName}.txt", entries);
                Console.WriteLine($"Your entries have been saved in '.\\out\\{fileName}.txt'");
            }
            catch (IOException except)
            {
                Console.WriteLine($"Could not write file: {except}");
            }
        }

        /// <summary>
        /// This function prompts the user for a journal name, opens the file, and reads it. 
        /// </summary>
        public void Load()
        {
            // get the users desired file name
            Console.Write("Please enter name of journal to open: ");
            string fileName = Console.ReadLine();
            string filePath = $".\\out\\{fileName}.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("The specified journal does not exist.");
                return;
            }
            else
            {
                _entries.Clear();

                // get the text
                string text = File.ReadAllText(filePath);
                List<string> entries = [.. text.Split("\r\n")];

                foreach (string entry in entries)
                {
                    if (entry != "")
                    {
                        string[] line = entry.Split("|");
                        string date = line[0];
                        string prompt = line[1];
                        string entryText = line[2];
                        Entry newEntry = new(date, prompt, entryText);
                        AddEntry(newEntry);
                    }
                }
            }
        }
    }
}