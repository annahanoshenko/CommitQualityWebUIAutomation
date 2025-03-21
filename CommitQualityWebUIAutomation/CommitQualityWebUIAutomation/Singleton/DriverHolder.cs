using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CommitQualityWebUIAutomation.Singleton
{
    public class DriverHolder
    {
        private static IWebDriver? _driver;

        private DriverHolder() { }
        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {

                    _driver = new ChromeDriver();
                    _driver.Manage().Window.Maximize();
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                }
                return _driver;
            }
        }
        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}
