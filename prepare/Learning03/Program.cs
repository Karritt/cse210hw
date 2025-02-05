using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction one = new Fraction();
        Fraction six = new Fraction(6);
        Fraction sixSeven = new Fraction(6, 7);

        Console.WriteLine(one.GetFractionString());
        Console.WriteLine(sixSeven.GetDecimalValue());
    }
}