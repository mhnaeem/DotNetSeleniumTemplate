using System.Reflection;
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

		/// <summary>
		/// A one time setup that is run before running any tests
		/// </summary>
		[OneTimeSetUp]
		protected void OneTimeSetupBeforeTestSuite()
		{
			ExtentService.InitializeExtentReport(CurrentDirectory);
		}

		/// <summary>
		/// A one time tear down that is run after all tests have been run
		/// </summary>
		[OneTimeTearDown]
		protected void OneTimeTearDownAfterTestSuite()
		{
			ExtentService.Instance.Flush();
			Console.WriteLine($"The report has been exported to: {ExtentService.ReportPath}");
        }

        /// <summary>
        /// Runs before every single test is executed
        /// </summary>
        /// <example>
        ///	This method can be overridden in any of the inheriting subclasses like below
		/// <code>
        /// protected override void BeforeEach()
        /// {
		///     // run the method from super class to create driver
        ///     base.BeforeEach();
		///
		///     // any other code you want to run before each test
        /// }
        /// </code>
        /// </example>
        [SetUp]
		protected virtual void BeforeEach()
		{
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 15);
            driver.Manage().Timeouts().AsynchronousJavaScript = new TimeSpan(0, 0, 15);
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 60);

			string name = TestContext.CurrentContext.Test.Name;
			string description = "";
            if (TestContext.CurrentContext.Test.Properties.ContainsKey("Name"))
            {
                name = TestContext.CurrentContext.Test.Properties.Get("Name") as string;
            }
            if (TestContext.CurrentContext.Test.Properties.ContainsKey("Description"))
            {
                description = TestContext.CurrentContext.Test.Properties.Get("Description") as string;
            }
            ExtentTestManager.CreateTest(name, description);
        }

        /// <summary>
        /// Runs after every test is executed
        /// </summary>
        ///	This method can be overridden in any of the inheriting subclasses like below
        /// <code>
        /// protected override void AfterEach()
        /// {
        ///     // run the method from super class to remove driver
        ///     base.AfterEach();
        ///
        ///     // any other code you want to run after each test
        /// }
        /// </code>
        /// </example>
        [TearDown]
		protected virtual void AfterEach()
		{
			if(TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
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

			if(TestContext.CurrentContext.Result.Outcome == ResultState.Success)
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

		/// <summary>
		/// Navigates the <c>IWebDriver</c> instance to the given URL
		/// </summary>
		/// <param name="driver">Driver to navigate</param>
		/// <param name="url">URL to navigate to</param>
		protected static void GoTo(IWebDriver driver, string url)
		{
			driver.Navigate().GoToUrl(url);
			ExtentTestManager.GetTest().CreateStep($"{MethodBase.GetCurrentMethod()?.Name} {url}");
		}
	}
}

