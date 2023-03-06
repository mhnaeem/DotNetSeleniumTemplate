using OpenQA.Selenium;

namespace DotNetSeleniumTemplate.Helpers.Model
{
	public abstract class BasePage
	{
		protected readonly IWebDriver driver;

		public BasePage(IWebDriver driver)
		{
			this.driver = driver;
		}
	}
}

