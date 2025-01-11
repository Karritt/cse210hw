using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("fName? ");
        string fName = Console.ReadLine();
        Console.Write("lName? ");
        string lName = Console.ReadLine();
        Console.Write($"Your name is {lName}, {fName} {lName}");
    }
}