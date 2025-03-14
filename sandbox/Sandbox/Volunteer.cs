public class Volunteer : Staff
{
    public Volunteer(string fName, string lName, string gender) : base(fName, lName, gender) {}

    public void DisplayGreeting()
    {
        Console.Write(GetGreetingIntro());
        Console.WriteLine($" I am a volunteer at the school.");
    }
}