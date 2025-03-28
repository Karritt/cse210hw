public class Onetime : Goal
{
    private bool _isCompleted = false;

    public Onetime(string name, string description, int pointValue) : base(name, description, pointValue)
    {
    }
    public override int Complete()
    {
        if (!_isCompleted) 
        {
            _isCompleted = true;
            int output = _pointValue;
            _pointValue = 0;
            return output;
        } 
        else
        {
            return 0;
        }
    }
    public override string GetInformation()
    {
        return $"Onetime goal: \n {GetNameDescriptionPoints()}";
    }
    public override string Serialize()
    {
        return $"type::Onetime;;name::{GetName()};;description::{GetDescription()};;pointValue::{GetPointValue()}";
    }
}