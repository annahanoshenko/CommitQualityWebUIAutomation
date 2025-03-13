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
    public class FileUploadContainer : PageBase
    {
        public FileUploadContainer(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ChooseFileBtn => Driver.FindElement(By.XPath("//input[@id = 'file-input']"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//input[@data-testid='file-upload']"));
        public IWebElement FileUploadMessage => wait.Until(ExpectedConditions.ElementExists(By.XPath("//p[@data-testid='file-upload-message']")));

        public void UploadFile(string filePath)
        {
            FileUploadButton.SendKeys(filePath);
        }

        public string GetFileUploadMessage() => FileUploadMessage.Text;
    }
}
