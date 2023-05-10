using INVENTORY.Console;

namespace NUnitTest
{
    public class MathematicsTests
    {
        private Mathematics mathematics { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            mathematics = new Mathematics();
        }

        [Test]
        public void AddTwoNumber_EqualTest()
        {
            // Assign
            var num1 = 5; var num2 = 9;

            // Act
            var result = mathematics.AddTwoNumbers(num1, num2);

            //Assert
            Assert.That(result, Is.EqualTo(14));
        }

        [TestCase(4,10)]
        [TestCase(7, 7)]
        [TestCase(11, 3)]
        public void AddTwoNumbers_EqualTest(int num1, int num2)
        {
            // Assign
            //var num1 = 5; var num2 = 9;

            // Act
            var result = mathematics.AddTwoNumbers(num1, num2);

            //Assert
            Assert.That(result, Is.EqualTo(14));
        }
    }
}