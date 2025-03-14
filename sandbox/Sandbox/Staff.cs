public class Staff
{
    private string _fName;
    private string _lName;
    private string _gender;

    public Staff(string fName, string lName, string gender)
    {
        _fName = fName;
        _lName = lName;
        _gender = gender;
    }

    public string GetGreetingIntro()
    {
        return $"Hello students, I am {_gender} {_lName}.";
    }
}