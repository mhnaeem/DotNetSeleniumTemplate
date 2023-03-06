using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotNetSeleniumTemplate.Helpers
{
	public static class WaitHelper
	{

		public static IWebElement waitForElementToBeVisible(IWebDriver driver, By bySelector)
		{
			WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 15));
			return wait.Until(ExpectedConditions.ElementIsVisible(bySelector));
		}

	}
}
