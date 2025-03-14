public class Specialist : Staff
{
    private string _specialistType;
    public Specialist(string fName, string lName, string gender, string specialistType) : base(fName, lName, gender)
    {
        _specialistType = specialistType;
    }

    public void DisplayGreeting()
    {
        Console.Write(GetGreetingIntro());
        Console.WriteLine($" I am a {_specialistType} specialist.");
    }
}