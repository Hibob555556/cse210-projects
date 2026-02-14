namespace Shapes
{
    public class Rectangle(string color, double length, double width) : Shape(color)
    {
        private double _width = width;
        private double _length = length;

        public override double GetArea()
        {
            return _length * _width;
        }
    }
}