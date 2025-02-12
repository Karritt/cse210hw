using System;



//Github Copilot Disclaimer:
//The Code was written with the help of Github Copilot, but it was programmed by me.
//One Exception: The API call in Scripture.cs was written by Copilot.

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Scripture scripture = new Scripture(new Reference());
        bool isRunning = true;
        while (isRunning)
        {
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            scripture.Display();
            scripture.HideWords(3);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press any key to continue. 'q' to quit or 'r' to restart.");
            Console.ForegroundColor = ConsoleColor.White;
            char key = Console.ReadKey().KeyChar;
            if (key == 'q')
            {
                isRunning = false;
            }
            else if (key == 'r')
            {
                scripture.Reset();
            }
        }
    }
}