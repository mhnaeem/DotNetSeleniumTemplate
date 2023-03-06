using AventStack.ExtentReports;

namespace DotNetSeleniumTemplate.Helpers.ExtentReport
{
    public static class ExtentTestManager
    {
        [ThreadStatic]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static ExtentTest _test;
        [ThreadStatic]
        private static ExtentTest _step;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public static ExtentTest CreateTest(string testName, string description = "")
        {
            _test = ExtentService.Instance.CreateTest(testName, description);
            return _test;
        }

        public static ExtentTest CreateStep(this ExtentTest extentTest, string methodName, string description = "")
        {
            _step = extentTest.CreateNode(methodName, description);
            return _step;
        }

        public static ExtentTest GetTest() => _test;

        public static ExtentTest GetStep() => _step;

    }
}

