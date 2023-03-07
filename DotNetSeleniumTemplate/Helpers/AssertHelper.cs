using DotNetSeleniumTemplate.Helpers.ExtentReport;
using FluentAssertions;

namespace DotNetSeleniumTemplate.Helpers
{
    public static class AssertHelper
    {
        /// <summary>
        /// Asserts that both strings are equal
        /// </summary>
        /// <param name="actual">Actual value</param>
        /// <param name="expected">Expected value</param>
        public static void ShouldBe(this string actual, string expected)
        {
            ExtentTestManager.GetTest().CreateStep($"{actual} should be {expected}");
            actual.Should().Be(expected);
        }

        /// <summary>
        /// Asserts that both integers are equal
        /// </summary>
        /// <param name="actual">Actual value</param>
        /// <param name="expected">Expected value</param>
        public static void ShouldBe(this int actual, int expected)
        {
            ExtentTestManager.GetStep().Info($"Actual: {actual} Expected: {expected}");
            actual.Should().Be(expected);
        }

        /// <summary>
        /// Asserts that both booleans are equal
        /// </summary>
        /// <param name="actual">Actual value</param>
        /// <param name="expected">Expected value</param>
        public static void ShouldBe(this bool actual, bool expected)
        {
            ExtentTestManager.GetStep().Info($"Actual: {actual} Expected: {expected}");
            actual.Should().Be(expected);
        }
    }
}

