using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square a1 = new Square("Blue", 2);
        shapes.Add(a1);

        Rectangle a2 = new Rectangle("Green", 3, 4);
        shapes.Add(a2);

        Circle a3 = new Circle("Yellow", 5);
        shapes.Add(a3);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();

            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}