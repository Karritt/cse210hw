public class Job 
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;
    
    public Job (string Company, string JobTitle, int StartYear, int EndYear) 
    {
        _company = Company;
        _jobTitle = JobTitle;
        _startYear = StartYear;
        _endYear = EndYear;
    }

    public void Display ()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }

}