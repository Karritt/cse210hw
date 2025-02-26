using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness App!");
            Console.WriteLine("Please select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Quit");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Start();
            }
            else if (choice == "2")
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Start();
            }
            else if (choice == "3")
            {
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                reflectionActivity.Start();
            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}