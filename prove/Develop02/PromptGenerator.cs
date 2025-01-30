public class PromptGenerator
{
    List<string> _prompts  = new List<string>
        {
            "What was the most random thing you saw today?",
            "What made you smile today?",
            "What is something you learned today?",
            "What is something you are grateful for?",
            "What was the highlight of your day?",
            "What is a goal you have for tomorrow?",
            "What is something you did today that you are proud of?",
            "What is a challenge you faced today?",
            "What is something you are looking forward to?",
            "What is a memorable moment from today?"
        };

    public string GetPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}