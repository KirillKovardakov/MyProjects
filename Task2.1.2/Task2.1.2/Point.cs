using System;
namespace Task2
{
    public class Point
    {
        public double X { get; set; } 
        public double Y { get; set; }
        public Point()
        {
            X = 0.0;
            Y = 0.0;
        }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public virtual string Print() => $"({X}; {Y})";
        // метод вычисляющий площадь 
        public virtual double Square()
        {
            return 0;
        }
        public override string ToString()
        {
            return $"({X}; {Y})";
        }
    }
    
}
