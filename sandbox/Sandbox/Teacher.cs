public class Teacher : Staff
{
    private int _roomNumber;
    public Teacher(string fName, string lName, string gender, int roomNumber) : base(fName, lName, gender)
    {
        _roomNumber = roomNumber;
    }

    public void DisplayGreeting()
    {
        Console.Write(GetGreetingIntro());
        Console.WriteLine($" I teach in room {_roomNumber}.");
    }
}