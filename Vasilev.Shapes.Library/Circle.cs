using System;

namespace Vasilev.Shapes.Library
{
    public class Circle : IShape
    {
        public static double MaxAllowedValue = Math.Sqrt(double.MaxValue / Math.PI);
        // It's impossible to use Math.Sqrt(double.Epsilon/Math.PI) because double.Epsilon/Math.PI equals to zero 
        public static double MinAllowedValue = Math.Sqrt(double.Epsilon) / Math.Sqrt(Math.PI);
        public double Radius { get; }
        public Circle(double radius)
        {
            VerifyRadius(radius);
            Radius = radius;
        }
        private static void VerifyRadius(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "Parameter must be a positive number");
            }
            else if (radius >= MaxAllowedValue)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), $"Parameter must be less then {MaxAllowedValue:G2}");
            }
            // we have to avoid using circles with a very small radius 
            // because squares of such circles will be equal to zero
            else if (radius > 0 && radius <= MinAllowedValue)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), $"Parameter must be equals to zero or greater then {MinAllowedValue:G2}");
            }
        }
        public double CalculateSquare()
        {
            return Math.PI * Radius * Radius;
        }
        public override string ToString()
        {
            return $"R={Radius}";
        }
    }
}
