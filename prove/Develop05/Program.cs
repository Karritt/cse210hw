using System;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        //main variables
        List<Goal> goals = new List<Goal>();
        int score = 0;

        //load goals and score from file
        string filename = "goals.txt";
        if (!File.Exists(filename))
        {
            File.Create(filename).Close();
            File.WriteAllText(filename, "score::0");
        } else {
            List<string> lines = File.ReadAllLines(filename).ToList();
            string firstLine = lines[0];
            score = int.Parse(firstLine.Split("::")[1]);
            lines.RemoveAt(0);
            foreach (string line in lines)
            {
                string [] parts = line.Split(";;");
                string type = parts[0].Split("::")[1];
                string name = parts[1].Split("::")[1];
                string description = parts[2].Split("::")[1];
                int pointValue = int.Parse(parts[3].Split("::")[1]);
                if (type == "Onetime")
                {
                    goals.Add(new Onetime(name, description, pointValue));
                }
                else if (type == "Repeatable")
                {
                    goals.Add(new Repeatable(name, description, pointValue));
                }
                else if (type == "Checklist")
                {
                    int bonusPoints = int.Parse(parts[4].Split("::")[1]);
                    int maxTimes = int.Parse(parts[5].Split("::")[1]);
                    int timesCompleted = int.Parse(parts[6].Split("::")[1]);
                    goals.Add(new Checklist(name, description, pointValue, bonusPoints, maxTimes, timesCompleted));
                }
            }
        }
        
        

        //run the program
        while (true)
        {
            Console.Write($"{score}~>");
            string command = Console.ReadLine();
            switch (command)
            {
                case "exit":
                    Console.WriteLine("Saving...");
                    List<string> output = new List<string>();
                    output.Add("score::" + score);
                    foreach (Goal goal in goals)
                    {
                        output.Add(goal.Serialize());
                    }
                    File.WriteAllLines(filename, output);
                    return;
                    break;
                case "list":
                    foreach (Goal goal in goals)
                    {
                        Console.WriteLine(goal.GetInformation());
                    }
                    break;
                case "complete":
                    Console.Write("Enter goal name: ");
                    string goalName = Console.ReadLine();
                    foreach (Goal goal in goals)
                    {
                        if (goal.GetName() == goalName)
                        {
                            int points = goal.Complete();
                            if (points == 0)
                            {
                                Console.WriteLine($"Goal {goalName} is already completed.");
                                break;
                            }
                            score += points;
                            Console.WriteLine($"Completed {goalName} for {points} points.");
                            break;
                        }
                    }
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "create":
                    Console.Write("Enter goal name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter goal description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter goal point value: ");
                    int pointValue = int.Parse(Console.ReadLine());
                    Console.Write("Enter goal type (Onetime, Repeatable, Checklist): ");
                    string type = Console.ReadLine();
                    if (type == "Onetime")
                    {
                        goals.Add(new Onetime(name, description, pointValue));
                    }
                    else if (type == "Repeatable")
                    {
                        goals.Add(new Repeatable(name, description, pointValue));
                    }
                    else if (type == "Checklist")
                    {
                        Console.Write("Enter bonus points: ");
                        int bonusPoints = int.Parse(Console.ReadLine());
                        Console.Write("Enter max times: ");
                        int maxTimes = int.Parse(Console.ReadLine());
                        goals.Add(new Checklist(name, description, pointValue, bonusPoints, maxTimes));
                    }
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    Console.WriteLine("Commands: exit, list, complete, clear, create");
                    break;
            }
        }

    }
}