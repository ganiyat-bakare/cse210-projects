using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square shape1 = new Square("Red", 2);
        shapes.Add(shape1);
        
        Rectangle shape2 = new Rectangle("Pink", 4, 6);
        shapes.Add(shape2);
        
        Circle shape3 = new Circle("Blue", 8);
        shapes.Add(shape3);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();

            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}");
        }
        
    }
}