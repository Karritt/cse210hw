using System.Collections.Specialized;

public class Generic : Event
{
    public Generic (string title, DateTime startTime, TimeSpan duration, string description) : base(title, startTime, duration, description)
    {}
    public Generic (string title, DateTime startTime, TimeSpan duration) : base(title, startTime, duration)
    {}
    public override string CancelEvent()
    {
        SetStartTime(DateTime.MinValue);
        DeleteReminder();
        return $"{GetTitle()} has been cancelled.";
    }
    public override string GetInfo()
    {
        return $"{GetTitle()} - {GetStartTimeAsString()} - {GetDurationAsString()} - {GetNotes()}";
    }
    public override string Serialize()
    {
        return $"generic::{GetTitle()}::{GetStartTimeAsString()}::{GetDurationAsSerializedString()}::{GetNotes()}";
    }
}