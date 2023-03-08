using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DotNetSeleniumTemplate.Helpers
{
	public class WaitHelper
	{

		private static readonly TimeSpan DEFAULT_WAIT_TIME = new TimeSpan(0, 0, 15);


        protected readonly IWebDriver driver;
        public WaitHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Generic Wait
        private static IWebElement waitUntilWrapper(IWebDriver driver, Func<IWebDriver, IWebElement> condition, TimeSpan timeSpan)
		{
            return new WebDriverWait(driver, timeSpan)
				.Until(condition);
        }

        private static IWebElement waitUntilWrapper(IWebDriver driver, Func<IWebDriver, IWebElement> condition)
        {
            return new WebDriverWait(driver, DEFAULT_WAIT_TIME)
                .Until(condition);
        }

        private static ReadOnlyCollection<IWebElement> waitUntilWrapper(IWebDriver driver, Func<IWebDriver, ReadOnlyCollection<IWebElement>> condition, TimeSpan timeSpan)
        {
            return new WebDriverWait(driver, timeSpan)
                .Until(condition);
        }

        private static ReadOnlyCollection<IWebElement> waitUntilWrapper(IWebDriver driver, Func<IWebDriver, ReadOnlyCollection<IWebElement>> condition)
        {
            return new WebDriverWait(driver, DEFAULT_WAIT_TIME)
                .Until(condition);
        }

        private static bool waitUntilWrapper(IWebDriver driver, Func<IWebDriver, bool> condition, TimeSpan timeSpan)
        {
            return new WebDriverWait(driver, timeSpan)
                .Until(condition);
        }

        private static bool waitUntilWrapper(IWebDriver driver, Func<IWebDriver, bool> condition)
        {
            return new WebDriverWait(driver, DEFAULT_WAIT_TIME)
                .Until(condition);
        }
        #endregion

        #region ElementIsVisible
        public static IWebElement waitUntilElementIsVisible(IWebDriver driver, By bySelector)
		{
			return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.ElementIsVisible(bySelector));
		}

        public static IWebElement waitUntilElementIsVisible(IWebDriver driver, By bySelector, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.ElementIsVisible(bySelector), timeSpan);
        }

        public IWebElement waitUntilElementIsVisible(By bySelector)
        {
            return WaitHelper.waitUntilElementIsVisible(driver, bySelector);
        }

        public IWebElement waitUntilElementIsVisible(By bySelector, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilElementIsVisible(driver, bySelector, timeSpan);
        }
        #endregion

        #region VisibilityOfAllElementsLocatedBy
        public static ReadOnlyCollection<IWebElement> waitUntilVisibilityOfAllElementsLocatedBy(IWebDriver driver, By bySelector)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.VisibilityOfAllElementsLocatedBy(bySelector));
        }

        public static ReadOnlyCollection<IWebElement> waitUntilVisibilityOfAllElementsLocatedBy(IWebDriver driver, By bySelector, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.VisibilityOfAllElementsLocatedBy(bySelector), timeSpan);
        }

        public ReadOnlyCollection<IWebElement> waitUntilVisibilityOfAllElementsLocatedBy(By bySelector)
        {
            return WaitHelper.waitUntilVisibilityOfAllElementsLocatedBy(driver, bySelector);
        }

        public ReadOnlyCollection<IWebElement> waitUntilVisibilityOfAllElementsLocatedBy(By bySelector, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilVisibilityOfAllElementsLocatedBy(driver, bySelector, timeSpan);
        }
        #endregion

        #region PresenceOfAllElementsLocatedBy
        public static ReadOnlyCollection<IWebElement> waitUntilPresenceOfAllElementsLocatedBy(IWebDriver driver, By bySelector)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.PresenceOfAllElementsLocatedBy(bySelector));
        }

        public static ReadOnlyCollection<IWebElement> waitUntilPresenceOfAllElementsLocatedBy(IWebDriver driver, By bySelector, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.PresenceOfAllElementsLocatedBy(bySelector), timeSpan);
        }

        public ReadOnlyCollection<IWebElement> waitUntilPresenceOfAllElementsLocatedBy(By bySelector)
        {
            return WaitHelper.waitUntilPresenceOfAllElementsLocatedBy(driver, bySelector);
        }

        public ReadOnlyCollection<IWebElement> waitUntilPresenceOfAllElementsLocatedBy(By bySelector, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilPresenceOfAllElementsLocatedBy(driver, bySelector, timeSpan);
        }
        #endregion

        #region TitleIs
        public static bool waitUntilTitleIs(IWebDriver driver, string expectedTitle)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.TitleIs(expectedTitle));
        }

        public static bool waitUntilTitleIs(IWebDriver driver, string expectedTitle, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.TitleIs(expectedTitle), timeSpan);
        }

        public bool waitUntilTitleIs(string expectedTitle)
        {
            return WaitHelper.waitUntilTitleIs(driver, expectedTitle);
        }

        public bool waitUntilTitleIs(string expectedTitle, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilTitleIs(driver, expectedTitle, timeSpan);
        }
        #endregion

        #region TitleContains
        public static bool waitUntilTitleContains(IWebDriver driver, string expectedTitle)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.TitleContains(expectedTitle));
        }

        public static bool waitUntilTitleContains(IWebDriver driver, string expectedTitle, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.TitleContains(expectedTitle), timeSpan);
        }

        public bool waitUntilTitleContains(string expectedTitle)
        {
            return WaitHelper.waitUntilTitleContains(driver, expectedTitle);
        }

        public bool waitUntilTitleContains(string expectedTitle, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilTitleContains(driver, expectedTitle, timeSpan);
        }
        #endregion

        #region UrilContains
        public static bool waitUntilUrlContains(IWebDriver driver, string expectedUrl)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.UrlContains(expectedUrl));
        }

        public static bool waitUntilUrlContains(IWebDriver driver, string expectedUrl, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.UrlContains(expectedUrl), timeSpan);
        }

        public bool waitUntilUrlContains(string expectedUrl)
        {
            return WaitHelper.waitUntilUrlContains(driver, expectedUrl);
        }

        public bool waitUntilUrlContains(string expectedUrl, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilUrlContains(driver, expectedUrl, timeSpan);
        }
        #endregion

        #region UrlToBe
        public static bool waitUntilUrlToBe(IWebDriver driver, string expectedUrl)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.UrlToBe(expectedUrl));
        }

        public static bool waitUntilUrlToBe(IWebDriver driver, string expectedUrl, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.UrlToBe(expectedUrl), timeSpan);
        }

        public bool waitUntilUrlToBe(string expectedUrl)
        {
            return WaitHelper.waitUntilUrlToBe(driver, expectedUrl);
        }

        public bool waitUntilUrlToBe(string expectedUrl, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilUrlToBe(driver, expectedUrl, timeSpan);
        }
        #endregion

        #region ElementExists
        public static IWebElement waitUntilElementExists(IWebDriver driver, By bySelector)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.ElementExists(bySelector));
        }

        public static IWebElement waitUntilElementExists(IWebDriver driver, By bySelector, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.ElementExists(bySelector), timeSpan);
        }

        public IWebElement waitUntilElementExists(By bySelector)
        {
            return WaitHelper.waitUntilElementExists(driver, bySelector);
        }

        public IWebElement waitUntilElementExists(By bySelector, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilElementExists(driver, bySelector, timeSpan);
        }
        #endregion

        #region TextToBePresent
        public static bool waitUntilTextToBePresentInElementLocated(IWebDriver driver, By bySelector, string expectedText)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.TextToBePresentInElementLocated(bySelector, expectedText));
        }

        public static bool waitUntilTextToBePresentInElementLocated(IWebDriver driver, By bySelector, string expectedText, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.TextToBePresentInElementLocated(bySelector, expectedText), timeSpan);
        }

        public bool waitUntilTextToBePresentInElementLocated(By bySelector, string expectedText)
        {
            return WaitHelper.waitUntilTextToBePresentInElementLocated(driver, bySelector, expectedText);
        }

        public bool waitUntilTextToBePresentInElementLocated(By bySelector, string expectedText, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilTextToBePresentInElementLocated(driver, bySelector, expectedText, timeSpan);
        }
        #endregion

        #region ElementToBeClickable
        public static IWebElement waitUntilElementToBeClickable(IWebDriver driver, By bySelector)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.ElementToBeClickable(bySelector));
        }

        public static IWebElement waitUntilElementToBeClickable(IWebDriver driver, By bySelector, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.ElementToBeClickable(bySelector), timeSpan);
        }

        public IWebElement waitUntilElementToBeClickable(By bySelector)
        {
            return WaitHelper.waitUntilElementToBeClickable(driver, bySelector);
        }

        public IWebElement waitUntilElementToBeClickable(By bySelector, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilElementToBeClickable(driver, bySelector, timeSpan);
        }
        #endregion

        #region ElementToBeSelected
        public static bool waitUntilElementToBeSelected(IWebDriver driver, By bySelector)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.ElementToBeSelected(bySelector));
        }

        public static bool waitUntilElementToBeSelected(IWebDriver driver, By bySelector, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilWrapper(driver, ExpectedConditions.ElementToBeSelected(bySelector), timeSpan);
        }

        public bool waitUntilElementToBeSelected(By bySelector)
        {
            return WaitHelper.waitUntilElementToBeSelected(driver, bySelector);
        }

        public bool waitUntilElementToBeSelected(By bySelector, TimeSpan timeSpan)
        {
            return WaitHelper.waitUntilElementToBeSelected(driver, bySelector, timeSpan);
        }
        #endregion

    }
}
