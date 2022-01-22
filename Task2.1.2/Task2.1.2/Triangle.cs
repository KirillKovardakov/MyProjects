using System;
using Points;

namespace Task2
{
    public class Triangle : Line
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Point Point3 { get; set; }

        public Triangle()
        {
            Point1 = new Point(0.0, 0.0);
            Point2 = new Point(0.0, 0.0);
            Point3 = new Point(0.0, 0.0);
        }
        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Point1 = new Point(x1, y1);
            Point2 = new Point(x2, y2);
            Point3 = new Point(x3, y3);
        }
        public override string Print() => $"Треугольник с точками: x1 = {Point1}, x2 = {Point2} и x3 = {Point3}";

        public override double Square()
        {
            double a11 = Point1.X - Point3.X;
            double a12 = Point1.Y - Point3.Y;
            double a21 = Point2.X - Point3.X;
            double a22 = Point2.Y - Point3.Y;
            return 0.5 * Math.Abs(a11 * a22 - a12 * a21);
        }
    }
}
