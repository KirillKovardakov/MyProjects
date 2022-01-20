using System;
namespace Task2
{
    public class Circle : Point
    {
        public double R { get; set; }


        public Circle() : base()
        {
            R = 1.0;
        }
        public Circle(double x, double y, double r) : base(x, y)
        {
            R = r;
        }

        public override string Print() => $"Окружность с центром ({X};{Y}) и радиусом {R}";
        
        // метод вычисляющий площадь круга
        public override double Square()
        {
            double s = Math.PI * R * R;
            return s;
        }
        public virtual double Circumference() => 2 * Math.PI * R;

    }
}

