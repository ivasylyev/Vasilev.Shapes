using System;
using NUnit.Framework;
using Vasilev.Shapes.Library;

namespace Tests
{
    public class CircleTests
    {
        public static double Epsilon = 1E14;
        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "Verify that a circle with zero radius has a zero square")]
        public void CalculateSquareZeroRadius()
        {
            IShape circle = new Circle(0);
            var square = circle.CalculateSquare();
            Assert.IsTrue(square < Epsilon);
            Assert.Pass();
        }

        [Test(Description = "Verify that a circle with non-zero int radius has properly calculated square")]
        public void CalculateSquareNonZeroIntRadius()
        {
            IShape circle = new Circle(10);
            var square = circle.CalculateSquare();
            Assert.IsTrue(Math.Abs(Math.PI * 10 * 10 - square) < Epsilon);
            Assert.Pass();
        }

        [Test(Description = "Verify that a circle with non-zero double radius has properly calculated square")]
        public void CalculateSquareNonZeroDoubleRadius()
        {
            IShape circle = new Circle(12.3456);
            var square = circle.CalculateSquare();
            Assert.IsTrue(Math.Abs(Math.PI * 12.3456 * 12.3456 - square) < Epsilon);
            Assert.Pass();
        }

        [Test(Description = "Verify that it's impossible to create a circle with radius which will have an infinite square")]
        public void CalculateSquareBigRadiusFail()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(double.MaxValue));
            Assert.That(ex.Message, Is.EqualTo("Parameter must be less then 7.6E+153 (Parameter 'radius')"));
            Assert.Pass();
        }
        [Test(Description = "Verify that it's impossible to create a circle with non-zero radius which will have a zero square")]
        public void CalculateSquareSmallRadiusFail()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(1 / double.MaxValue));
            Assert.That(ex.Message, Is.EqualTo("Parameter must be equals to zero or greater then 1.3E-162 (Parameter 'radius')"));
            Assert.Pass();
        }
    }
}