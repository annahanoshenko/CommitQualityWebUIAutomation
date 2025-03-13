using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Extentions;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace CommitQualityWebUIAutomation.PracticePageContainers
{
    public class PopupContainer : PageBase
    {
        public PopupContainer(IWebDriver driver) : base(driver)
        {
        }

        IWebElement closeButton => Driver.FindElement(By.XPath("//button[text()='Close']"));

        public void WaitForPopup()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='overlay-content']")));
        }
        public void ClickCloseBtn() => closeButton.Click();
        public bool IsPopupDisplayed()
        {
            try
            {
                return closeButton.Exists();
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }
        
    }
}
