using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        DisplayResult(PromptUserName(), SquareNumber(PromptUserNumber()));
    }
    static void DisplayWelcome () {
        Console.WriteLine ("Welcome to the Program!");
    }

    static string PromptUserName () {
        Console.Write("What is your username? ");
        return Console.ReadLine ();
    }

    static int PromptUserNumber () {
        Console.Write ("What is your favorite number? ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber (int inNum) {
        return inNum*inNum;
    }

    static void DisplayResult(string userName, int squareNumber) {
        Console.WriteLine ($"{userName}, the square of your number is {squareNumber}");
    }
}