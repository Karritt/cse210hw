public class BreathingActivity : Activity
{
    public BreathingActivity() : base("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", "Breathing Activity") {}
    public void Start()
    {
        DisplayIntroAndSetDuration();
        int timeLeft = GetDuration();
        timeLeft +=  timeLeft % 8; // Ensure timeLeft is a multiple of 8
        while (timeLeft > 0) {
            Console.Clear();
            Console.WriteLine("Breathe in...");
            new Spinner(4);
            Console.WriteLine("Breathe out...");
            new Spinner(4);
            timeLeft -= 8;
        }
        Console.Clear();
        DisplayOutro();
    }
}