using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        while (true)
        {
            Console.WriteLine("1. Add Entry (With Prompt)");
            Console.WriteLine("2. Add Entry (Without Prompt)");
            Console.WriteLine("3. Display Entries");
            Console.WriteLine("4. Save to CSV");
            Console.WriteLine("5. Load from CSV");
            Console.WriteLine("6. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.AddEntryNoPrompt();
                    break;
                case "3":
                    journal.DisplayEntries();
                    break;
                case "4":
                    Console.WriteLine("Enter filename:");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToCSV(saveFilename);
                    break;
                case "5":
                    Console.WriteLine("Enter filename:");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromCSV(loadFilename);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}