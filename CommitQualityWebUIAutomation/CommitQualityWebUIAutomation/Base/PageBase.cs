using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
