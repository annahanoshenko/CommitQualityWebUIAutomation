using CommitQualityWebUIAutomation.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
        public IWebElement ButtonRightClickedMessage => Driver.FindElement(By.XPath("//[text()='Button right mouse clicked']"));
        public IWebElement RadioButton => Driver.FindElement(By.XPath("//input[@data-testid='option1']"));
        public IWebElement Option1ClickedMessage => Driver.FindElement(By.XPath("//p[text()='option1']"));
        public IWebElement RadioButton2 => Driver.FindElement(By.XPath("//input[@data-testid='option2']"));
        public IWebElement Option2ClickedMessage => Driver.FindElement(By.XPath("//p[text()='option2']"));
        public IWebElement SelectOptionDropDown => Driver.FindElement(By.XPath("//div[@data-testid='dropdown']/select"));

      //  public IWebElement SelectOption1DropDown => Driver.FindElement(By.XPath("//div[@data-testid='dropdown']/select"));
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

        public void RadioButtonClick() => RadioButton.Click();
        public void RadioButton2Click() => RadioButton2.Click();
        public string GetOption1ClickedMessage() => Option1ClickedMessage.Text;
        public string GetOption2ClickedMessage() => Option2ClickedMessage.Text;

        public void SelectOptionDropDownCkick() => SelectOptionDropDown.Click();

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

        public void ClickCheckBox(int index)
        {
            if (index >= 0 && index < Checkboxes.Count)
            {
                Checkboxes.ElementAt(index).Click();
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");
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


        public string GetButtonRightClickedMessageWait()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            IWebElement message = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Button right mouse clicked']")));
            return message.Text;
        }

    }
}     

