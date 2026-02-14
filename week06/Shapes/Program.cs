namespace Shapes
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes =
            [
                new Square("Red", 6),
                new Rectangle("Green", 7, 5),
                new Circle("Blue", 2)
            ];

            foreach (Shape s in shapes)
            {
                Console.WriteLine($"{s.GetColor()} area: {s.GetArea():F2}");
            }
        }
    }
}