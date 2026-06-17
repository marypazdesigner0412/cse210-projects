using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public virtual string GetDetailsString()
    {
        string statusCheckbox = IsComplete() ? "[X]" : "[ ]";
        return $"{statusCheckbox} {_shortName} ({_description})";
    }

    public string GetShortName() => _shortName;
    public string GetDescription() => _description;
    public int GetPoints() => _points;

    // Abstract hooks for polymorphism
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();
}