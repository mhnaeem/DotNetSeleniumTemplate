using OpenQA.Selenium;

namespace DotNetSeleniumTemplate.Helpers.Model
{
	public abstract class BasePage : WaitHelper
	{
		protected readonly IWebDriver driver;

		public BasePage(IWebDriver driver) : base(driver)
		{
			this.driver = driver;
		}
	}
}

