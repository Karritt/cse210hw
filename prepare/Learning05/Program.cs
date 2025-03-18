using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Circle(5, "Red"));
        shapes.Add(new Rectangle(4, 5, "Blue"));
        shapes.Add(new Square(4, "Green"));
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Area of {shape.GetColor()} shape is {shape.GetArea()}");
        }
    }
}