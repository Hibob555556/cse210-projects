using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals = new();
        private int _score = 0;

        public void Start()
        {
            string userInput = "";

            while (userInput != "6")
            {
                DisplayPlayerInfo();
                DisplayMenu();

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        SaveGoals();
                        break;
                    case "4":
                        LoadGoals();
                        break;
                    case "5":
                        RecordEvent();
                        break;
                }
            }
        }

        private void DisplayPlayerInfo()
        {
            Console.WriteLine($"\nYou have {_score} points. (Level {GetLevel()})\n");
        }


        private static void DisplayMenu()
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.WriteLine("---------------------------------");
            Console.Write("Select a choice: ");
        }

        private void CreateGoal()
        {
            Console.WriteLine("\nThe types of goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string goalType = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string desc = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            switch (goalType)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, desc, points));
                    break;

                case "2":
                    _goals.Add(new EternalGoal(name, desc, points));
                    break;

                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine());

                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());

                    _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                    break;

                default:
                    Console.WriteLine("Invalid goal type.\n");
                    break;

            }

            Console.WriteLine();
        }

        private void ListGoals()
        {
            Console.WriteLine("\nThe goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
            Console.WriteLine();
        }

        private void RecordEvent()
        {
            Console.WriteLine("\nThe goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }

            Console.Write("Which goal did you accomplish? ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid number.\n");
                return;
            }

            int index = choice - 1;

            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("That goal number doesn't exist.\n");
                return;
            }

            int earned = _goals[index].RecordEvent();
            _score += earned;

            Console.WriteLine($"Congratulations! You have earned {earned} points!");
            Console.WriteLine($"You now have {_score} points.\n");
        }

        private void SaveGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            using StreamWriter outputFile = new StreamWriter(filename);

            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }

            Console.WriteLine("Saved.\n");
        }

        private void LoadGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.\n");
                return;
            }

            string[] lines = File.ReadAllLines(filename);

            _goals.Clear();
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");

                if (string.IsNullOrWhiteSpace(lines[i])) continue;

                string type = parts[0];
                string name = parts[1];
                string desc = parts[2];
                int points = int.Parse(parts[3]);

                switch (type)
                {
                    case "SimpleGoal":
                        {
                            bool isComplete = bool.Parse(parts[4]);
                            SimpleGoal goal = new SimpleGoal(name, desc, points);

                            if (isComplete)
                            {
                                goal.RecordEvent();
                            }

                            _goals.Add(goal);
                            break;
                        }

                    case "EternalGoal":
                        {
                            _goals.Add(new EternalGoal(name, desc, points));
                            break;
                        }

                    case "ChecklistGoal":
                        {
                            int bonus = int.Parse(parts[4]);
                            int target = int.Parse(parts[5]);
                            int amountCompleted = int.Parse(parts[6]);

                            ChecklistGoal goal = new ChecklistGoal(name, desc, points, target, bonus);

                            for (int c = 0; c < amountCompleted; c++)
                            {
                                goal.RecordEvent();
                            }

                            _goals.Add(goal);
                            break;
                        }
                }
            }

            Console.WriteLine("Loaded.\n");
        }

        private int GetLevel()
        {
            // 1 level per 1000 points
            return (_score / 1000) + 1;
        }

    }
}