using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Microsoft","Software Engineer",2019,2022);
        Job job2 = new Job("Apple","Manager",2022,2023);
        List<Job> jobs = new List<Job>();
        jobs.Add(job1);
        jobs.Add(job2);
        Resume resume1 = new Resume("Karter Arritt", jobs);
        resume1.Display();
    }
}