using System;
using DotNetSeleniumTemplate.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace DotNetSeleniumTemplate.Helpers
{
    /// <summary>
    /// Allows us to assign a <c>Name</c> property to a test
    /// </summary>
    /// <example>
    /// For example:
    /// <code>
    /// [Test, Name("Some Test Case")]
    /// void someTestCase() {}
    /// </code>
    /// </example>
    public class NameAttribute : NUnitAttribute, IApplyToTest
    {
        public NameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void ApplyToTest(Test test)
        {
            test.Properties.Add("Name", Name);
        }
    }
}
