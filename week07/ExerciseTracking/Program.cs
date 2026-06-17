using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================================\n");

        // Criterion 6: Create at least one activity of each type and put them in the same list
        List<Activity> activities = new List<Activity>();

        // Instantiating objects using local variables with camelCase
        Running runningActivity = new Running("03 Nov 2022", 30, 3.0);
        Cycling cyclingActivity = new Cycling("03 Nov 2022", 45, 12.0);
        Swimming swimmingActivity = new Swimming("04 Nov 2022", 40, 40); // 40 laps = 2000m (~1.24 miles)

        activities.Add(runningActivity);
        activities.Add(cyclingActivity);
        activities.Add(swimmingActivity);

        // Iterate through the shared list and call GetSummary() polymorphically
        foreach (Activity activity in activities)
        {
            // C# resolves the abstract hooks inside GetSummary at runtime for each specific child class
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("\n=================================================================");
    }
}