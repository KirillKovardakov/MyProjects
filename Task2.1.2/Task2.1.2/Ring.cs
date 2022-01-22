using System;
using Points;

namespace Task2
{
    public class Ring : Circle
    {
        public double InnerRadius { get; set; }
        public double OuterRadius { get; set; }

        public Ring()
        {
        }
        public Ring(double x, double y, double innerRadius, double outerRadius)
        {
            this.Point = new Point(x, y);
            InnerRadius = innerRadius;
            OuterRadius = outerRadius;
        }
        public override string Print() => $"Кольцо:\n\r с центром: ({Point.X};{Point.Y})" +
                $", внутреннем радиусом: {InnerRadius} " +
                $"и внешним радиусом: {OuterRadius}";

        public override double Square()
        {
            double s = Math.PI * (OuterRadius * OuterRadius - InnerRadius * InnerRadius);
            return s;
        }
        public override double Circumference() => 2 * Math.PI * (InnerRadius + OuterRadius);

    }
}
