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

        public IWebElement IFrame => wait.Until(ExpectedConditions.ElementExists(By.XPath("//iframe[@data-testid='iframe']")));
        public IWebElement PracticeBtnInsideIframe => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div/a[@data-testid='navbar-practice']")));
        public IWebElement GeneralComponentsContainerInsideIframe => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@data-testid='practice-general']")));
        public IWebElement ClickMeButtonInsideIframe => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@data-testid='basic-click']")));
        public IWebElement ButtonClickedMessage => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Button clicked']")));

        public void SwitchToIFrame()
        {
            Driver.SwitchTo().Frame(IFrame);
        }

        public void ClickPracticeBtnInsideIframe() => PracticeBtnInsideIframe.Click();
        public void ClickGeneralComponentsContainerInsideIframe() => GeneralComponentsContainerInsideIframe.Click();
        public void ClickClickMeButtonInsideIframe() => ClickMeButtonInsideIframe.Click();
        public bool IsButtonClickedMessageDisplayed() => ButtonClickedMessage.Displayed;
        public void SwitchToDefaultContent() => Driver.SwitchTo().DefaultContent();

    }
}
