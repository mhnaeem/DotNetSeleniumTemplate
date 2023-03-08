using System;
using DotNetSeleniumTemplate.Helpers.ExtentReport;
using System.Reflection;
using DotNetSeleniumTemplate.Helpers.Model;
using OpenQA.Selenium;

namespace DotNetSeleniumTemplate.Components
{
	public class InventoryListComponent : BaseComponent
	{
        private By inventoryListSelector = By.ClassName("inventory_list");
        private By inventoryItemSelector = By.ClassName("inventory_item");
        private By addItemButtonSelector = By.ClassName("btn_inventory");

        public InventoryListComponent(IWebDriver driver) : base(driver)
		{
			waitUntilElementIsVisible(inventoryListSelector);
		}

		public InventoryListComponent addItemToCart(int itemNumber)
		{
			waitUntilPresenceOfAllElementsLocatedBy(inventoryItemSelector)[itemNumber - 1]
				.FindElement(addItemButtonSelector)
				.Click();
            ExtentTestManager.GetTest().CreateStep($"Add item number #{itemNumber} to cart");
            return this;
		}
	}
}
