namespace Shapes
{
    using System;

    public class Circle(string color, double radius) : Shape(color)
    {
        private double _radius = radius;

        public override double GetArea()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }
    }
}