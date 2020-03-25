using System;
using NUnit.Framework;
using Vasilev.Shapes.Library;

namespace Tests
{
    public class TriangleTests
    {
        public static double Epsilon = 1E14;

        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "Calculate a square of the rectangular triangle")]
        public void CalculateSquareRectangular()
        {
            IShape triangle = new Triangle(3, 4, 5);
            var square = triangle.CalculateSquare();
            Assert.IsTrue(Math.Abs((3 * 4) / 2 - square) < Epsilon);
            Assert.Pass();
        }

        [Test(Description = "Check if the triangle is rectangular")]
        public void CheckRectangular()
        {
            Triangle triangle = new Triangle(3, 4, 5);           
            Assert.IsTrue(triangle.IsRectangular);
            Assert.Pass();
        }

        [Test(Description = "Check if the triangle is not rectangular")]
        public void CheckNotRectangular()
        {
            Triangle triangle = new Triangle(3.12, 4.43, 5.55);
            Assert.IsFalse(triangle.IsRectangular);
            Assert.Pass();
        }

        [Test(Description = "Calculate a square of the Geron triangle")]
        public void CalculateSquareGeron()
        {
            IShape triangle = new Triangle(15, 13, 4);
            var square = triangle.CalculateSquare();
            Assert.IsTrue(Math.Abs(24 - square) < Epsilon);
            Assert.Pass();
        }

        [Test(Description = "Calculate a square of the ordinary triangle")]
        public void CalculateSquareOrdinary()
        {
            IShape triangle = new Triangle(100.83, 100.84, 100.85);
            var square = triangle.CalculateSquare();
            Assert.IsTrue(Math.Abs(4403.1786 - square) < Epsilon);
            Assert.Pass();
        }

        [Test(Description = "Verify that it's impossible to create a triangle with zero side")]
        public void CalculateZeroSide()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(0, 1, 2));
            Assert.That(ex.Message, Is.EqualTo("Parameter must be greater then 3E-81 (Parameter 'a')"));
            Assert.Pass();
        }

        [Test(Description = "Verify that it's impossible to create a triangle with negative side")]
        public void CalculateNegativeSide()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, -1, 2));
            Assert.That(ex.Message, Is.EqualTo("Parameter must be greater then 3E-81 (Parameter 'b')"));
            Assert.Pass();
        }

        [Test(Description = "Verify that it's impossible to create a triangle which will have an infinite square")]
        public void CalculateSquareBigSizeFail()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(double.MaxValue, double.MaxValue, double.MaxValue));
            Assert.That(ex.Message, Is.EqualTo("Parameter must be less then 8.2E+76 (Parameter 'a')"));
            Assert.Pass();
        }
        [Test(Description = "Verify that it's impossible to create a triangle when the difference between sizes is more than the number of significant digint in double")]
        public void CalculateSquareBigRelativeDifferenceFail()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Triangle(1, 1E15, 1E15));
            Assert.That(ex.Message, Is.EqualTo("The side must not be in 1E+14 times or more bigger then others"));
            Assert.Pass();
        }
    }
}