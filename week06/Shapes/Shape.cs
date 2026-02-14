namespace Shapes
{
    public class Shape(string color)
    {
        private string _shape_color = color;

        public string GetColor()
        {
            return _shape_color;
        }

        public void SetColor(string color)
        {
            _shape_color = color;
        }

        public virtual double GetArea()
        {
            return 0;
        }
    }
}