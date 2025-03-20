using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.PracticePageContainers
{
    public class RadioButtonsContainer
    {
        private readonly IWebElement _parentContainer;

        public RadioButtonsContainer(IWebElement container)
        {
            _parentContainer = container;
        }
        public void SelectByName(string optionName)
        {
            IReadOnlyCollection<IWebElement> radioButtons = _parentContainer.FindElements(By.XPath("//input[@type='radio']"));
            var targetRadio = radioButtons.FirstOrDefault(rb => rb.GetAttribute("value") == optionName);
           if (targetRadio != null)
            {
                targetRadio.Click();
            }
           else 
            {
                throw new NoSuchElementException($"Radio button with value {optionName} not found");
            }
        }
    }
}
