using CommitQualityWebUIAutomation.Base;
using Docker.DotNet.Models;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace CommitQualityWebUIAutomation.PracticePageContainers
{
    public class DynamicTextContainer : PageBase
    {
        public DynamicTextContainer(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement DynamicTextButton => wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[@data-testid='dynamic-button1']")));
       
       

        public void ClickDynamicTextButton() => DynamicTextButton.Click();
        public string GetDynamicButtonText() => DynamicTextButton.Text;
        public bool IsDynamicButtonTextChanged() => wait.Until(ExpectedConditions.TextToBePresentInElement(DynamicTextButton, "I am visible after 5 seconds"));
    }
}
