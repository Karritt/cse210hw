public class Activity
{
    private int _duration;
    private string _description;
    private string _title;
    public Activity (string description, string title)
    {
        _description = description;
        _title = title;
    }
    public int GetDuration()
    {
        return _duration;
    }
    public void DisplayIntroAndSetDuration()
    {
        Console.WriteLine($"Welcome to the {_title} activity.");
        Console.WriteLine(_description);
        Console.WriteLine("How long, in seconds, would you like for your session?");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine($"You have chosen a duration of {_duration} seconds.");
    }
    public void DisplayOutro()
    {
        Console.WriteLine($"You've completed the {_title} activity for {_duration} seconds. Well Done!");
        new Spinner(5);
    }
}