using System;

public class Job
{
    // Member variables (using the underscore convention)
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    // Method to display the specific job details in the required format
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}