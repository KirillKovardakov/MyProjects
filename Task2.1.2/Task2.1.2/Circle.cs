using System;
using Points;
namespace Task2
{
    public class Circle : Figure
    {
        public double R { get; set; }

        public Circle() : base()
        {
            R = 1.0;
        }
        public Circle(double x, double y, double r)
        {
            this.Point = new Point(x, y);
            R = r;
        }

        public override string Print() => $"Окружность с центром ({Point.X};{Point.Y}) и радиусом {R}";

        // метод вычисляющий площадь круга
        public virtual double Square()
        {
            double s = Math.PI * R * R;
            return s;
        }
        public virtual double Circumference() => 2 * Math.PI * R;

    }
}

