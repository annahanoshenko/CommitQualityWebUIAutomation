using CommitQualityWebUIAutomation.Base;
using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.PracticePageContainers
{
    public class FileUploadContainer : PageBase
    {
        public FileUploadContainer(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement FileInput => Driver.FindElement(By.XPath("//input[@id ='file-input']"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//button[@type='submit']"));
       
        public void UploadFile(string filePath)
        {
            FileInput.SendKeys(filePath);
        }
        public void ClickSubmitButton() => SubmitButton.Click();
    }
}
