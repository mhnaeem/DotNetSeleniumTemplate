﻿using System.Reflection;
using DotNetSeleniumTemplate.Helpers.ExtentReport;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotNetSeleniumTemplate.Helpers.Model
{
	public class BaseTest
	{

        public static AppSettings Configuration = ConfigurationRoot.GetApplicationConfiguration();
        private static readonly string CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		protected IWebDriver driver;

		[OneTimeSetUp]
		public void OneTimeSetupBeforeTestSuite()
		{
			ExtentService.InitializeExtentReport(CurrentDirectory);
		}

		[OneTimeTearDown]
		public void OneTimeTearDownAfterTestSuite()
		{
			ExtentService.Instance.Flush();
		}

		[SetUp]
		public void BeforeEach()
		{
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 15);
            driver.Manage().Timeouts().AsynchronousJavaScript = new TimeSpan(0, 0, 15);
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 60);
			ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
        }

		[TearDown]
		public void AfterEach()
		{
			if(TestContext.CurrentContext.Result.Outcome.Equals(TestStatus.Failed))
			{
				var path = ExtentService.GetScreenshotPath(driver, TestContext.CurrentContext.Test.Name);
				TestContext.AddTestAttachment(path);
			}

			LogToExtentReport();
			driver.Quit();
		}

		private void LogToExtentReport()
		{
			string filename = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:h_mm_ss}.png";

			if(TestContext.CurrentContext.Result.Outcome.Equals(TestStatus.Passed))
			{
				ExtentTestManager.GetTest().Pass("Test Passed");
			}
			else
			{
				var mediaEntity = ExtentService.CaptureScreenShot(driver, filename);
				ExtentTestManager.GetTest().Fail("Test Failed", mediaEntity);
				ExtentTestManager.GetStep().Fail("Step Failed", mediaEntity);
			}
		}

		public static void GoTo(IWebDriver driver, string url)
		{
			driver.Navigate().GoToUrl(url);
			ExtentTestManager.GetTest().CreateStep($"{MethodBase.GetCurrentMethod()?.Name} {url}");
		}
	}
}

