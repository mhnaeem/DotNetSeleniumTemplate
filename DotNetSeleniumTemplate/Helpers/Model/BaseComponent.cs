using OpenQA.Selenium;

namespace DotNetSeleniumTemplate.Helpers.Model
{
	public abstract class BaseComponent : WaitHelper
	{
		public BaseComponent(IWebDriver driver) : base(driver)
		{
		}
	}
}
