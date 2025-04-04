//Tasks are a type of event that can be checked off as completed, but aren't deleted on completion.

public class Task : Event
{
    private Boolean _completed = false;
    public Task(string Title, DateTime DeadLine, string Notes) : base(Title, DeadLine, new TimeSpan(0, 0, 0), Notes)
    { }
    public Task(string Title, DateTime DeadLine) : base(Title, DeadLine, new TimeSpan(0, 0, 0))
    { }
    public Task(string Title, DateTime DeadLine, string Notes, Boolean Completed) : base(Title, DeadLine, new TimeSpan(0, 0, 0), Notes)
    {
        _completed = Completed;
    }


    public string CompleteTask()
    {
        _completed = true;
        CancelEvent();
        return $"{GetTitle()} has been completed. Good Job!";
    }
    public override string CancelEvent()
    {
        SetStartTime(DateTime.MinValue);
        DeleteReminder();
        return $"{GetTitle()} has been cancelled.";
    }
    public override string GetInfo()
    {
        return $"{GetTitle()} - Complete By {GetStartTimeAsString()} - {GetNotes()} - Completed: {_completed}";
    }
    public override string Serialize()
    {
        return $"task::{GetTitle()}::{GetStartTimeAsString()}::{GetNotes()}::{_completed}";
    }
}