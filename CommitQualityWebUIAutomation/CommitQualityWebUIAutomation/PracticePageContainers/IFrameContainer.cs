using CommitQualityWebUIAutomation.Base;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitQualityWebUIAutomation.PracticePageContainers
{
    public class IFrameContainer : PageBase
    {
        public IFrameContainer(IWebDriver driver) : base(driver)
        {
        }

       private IWebElement IFrame => wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='component-container']")));
       private IWebElement PracticeBtnInsideIframe => Driver.FindElement(By.XPath("//div/a[@data-testid='navbar-practice']"));
       private IWebElement GeneralComponentsContainerInsideIframe => Driver.FindElement(By.XPath("//div[@data-testid='practice-general']"));
       private IWebElement ClickMeButtonInsideIframe => Driver.FindElement(By.XPath("//button[@data-testid='basic-click']"));
        private IWebElement ButtonClickedMessage => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Button clicked']")));

        public void SwitchToIFrame()
        {
            Driver.SwitchTo().Frame(IFrame);
        }

        public void ClickPracticeBtnInsideIframe() => PracticeBtnInsideIframe.Click();
        public void ClickGeneralComponentsContainerInsideIframe() => GeneralComponentsContainerInsideIframe.Click();
        public void ClickClickMeButtonInsideIframe() => ClickMeButtonInsideIframe.Click();
        public bool IsButtonClickedMessageDisplayed() => ButtonClickedMessage.Displayed;
        public void SwitchToDefaultContetnt() => Driver.SwitchTo().DefaultContent();


    }
}
