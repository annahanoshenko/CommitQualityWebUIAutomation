using CommitQualityWebUIAutomation.PracticePageContainers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CommitQualityWebUIAutomation.Base
{
    public class TestBase
    {
        public IWebDriver Driver;
      

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://commitquality.com/");
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();

        }
    }
}
