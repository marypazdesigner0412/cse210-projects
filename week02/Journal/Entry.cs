using System;

namespace JournalApp
{
    public class Entry
    {
        // Properties automatically handled by the JSON serializer
        public string Date { get; set; }
        public string PromptText { get; set; }
        public string EntryText { get; set; }

        // Parameterless constructor needed for JSON deserialization
        public Entry() { }

        public Entry(string date, string promptText, string entryText)
        {
            Date = date;
            PromptText = promptText;
            EntryText = entryText;
        }

        public void Display()
        {
            Console.WriteLine($"Date: {Date} - Prompt: {PromptText}");
            Console.WriteLine($"{EntryText}");
            Console.WriteLine(new string('-', 50));
        }
    }
}