using System;

namespace Task2
{
    public class Line : Point
    {
        public double Length { get; set; }
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
        public override double Square()
        {
            return 0;
        }
        
    }
}
