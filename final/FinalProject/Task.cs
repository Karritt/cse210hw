//Tasks are a type of event that can be checked off as completed, but aren't deleted on completion.

public class Task : Event
{
    private Boolean _completed = false;
    public Task(string Title, DateTime DeadLine, string Notes) : base(Title, DeadLine, new TimeSpan(0, 0, 0), Notes)
    {}
    public Task(string Title, DateTime DeadLine) : base(Title, DeadLine, new TimeSpan(0, 0, 0))
    {}



    public string CompleteTask()
    {
        _completed = true;
        return $"{GetTitle()} has been completed. Good Job!";
    }
}