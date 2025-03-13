using CommitQualityWebUIAutomation.Base;
using Docker.DotNet.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitQualityWebUIAutomation.PracticePageContainers
{
    public class DynamicTextContainer : PageBase
    {
        public DynamicTextContainer(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement AlwaysVisibleButton => Driver.FindElement(By.XPath("//button[@data-testid='dynamic-button1']"));
       
        public IWebElement TextChangedMessage => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Text changed']")));

        public void ClickAlwaysVisibleButton() => AlwaysVisibleButton.Click();
        public bool IsTextChangedMessageDisplayed() => TextChangedMessage.Displayed;
    }
}
