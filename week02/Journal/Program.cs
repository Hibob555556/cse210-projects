// Creativity: Loading journal prompts from an external file rather than a hardcoded list

using System;
namespace Journal
{
    class Program
    {
        const string dir = ".\\in\\";
        const string file = "in.txt";
        const string headerText = "Please select one of the following choices:";
        static void Main(string[] args)
        {
            List<string> prompts = [];
            try
            {
                prompts = LoadPrompts();
            }
            catch (Exception except)
            {
                Console.WriteLine($"Could not load prompt files: {except}");
            }

            Journal journal = new();
            bool writing = true;
            while (writing)
            {
                if (prompts.Count != 0)
                {
                    DisplayMenu();
                    int userAnswer = GetAnswer();

                    if (userAnswer == 1)
                        WriteEntry(prompts, journal);
                    else if (userAnswer == 2)
                        journal.DisplayEntries();
                    else if (userAnswer == 3)
                        journal.Load();
                    else if (userAnswer == 4)
                        journal.Save();
                    else if (userAnswer == 5)
                        writing = false;
                }
                else
                {
                    Console.WriteLine("There are no prompts provided in '.\\In\\in.txt");
                }
            }
        }

        public static List<string> LoadPrompts()
        {
            if (!Directory.Exists(dir))
                throw new Exception("The 'In' folder containing the prompt entries does note exits.");

            if (!File.Exists($"{dir}{file}"))
                throw new Exception("The 'In' file containing your prompts does not exist.");

            string promptFileText = File.ReadAllText($"{dir}{file}");
            List<string> prompts = [.. promptFileText.Split("\r\n")];
            prompts = [.. prompts.Where((l) => l.Trim() != "")];
            return prompts;
        }

        public static void DisplayMenu()
        {
            Console.WriteLine(headerText);
            string[] options = ["Write", "Display", "Load", "Save", "Quit"];
            for (int i = 0; i < options.Length; i++)
                Console.WriteLine($"{i + 1}. {options[i]}");
            Console.Write("What would you like to do? ");
        }

        public static int GetAnswer()
        {
            var restart = (() =>
            {
                Console.WriteLine("Invalid option selected. Try again.");
                DisplayMenu();
                return GetAnswer();
            });

            try
            {
                string answerText = Console.ReadLine();
                int answer = int.Parse(answerText);
                if (answer! > 0 && answer < 6)
                    return answer;
                else
                    return restart();
            }
            catch
            {
                return restart();
            }
        }

        public static void WriteEntry(List<string> prompts, Journal journal)
        {
            Random rand = new();
            string date = DateTime.Now.Date.ToString("d");
            int randIndex = rand.Next(0, prompts.Count);
            string prompt = prompts[randIndex];
            Console.WriteLine($"{prompt} ");
            string entryText = Console.ReadLine();
            Entry entry = new(date, prompt, entryText);
            journal.AddEntry(entry);
        }
    }
}