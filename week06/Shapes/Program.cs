using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("             POLYMORPHISM SHAPES TEST             ");
        Console.WriteLine("==================================================\n");
        
        List<Shape> shapesList = new List<Shape>();

        // Populate the list with different inherited objects
        shapesList.Add(new Square("Red", 4.0));
        shapesList.Add(new Rectangle("Blue", 5.0, 6.0));
        shapesList.Add(new Circle("Green", 3.0));

        // Iterate seamlessly through the list utilizing Polymorphism
        foreach (Shape shape in shapesList)
        {
            string color = shape.GetColor();

            double area = shape.GetArea();

            Console.WriteLine($"Shape Color: {color,-8} | Calculated Area: {area:F2}");
        }

        Console.WriteLine("\n==================================================");
    }
}