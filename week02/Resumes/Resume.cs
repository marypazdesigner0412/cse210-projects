using System;
using System.Collections.Generic;

public class Resume
{
    public string _name;

    // Initialize the list immediately to avoid a NullReferenceException later
    public List<Job> _jobs = new List<Job>();

    // Method to display the full resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Loop through the list of Job objects and call their individual Display method
        foreach (Job job in _jobs)
        {
            // Call the Display method on each job
            job.Display();
        }
    }
}