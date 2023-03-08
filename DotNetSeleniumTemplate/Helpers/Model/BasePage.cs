using OpenQA.Selenium;

namespace DotNetSeleniumTemplate.Helpers.Model
{
	public abstract class BasePage : BaseComponent
	{
		public BasePage(IWebDriver driver) : base(driver)
		{
		}
	}
}
