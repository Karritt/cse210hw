
public abstract class Event
{
    private string _title;
    private string _notes;
    private DateTime _startDate;
    private DateTime _endDate;
    private DateTime _reminder;

    public Event(string Title, DateTime StartDate, TimeSpan Duration, string Notes)
    {
        _title = Title;
        _startDate = StartDate;
        _endDate = StartDate.Add(Duration);
        _notes = Notes;
    }
    public Event(string Title, DateTime StartDate, TimeSpan Duration)
    {
        _title = Title;
        _startDate = StartDate;
        _endDate = StartDate.Add(Duration);
        _notes = "";
    }

    public void SetReminder(TimeSpan Reminder)
    {
        _reminder = _startDate - Reminder;
    }
    public void DeleteReminder()
    {
        _reminder = default;
    }

    public abstract string GetInfo();
    public string GetTitle()
    {
        return _title;
    }
    public string GetNotes()
    {
        return _notes;
    }
    public string GetStartTimeAsString()
    {
        return _startDate.ToString("MM/dd/yyyy HH:mm:ss");
    }
    public string GetDurationAsString()
    {
        TimeSpan duration = _endDate - _startDate;
        return $"{duration.TotalHours}hr, {duration.Minutes}min";
    }
    public string GetDurationAsSerializedString()
    {
        TimeSpan duration = _endDate - _startDate;
        return $"{duration.TotalHours}:{duration.Minutes}";
    }
    public void SetStartTime(DateTime StartTime)
    {
        _startDate = StartTime;
    }
    public void SetDuration(TimeSpan Duration)
    {
        _endDate = _startDate.Add(Duration);
    }
    //this function may be polymorpic
    public abstract string CancelEvent();
    public abstract string Serialize();
}