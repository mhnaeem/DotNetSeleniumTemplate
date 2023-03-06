using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;

namespace DotNetSeleniumTemplate.Helpers.ExtentReport
{
	public class ExtentService
	{
        public static ExtentReports Instance { get; } = new();

        public static void InitializeExtentReport(string currentDirectory)
        {
            var reportsPath = Path.Combine(currentDirectory, "Reports", GetPrettyTimestamp(DateTime.Now));
            Directory.CreateDirectory(reportsPath);

            var htmlReporter = new ExtentHtmlReporter(Path.Combine(reportsPath, "index.html"));
            htmlReporter.Config.Theme = Theme.Standard;
            Instance.AttachReporter(htmlReporter);
            Instance.AddSystemInfo("Environment", ConfigurationRoot.GetApplicationConfiguration().Environment);
        }

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

