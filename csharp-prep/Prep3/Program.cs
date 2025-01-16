using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int guessMe = randomGenerator.Next(1,100);
        int guess = 0;
        do
        {
            Console.Write("Guess a number between 1 and 100 >");
            guess = int.Parse(Console.ReadLine());
            if (guess < guessMe)
            {
                Console.WriteLine("It's higher!");
            } else if (guess > guessMe) 
            {
                Console.WriteLine("It's lower!");
            }
        } while (guess != guessMe);
        Console.WriteLine("You Win!");
    }
}