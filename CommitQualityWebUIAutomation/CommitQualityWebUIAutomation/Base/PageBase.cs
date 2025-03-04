using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace CommitQualityWebUIAutomation.Base
{
    public class PageBase
    {
        public IWebDriver Driver;
        protected WebDriverWait wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        public PageBase(IWebDriver driver)
        {
            Driver = driver;
        }
        public IAlert GetAlertWithWait()
        {
            IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            return alert;
        }
        public string GetAlertTextWithWait()
        {
            IAlert alert = GetAlertWithWait();
            return alert.Text;
        }

        public void AcceptAlertWithWait()
        {
            IAlert alert = GetAlertWithWait();
            alert.Accept();
        }

        public bool ContainsClass(IWebElement webElement, string className)
        {
            return webElement.GetAttribute("class").Contains(className);
        }
    }
}
