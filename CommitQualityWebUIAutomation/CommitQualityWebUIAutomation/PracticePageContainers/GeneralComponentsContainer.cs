using CommitQualityWebUIAutomation.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CommitQualityWebUIAutomation.PracticePageContainers
{
    public class GeneralComponentsContainer : PageBase
    {
        public GeneralComponentsContainer(IWebDriver driver) : base(driver)
        {
        }
        IWebElement ClickMeButton => Driver.FindElement(By.XPath("//button[@data-testid='basic-click']"));
        public IWebElement ButtonClickedMessage => Driver.FindElement(By.XPath("//p[text()='Button clicked']"));
        public IWebElement DoubleButtonClickMeButton => Driver.FindElement(By.XPath("//button[@data-testid='double-click']"));
        public IWebElement ButtonDoubleClickedMessage => Driver.FindElement(By.XPath("//p[text()='Button double clicked']"));
        public IWebElement RightButtonClickMeButton => Driver.FindElement(By.XPath("//button[@data-testid='right-click']"));
        public IWebElement ButtonRightClickedMessage => Driver.FindElement(By.XPath("//p[text()='Button right mouse clicked']"));
        public IWebElement RadioButtonsContainerWebElement => Driver.FindElement(By.XPath("//div[contains(@class,'radio-buttons-container')]"));
        public RadioButtonsContainer RadioButtonsContainer => new RadioButtonsContainer(RadioButtonsContainerWebElement);
        public IWebElement OptionClickedMessage => Driver.FindElement(By.XPath("//div[contains(@class,'radio-buttons-container')]//p"));
        public IWebElement SelectOptionDropDown => Driver.FindElement(By.XPath("//div[@data-testid='dropdown']/select"));
        public IReadOnlyCollection<IWebElement> Checkboxes => Driver.FindElements(By.XPath("//input[@type='checkbox']"));


        public void ClickMeButtonClick() => ClickMeButton.Click();
        public void DoubleClickMeButtonClick()
        {
            Actions actions = new Actions(Driver);
            actions.DoubleClick(DoubleButtonClickMeButton).Perform();
        }
        public void RightClickMeButtonClick()
        {
            Actions actions = new Actions(Driver);
            actions.ContextClick(RightButtonClickMeButton).Perform();
        }

        public string GetButtonClickedMessage() => ButtonClickedMessage.Text;
        public string GetButtonDoubleClickedMessage() => ButtonDoubleClickedMessage.Text;
        public string GetButtonRightClickedMessage() => ButtonRightClickedMessage.Text;

        public string GetOptionClickedMessage() => OptionClickedMessage.Text;
       
        public void SelectOptionDropDownCkick() => SelectOptionDropDown.Click();
        public RadioButtonsContainer GetRadioButtonsContainer()
        {
            var radioGroupElement = Driver.FindElement(By.XPath("//div[@data-testid='radio-group']"));
            return new RadioButtonsContainer(radioGroupElement);
        }
        public void SelectRadioButtonOption(string optionName)
        {
            RadioButtonsContainer.SelectByName(optionName);
        }

        public void SelectFromDropDown(string value)
        {
            SelectElement option = new SelectElement(SelectOptionDropDown);
            option.SelectByText(value);
        }

        public string GetSelectedDropDownOption()
        {
            SelectElement select = new SelectElement(SelectOptionDropDown);
            return select.SelectedOption.Text;
        }

        public void ClickAllCheckboxes()
        {
            foreach (var checkbox in Checkboxes)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
            }
        }

        public void UncheckCheckboxes(int count)
        {
            for (int i = 0; i < count && i < Checkboxes.Count; i++)
            {
                if (Checkboxes.ElementAt(i).Selected)
                {
                    Checkboxes.ElementAt(i).Click();
                }
            }
        }

        public bool AreAllCheckboxesSelected()
        {
            return Checkboxes.All(checkbox => checkbox.Selected);
        }

        public bool IsCheckboxSelected(int index)
        {
            return Checkboxes.ElementAt(index).Selected;
        }
    }
}     

