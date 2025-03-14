using CommitQualityWebUIAutomation.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace CommitQualityWebUIAutomation.PracticePageContainers
{
    public class DragAndDropContainer : PageBase
    {
        public DragAndDropContainer(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement DraggableElement => Driver.FindElement(By.XPath("//div[@id ='small-box']"));
        private IWebElement DropBox => Driver.FindElement(By.XPath("//div[@data-testid ='large-box']"));
        private IWebElement DropBoxMessage => Driver.FindElement(By.XPath("//div[text()='Success!']"));

        public void PerformDragAndDrop()
        {
            Actions action = new Actions(Driver);
            action.DragAndDrop(DraggableElement, DropBox).Perform();
        }
        public bool IsDropSuccessful() => DropBoxMessage.Displayed;
    }
}
