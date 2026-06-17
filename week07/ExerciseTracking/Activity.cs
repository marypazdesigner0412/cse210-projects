using System;

public abstract class Activity
{
    // Criteria 2 & 8: Private member variables with _underscoreCamelCase
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Encapsulation getter for access in child calculations
    public int GetMinutes()
    {
        return _minutes;
    }

    // Criterion 4: Abstract methods with no bodies that MUST be overridden by subclasses
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Criterion 5: Defined ONLY in the base class. It polymorphically resolves 
    // the child methods at runtime and MUST NOT be overridden in child classes.
    public string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_minutes} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}