using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace DotNetSeleniumTemplate.Helpers
{
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
