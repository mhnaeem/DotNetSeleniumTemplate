using DotNetSeleniumTemplate.Helpers;
using DotNetSeleniumTemplate.Helpers.Model;
using DotNetSeleniumTemplate.Pages;
using NUnit.Framework;

namespace DotNetSeleniumTemplate.Tests
{
	[TestFixture]
	public class SampleTest : BaseTest
	{

		[Test, Name("Failing Test"), Description("Try login with incorrect details")]
		public void failingTestCase()
		{
			GoTo(driver, Configuration.Url);
			SamplePage page = new SamplePage(driver)
				.enterUserName("blah@example.com")
				.enterPassword("12345")
				.clickLoginButton();
			AssertHelper.ShouldBe(page.getErrorText(), "No Errors");
		}

		[Test, Name("Passing Test"), Description("Login successfully with correct details")]
		public void passingTestCase()
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
