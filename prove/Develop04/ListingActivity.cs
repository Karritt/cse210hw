public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    private List<string> _usedPrompts = new List<string>();
    private List<string> _responses = new List<string>();
    public ListingActivity() : base("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", "Listing Activity")
    {}
    public void Start()
    {
        DisplayIntroAndSetDuration();
        Console.WriteLine("Get ready...");
        new Spinner(3);
        Console.Clear();
        Console.WriteLine(getRandomPrompt());
        DateTime startTime = DateTime.Now;
        DateTime endTime = DateTime.Now;
        TimeSpan timeTaken = endTime - startTime;
        while (GetDuration() - timeTaken.Seconds > 0)
        {
            Console.Write($"{GetDuration() - timeTaken.Seconds}> ");
            string response = Console.ReadLine();
            addResponse(response);
            endTime = DateTime.Now;
            timeTaken = endTime - startTime;
        }
        Console.WriteLine($"You listed {_responses.Count} items.");
        DisplayOutro();
    }
    private string getRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            _prompts = new List<string>(_usedPrompts);
            _usedPrompts.Clear();
        }
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string chosenPrompt = _prompts[index];
        _usedPrompts.Add(chosenPrompt);
        _prompts.Remove(chosenPrompt);
        return chosenPrompt;
    }
    private void addResponse(string response)
    {
        if (response == "" || response == " " || response == null)
        {
            Console.WriteLine("Please enter a valid response.");
        } 
        else if (_responses.Contains(response.ToLower()))
        {
            Console.WriteLine("You have already entered that response. Please enter a different one.");
        } 
        else
        {
            _responses.Add(response.ToLower());
        }
        
    }
}