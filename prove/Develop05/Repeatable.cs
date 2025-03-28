public class Repeatable : Goal
{
    public Repeatable(string name, string description, int pointValue) : base(name, description, pointValue)
    {
    }
    public override int Complete()
    {
        return _pointValue;
    }
    public override string GetInformation()
    {
        return $"Repeatable goal: \n {GetNameDescriptionPoints()}";
    }
    public override string Serialize()
    {
        return $"type::Repeatable;;name::{GetName()};;description::{GetDescription()};;pointValue::{GetPointValue()}";
    }
}