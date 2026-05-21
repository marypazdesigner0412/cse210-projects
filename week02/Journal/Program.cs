using System;
using System.Collections.Generic;

/* CREATIVITY
1. Advanced File Format Storage: Instead of basic pipe-separated strings (like | or ~), 
   this implementation imports System.Text.Json to store data seamlessly as a robust JSON object list. 
   This safely handles nested strings, internal punctuation, quotes, and carriage returns natively.
2. Graceful Error Fallbacks: Built explicit try/catch validations handling file exceptions 
   smoothly so incorrect filenames do not crash the running terminal loop.
*/

namespace JournalApp
{
    class Program
    {
        private static List<string> _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What was a small victory you achieved over an obstacle today?",
            "What is a detail about Punto Fijo or your current environment that caught your eye today?"
        };

        static void Main(string[] args)
        {
            Journal activeJournal = new Journal();
            Random rand = new Random();
            string choice = "";

            Console.WriteLine("Welcome to the Journal Program!");

            while (choice != "5")
            {
                Console.WriteLine("\nPlease select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");

                choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        // Select a random prompt
                        int index = rand.Next(_prompts.Count);
                        string selectedPrompt = _prompts[index];

                        Console.WriteLine($"\nPrompt: {selectedPrompt}");
                        Console.Write("> ");
                        string userResponse = Console.ReadLine() ?? "";

                        // Grab current calendar date string cleanly
                        string currentDate = DateTime.Now.ToShortDateString();

                        Entry newEntry = new Entry(currentDate, selectedPrompt, userResponse);
                        activeJournal.AddEntry(newEntry);
                        break;

                    case "2":
                        activeJournal.DisplayAll();
                        break;

                    case "3":
                        Console.Write("\nWhat is the filename? ");
                        string loadFile = Console.ReadLine() ?? "";
                        activeJournal.LoadFromFile(loadFile);
                        break;

                    case "4":
                        Console.Write("\nWhat is the filename? ");
                        string saveFile = Console.ReadLine() ?? "";
                        activeJournal.SaveToFile(saveFile);
                        break;

                    case "5":
                        Console.WriteLine("\nThank you for writing today. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("\nInvalid option. Please enter a number from 1 to 5.");
                        break;
                }
            }
        }
    }
}