using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JournalApp
{
    public class Journal
    {
        // Using a property with a private setter to control modifications
        public List<Entry> Entries { get; private set; } = new List<Entry>();

        public void AddEntry(Entry newEntry)
        {
            Entries.Add(newEntry);
        }

        public void DisplayAll()
        {
            if (Entries.Count == 0)
            {
                Console.WriteLine("\nThe journal is empty.");
                return;
            }

            Console.WriteLine("\n--- Journal Entries ---");
            foreach (var entry in Entries)
            {
                entry.Display();
            }
        }

        public void SaveToFile(string file)
        {
            try
            {
                // Serializes the entire object list with nice indentation layout
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(Entries, options);

                File.WriteAllText(file, jsonString);
                Console.WriteLine($"Journal successfully saved to '{file}' using JSON format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        public void LoadFromFile(string file)
        {
            try
            {
                if (!File.Exists(file))
                {
                    Console.WriteLine($"Error: The file '{file}' does not exist.");
                    return;
                }

                string jsonString = File.ReadAllText(file);
                // Replace current local runtime entry storage completely with parsed data
                Entries = JsonSerializer.Deserialize<List<Entry>>(jsonString) ?? new List<Entry>();
                Console.WriteLine($"Journal successfully loaded from '{file}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data format from file: {ex.Message}");
            }
        }
    }
}