public class ReflectionActivity : Activity
{
    private List<String> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<String> _usedPrompts = new List<string>();
    private List<String> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    private List<String> _usedQuestions = new List<string>();
    public ReflectionActivity() : base("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", "Reflection Activity") {}
    public void Start()
    {
        DisplayIntroAndSetDuration();
        int timeLeft = GetDuration();
        Console.Clear();
        Console.WriteLine($"Think About This: {GetRandomPrompt()}");
        new Spinner(8);
        timeLeft -= 8;
        while (timeLeft > 0)
        {
            Console.WriteLine($"Answer this in your head: {GetRandomQuestion()}");
            new Spinner(12);
            timeLeft -= 12;
        }
        DisplayOutro();
    }
    private string GetRandomPrompt()
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
    private string GetRandomQuestion()
    {
        if (_questions.Count == 0)
        {
            _questions = new List<string>(_usedQuestions);
            _usedQuestions.Clear();
        }
        Random random = new Random();
        int index = random.Next(_questions.Count);
        string chosenQuestion = _questions[index];
        _usedQuestions.Add(chosenQuestion);
        _questions.Remove(chosenQuestion);
        return chosenQuestion;
    }

}