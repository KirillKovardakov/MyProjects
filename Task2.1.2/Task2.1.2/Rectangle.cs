using System;
using Points;

namespace Task2
{
    public class Rectangle : Line
    {
        protected double _width = 0;
        public double Width { get => _width; set { _width = value; } }
        public Rectangle() : base(0.0)
        {
            Width = 0.0;
        }
        public Rectangle(double a, double b)
        {
            Length = a;
            Width = b;
        }
        public override string Print() => $"Прямоугольник со сторонами: {Length} и  {Width}";

        public override double Square() => Length * Width;
    }
}
