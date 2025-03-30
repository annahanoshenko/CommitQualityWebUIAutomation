using CommitQualityWebUIAutomation.Singleton;
using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.Base
{
    public class TestBase
    {
        protected IWebDriver Driver;
      
        [SetUp]
        public void Setup()
        {
            Driver = DriverHolder.Driver;
            Driver.Navigate().GoToUrl("https://commitquality.com/");
        }

        [TearDown]
        public void TearDown()
        {
            DriverHolder.QuitDriver();
        }
    }
}
