using System;

namespace Vasilev.Shapes.Library
{
    public class Triangle : IShape
    {
        // It's a really rough estimation for the maximum allowed number. 
        // If it required it's possible to find out the more precise value
        public static double MaxAllowedValue = Math.Sqrt(Math.Sqrt(double.MaxValue / 4));
        // It's a really rough estimation for the minimum allowed number. 
        // maybe we have to calculate a better limit 
        public static double MinAllowedValue = 2 * Math.Sqrt(Math.Sqrt(double.Epsilon));
        // sizes should not be greater each other in 1E14 times, otherwise there will be lost of precision
        public static double MaxAllowedRelativeDifference = 1E14;

        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }
        public double Perimeter => SideA + SideB + SideC;

        public bool IsRectangular
        {
            get
            {
                double squareA = SideA * SideA;
                double squareB = SideB * SideB;
                double squareC = SideC * SideC;
                return Math.Abs(squareA + squareB - squareC) < double.Epsilon ||
                    Math.Abs(squareA + squareC - squareB) < double.Epsilon ||
                    Math.Abs(squareC + squareB - squareA) < double.Epsilon;
            }
        }

        public Triangle(double a, double b, double c)
        {
            VerifySides(a, b, c);
            SideA = a;
            SideB = b;
            SideC = c;
        }

        private static void VerifySides(double a, double b, double c)
        {
            VerifySideLength(a, nameof(a));
            VerifySideLength(b, nameof(b));
            VerifySideLength(c, nameof(c));
            VerifySidesSum(a, b, c);
            VerifySidesSum(b, c, a);
            VerifySidesSum(c, a, b);
            VerifySidesRelativeValues(a, b);
            VerifySidesRelativeValues(b, c);
            VerifySidesRelativeValues(c, a);
        }
        private static void VerifySideLength(double side, string paramName)
        {
            // side cannot be a negative number
            // we also have to avoid using triagles with positive sides that are too small
            // because squares of such triangles will be equal to zero
            if (side <= MinAllowedValue)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Parameter must be greater then {MinAllowedValue:G2}");
            }
            else if (side >= MaxAllowedValue)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Parameter must be less then {MaxAllowedValue:G2}");
            }

        }
        private static void VerifySidesSum(double a, double b, double c)
        {
            // the sum of two sides cannot be less or equals to the third side
            // but also the sum of two sides cannot be to close to the the third side
            // because squares of such triangles will be equal to zero
            if (a + b - c < MinAllowedValue)
            {
                throw new ArgumentException($"The sum of two sides must be greater than the third side for more than {MinAllowedValue:G2}");
            }
        }
        private static void VerifySidesRelativeValues(double a, double b)
        {
            // double has 14-15 significant digits
            // so it's not allowed to have sizes that differs in 1E14 times
            // because ther will be a serious lost of presision
            if (a / b > MaxAllowedRelativeDifference || b / a > MaxAllowedRelativeDifference)
            {
                throw new ArgumentException($"The side must not be in {MaxAllowedRelativeDifference:G2} times or more bigger then others");
            }
        }

        public double CalculateSquare()
        {
            var halfPerimeter = Perimeter / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));
        }
    }
}
