using System.Reflection;
using DotNetSeleniumTemplate.Helpers;
using DotNetSeleniumTemplate.Helpers.ExtentReport;
using DotNetSeleniumTemplate.Helpers.Model;
using OpenQA.Selenium;

namespace DotNetSeleniumTemplate.Pages
{
	public class SampleInventoryPage : BasePage
	{

		private By cartItemCountSelector = By.ClassName("shopping_cart_badge");

		public SampleInventoryPage(IWebDriver driver) : base(driver)
		{
			waitUntilUrlToBe($"{ConfigurationRoot.GetApplicationConfiguration().Url}inventory.html");
		}

		public int getNumberOfItemsInCart()
		{
			try
			{
				return Int32.Parse(waitUntilElementExists(cartItemCountSelector)
					.Text);
			}
			catch
			{
				return 0;
			}
		}
    }
}
