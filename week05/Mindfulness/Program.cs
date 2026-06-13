using System;
using Mindfulness;

/*
========================================================================================
1. I enhanced the 'ReflectingActivity' class by implementing an internal question tracking system. 
   The program saves questions to an active pool and filters out chosen questions so that NO 
   reflection question can repeat during a session until every single question has been used at least once.
2. I added a session log tracking counter right here in 'Program.cs' that keeps tabs on how 
   many times the user runs each of the exercises, outputting a summary statement before quitting.
========================================================================================
*/
class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        // Local tracking metrics
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                breathingCount++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                reflectingCount++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                listingCount++;
            }
        }

        // Display session logs upon exiting
        Console.Clear();
        Console.WriteLine("==================================================");
        Console.WriteLine("            GREAT JOB ON YOUR SESSIONS!           ");
        Console.WriteLine("==================================================");
        Console.WriteLine($"Breathing Activities Completed:  {breathingCount}");
        Console.WriteLine($"Reflection Activities Completed: {reflectingCount}");
        Console.WriteLine($"Listing Activities Completed:    {listingCount}");
        Console.WriteLine("==================================================");
        Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
    }
}