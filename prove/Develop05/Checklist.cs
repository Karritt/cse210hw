public class Checklist : Goal
{
    private int _timesCompleted;
    private int  _bonusPoints;
    private int _maxTimes;
    public Checklist(string name, string description, int pointValue, int bonusPoints, int maxTimes) : base(name, description, pointValue)
    {
        _timesCompleted = 0;
        _bonusPoints = bonusPoints;
        _maxTimes = maxTimes;
    }
    public Checklist(string name, string description, int pointValue, int bonusPoints, int maxTimes, int timesCompleted) : base(name, description, pointValue)
    {
        _timesCompleted = timesCompleted;
        _bonusPoints = bonusPoints;
        _maxTimes = maxTimes;
    }
    public override int Complete()
    {
        _timesCompleted++;
        if (_timesCompleted < _maxTimes) 
        {
            return _pointValue;
        } 
        else if (_timesCompleted == _maxTimes)
        {
            return _bonusPoints;
        }
        else
        {
            return 0;
        }
    }
    public override string GetInformation()
    {
        return $"Checklist goal: \n {GetNameDescriptionPoints()}, bonus of {_bonusPoints} points for completing {_maxTimes} times. Completed {_timesCompleted} times so far.";
    }
    public override string Serialize()
    {
        return $"type::Checklist;;name::{GetName()};;description::{GetDescription()};;pointValue::{GetPointValue()};;bonusPoints::{_bonusPoints};;maxTimes::{_maxTimes};;timesCompleted::{_timesCompleted}";
    }
}