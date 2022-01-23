using System;
using Points;

namespace Task2
{
    public class Line : Figure
    {
        protected double _length = 0;
        public double Length { get => _length; set { _length = value; } }
        public Line()
        {
            Length = 0.0;
        }
        public Line(double length)
        {
            Length = length;
        }
        public Line(double x1, double x2)
        {
            Length = Math.Abs(x1 - x2);
        }
        public override string Print() => $"Линия длиной {Length}cm";

        // метод вычисляющий площадь круга
        public virtual double Square()
        {
            return 0;
        }

    }
}
