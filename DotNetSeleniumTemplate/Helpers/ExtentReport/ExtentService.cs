using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;

namespace DotNetSeleniumTemplate.Helpers.ExtentReport
{
	public class ExtentService
	{

        /// <summary>
        /// Current instance of the extent report object
        /// </summary>
        public static ExtentReports Instance { get; } = new();

        /// <summary>
        /// File path to the extent report
        /// </summary>
        public static string ReportPath { get; private set; }

        /// <summary>
        /// Initializes the ExtentReport with required system info
        /// </summary>
        /// <param name="currentDirectory">Directory where the the current application is running in</param>
        public static void InitializeExtentReport(string currentDirectory)
        {
            string reportsDirPath = Path.Combine(currentDirectory, "Reports", GetPrettyTimestamp(DateTime.Now));
            Directory.CreateDirectory(reportsDirPath);

            ExtentService.ReportPath = Path.Combine(reportsDirPath, "index.html");
            var htmlReporter = new ExtentHtmlReporter(ExtentService.ReportPath);
            htmlReporter.Config.Theme = Theme.Standard;
            Instance.AttachReporter(htmlReporter);
            Instance.AddSystemInfo("Environment", ConfigurationRoot.GetApplicationConfiguration().Environment);
            Instance.AddSystemInfo("Username", Environment.UserName);
        }

        /// <summary>
        /// Captures screenshot from the given <c>IWebDriver</c> instance
        /// </summary>
        /// <param name="driver">Driver to take screenshot from</param>
        /// <param name="screenShotName">Name for the screenshot object</param>
        /// <returns></returns>
        public static MediaEntityModelProvider CaptureScreenShot(IWebDriver driver, string screenShotName)
        {
            var screenshots = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshots, screenShotName).Build();
        }

        private static string GetTimestamp(DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMddHHmmss");
        }

        private static string GetPrettyTimestamp(DateTime dateTime)
        {
            return dateTime.ToString("yyyy_MM_dd_HHmmss");
        }

        private static string GetImagePath(string folderPath, string testName)
        {
            var imageName = $"{testName}_{GetTimestamp(DateTime.Now)}.png";
            return Path.Combine(folderPath, imageName);
        }

        /// <summary>
        /// Takes a new screenshot of the given <c>IWebDriver</c> instance and returns a file path to the screenshot
        /// </summary>
        /// <param name="driver">Driver to take screenshot from</param>
        /// <param name="testName">Test name to create directory structures</param>
        /// <returns></returns>
        public static string GetScreenshotPath(IWebDriver driver, string testName)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
            var imagePath = GetImagePath(folderPath, testName);

            Directory.CreateDirectory(folderPath);
            screenshot.SaveAsFile(imagePath);
            return imagePath;
        }
    }
}

