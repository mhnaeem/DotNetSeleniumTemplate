using System;
using DotNetSeleniumTemplate.Helpers;
using DotNetSeleniumTemplate.Helpers.ExtentReport;
using DotNetSeleniumTemplate.Helpers.Model;
using DotNetSeleniumTemplate.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace DotNetSeleniumTemplate.Tests
{
    [TestFixture]
    public class SampleTestWithOverride : BaseTest
	{

        protected override void BeforeEach()
        {
            base.BeforeEach();

            // do something extra before running each test in this fixture
            GoTo(driver, "https://google.com");
        }

        [Test, Name("Override Passing Test"), Description("Login successfully with correct details")]
        public void overridePassingTestCase()
        {
            GoTo(driver, Configuration.Url);
            SamplePage page = new SamplePage(driver)
                .enterUserName("standard_user")
                .enterPassword("secret_sauce")
                .clickLoginButton();

            AssertHelper.ShouldBe(driver.Url, $"{Configuration.Url}inventory.html");
        }
    }
}

