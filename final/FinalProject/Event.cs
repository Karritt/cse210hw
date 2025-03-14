
public class Event
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

    public string GetInfo()
    {
        return $"{_title} - {_startDate} to {_endDate}. {_notes}";
    }
    public string GetTitle()
    {
        return _title;
    }

    //this function may be polymorpic
    public string CancelEvent()
    {
        _startDate = DateTime.MinValue;
        _endDate = DateTime.MinValue;
        _notes = "";
        return $"{_title} has been cancelled.";
    }

}