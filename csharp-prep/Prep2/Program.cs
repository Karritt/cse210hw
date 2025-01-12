using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Grade Percentage? ");
        int gradePercent = int.Parse(Console.ReadLine());
        string grade;
        if (gradePercent >= 90) {
            grade = "A";
        } else if (gradePercent >= 80) {
            grade = "B";
        } else if (gradePercent >= 70) {
            grade = "C";
        } else if (gradePercent >= 60) {
            grade = "D";
        } else {
            grade = "F";
        }

        Console.WriteLine("Your grade is: " + grade);
        if (gradePercent>=70) {Console.WriteLine("You Passed!");} else {Console.WriteLine("Better Luck Next Time.");}
    }
}