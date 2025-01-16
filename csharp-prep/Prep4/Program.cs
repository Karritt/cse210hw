using System;

class Program
{
    static void Main(string[] args)
    {
        int userInput;
        List<int> numbers = new List<int>();
        do {
            Console.WriteLine("Enter a Number. ");
            userInput = int.Parse(Console.ReadLine());
            numbers.Add(userInput);
        } while (userInput != 0);
        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is: {(numbers.Sum() * 1.0)/numbers.Count}");
        Console.WriteLine($"The largest number is: {numbers.Max()}");
    }
}