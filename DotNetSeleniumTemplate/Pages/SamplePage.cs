﻿using System.Reflection;
using DotNetSeleniumTemplate.Helpers;
using DotNetSeleniumTemplate.Helpers.ExtentReport;
using DotNetSeleniumTemplate.Helpers.Model;
using OpenQA.Selenium;

namespace DotNetSeleniumTemplate.Pages
{
	public class SamplePage : BasePage
	{

		private By loginButtonSelector = By.ClassName("submit-button");
		private By usernameFieldSelector = By.Id("user-name");
		private By passwordFieldSelector = By.CssSelector("[data-test='password']");
		private By errorTextSelector = By.CssSelector(".error-message-container");

		public SamplePage(IWebDriver driver) : base(driver)
		{
		}

		public SamplePage enterUserName(string userName)
		{
			waitUntilElementIsVisible(driver, usernameFieldSelector)
				.SendKeys(userName);
			ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod()?.Name, "Entered Username");
			return this;
		}

        public SamplePage enterPassword(string password)
        {
            waitUntilElementIsVisible(driver, passwordFieldSelector)
                .SendKeys(password);
            ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod()?.Name, "Entered Password");
            return this;
        }

		public SamplePage clickLoginButton()
		{
            waitUntilElementIsVisible(driver, loginButtonSelector)
                .Click();
            ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod()?.Name, "Clicked Login Button");
            return this;
        }

		public string getErrorText()
		{
			return waitUntilElementIsVisible(driver, errorTextSelector)
				.Text;
		}
    }
}

