public class Resume 
{
    public string _name;
    public List<Job> _jobList;
    public Resume (string Name, List<Job> JobList)
    {
        this._name = Name;
        this._jobList = JobList;
    }

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Jobs:");
        foreach (Job job in _jobList) 
        {
            job.Display();
        }
    }
}