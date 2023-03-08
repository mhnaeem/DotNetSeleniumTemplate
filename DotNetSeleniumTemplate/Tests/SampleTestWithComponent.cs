using DotNetSeleniumTemplate.Components;
using DotNetSeleniumTemplate.Helpers;
using DotNetSeleniumTemplate.Helpers.Model;
using DotNetSeleniumTemplate.Pages;
using NUnit.Framework;

namespace DotNetSeleniumTemplate.Tests
{
	[TestFixture]
	public class SampleTestWithComponent : BaseTest
	{

		[Test, Name("Component Test"), Description("Add item to inventory")]
		public void componentTestCase()
		{
			GoTo(driver, Configuration.Url);
			SamplePage page = new SamplePage(driver)
				.enterUserName("standard_user")
				.enterPassword("secret_sauce")
				.clickLoginButton();

			AssertHelper.ShouldBe(driver.Url, $"{Configuration.Url}inventory.html");

            SampleInventoryPage inventoryPage = new SampleInventoryPage(driver);
			AssertHelper.ShouldBe(inventoryPage.getNumberOfItemsInCart(), 0);

            InventoryListComponent inventoryList = new InventoryListComponent(driver)
				.addItemToCart(1);

            AssertHelper.ShouldBe(inventoryPage.getNumberOfItemsInCart(), 1);
        }
	}
}
