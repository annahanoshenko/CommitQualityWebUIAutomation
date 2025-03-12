using CommitQualityWebUIAutomation.Base;
using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.Pages
{
    public class PracticePage : MenuBar
    {
        IWebElement GeneralComponentsContainer => Driver.FindElement(By.XPath("//div[@data-testid='practice-general']"));
        IWebElement AccordionsContainer => Driver.FindElement(By.XPath("//div[@data-testid='practice-accordions']"));
        IWebElement PopupsContainer => Driver.FindElement(By.XPath("//div[@data-testid='practice-random-overlay']"));
        IWebElement IframesContainer => Driver.FindElement(By.XPath("//div[@data-testid='practice-iframe']"));
        IWebElement ApisContainer => Driver.FindElement(By.XPath("//div[@data-testid='practice-api']"));
        IWebElement DynamicTextContainer => Driver.FindElement(By.XPath("//div[@data-testid='practice-dynamic-text']"));
        IWebElement FileUploadContainer => Driver.FindElement(By.XPath("//div[@data-testid='practice-file-upload']"));
        IWebElement DragAndDropContainer => Driver.FindElement(By.XPath("//div[@data-testid='practice-drag-drop']"));
        IWebElement ContactUsFormContainer => Driver.FindElement(By.XPath("//div[@data-testid='practice-contact-form']"));
        IWebElement MockDatalayerContainer => Driver.FindElement(By.XPath("//div[@data-testid='practice-mock-data-layer']"));
        IWebElement FileDownloadContainer => Driver.FindElement(By.XPath("//div[@data-testid='practice-file-download']"));
        IWebElement TimeTestingContainer => Driver.FindElement(By.XPath("//div[@data-testid='practice-clock']"));

        public PracticePage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickGeneralComponents() => GeneralComponentsContainer.Click();
        public void ClickAccordions() => AccordionsContainer.Click();
        public void ClickPopups() => PopupsContainer.Click();  
        public void ClickIframes() => IframesContainer.Click();  
        public void ClickApis() => ApisContainer.Click();  
        public void ClickDynamicText() => DynamicTextContainer.Click();

        public void ClickFileUpload() => FileUploadContainer.Click();
        public void ClickDragAndDrop() => DragAndDropContainer.Click();
        public void ClickContactUsForm() => ContactUsFormContainer.Click();
        public void ClickMockDatalayer() => MockDatalayerContainer.Click();
        public void ClickFileDownload() => FileDownloadContainer.Click();
        public void ClickTimeTesting() => TimeTestingContainer.Click();

    }
}
