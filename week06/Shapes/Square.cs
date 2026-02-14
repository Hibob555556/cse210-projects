namespace Shapes
{
    public class Square(string color, double side) : Shape(color)
    {
        private double _side_len = side;

        public override double GetArea()
        {
            return _side_len * _side_len;
        }
    }
}