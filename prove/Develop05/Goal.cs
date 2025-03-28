public abstract class Goal
{
    private string _name;
    private string _description;
    protected int _pointValue;
    public Goal(string name, string description, int pointValue)
    {
        _name = name;
        _description = description;
        _pointValue = pointValue;
    }
    public abstract int Complete();

    public abstract string GetInformation();
    public abstract string Serialize();

    public string GetNameDescriptionPoints()
    {
        return _name + ": " + _description + " (" + _pointValue + " points)";
    }
    public string GetName()
    {
        return _name;
    }
    public string GetDescription()
    {
        return _description;
    }
    public int GetPointValue()
    {
        return _pointValue;
    }

}