using System;
using PersonalJournal;

namespace PersonalJournal
{}
class Program
{
    static void Main(string[] args)
    {
        
        {
            Journal journal = new Journal();

                List<string> prompts = new List<string>
            {
                "If you could go back and change 1 thing that happened today, what would it be? ",
                "What was the most challenging thing you faced today and how did you overcome it? ",
                "What was the best moment of your day and why? ",
                "What is something that happened today that you would want to remeber forever? ",
                "Did you discover anything new or learn something interesting today? ",
                "How did you Think Celestiasl today?" ,
                "Did you achieve any success in your work, studies or personal projects today? ",
                "Did you do anything today that took you out of your comfort zone? ",
                "What was the most peaceful moment during the day? ",
                "What is one goal you accomplished today? ",
                "How did you show love or compassion towards others today, inspired by your faith? ",
                "If you had another hour during the day, how would you have spent it? ",
                "How can you make tomorrow (even) better than today?",
                "How would you describe your spirituality today? ",
                "How did you demonstrate your faith through actions or choices you made today? ",
                "What was the hardest decision you had to make today?",
                "If this was your last night on earth, what would you like for the people reading this journal to know?"
            };
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nWelcome to the Journal Program");
                Console.WriteLine("Please Select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Save");
                Console.WriteLine("4. Load");
                Console.WriteLine("5. Quit");

                Console.WriteLine("\nWhat would you like to do? ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string prompt = RandomPrompt(prompts);
                        journal.AddEntry(prompt);
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        journal.SaveToFile();
                        break;
                    case "4":
                        journal.LoadFromFile();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Entry, Please enter a number between 1 - 5!");
                        break;
                }
            }
            Console.WriteLine("Until next time, keep writing!");
        }

        static string RandomPrompt(List<string> prompts)
        {
            Random random = new Random();
            int index = random.Next(prompts.Count);
            return prompts[index];
        }
    }
}

