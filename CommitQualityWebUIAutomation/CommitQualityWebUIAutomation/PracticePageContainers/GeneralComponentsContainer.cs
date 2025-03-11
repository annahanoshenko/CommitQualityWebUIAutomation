using CommitQualityWebUIAutomation.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CommitQualityWebUIAutomation.PracticePageContainers
{
    public class GeneralComponentsContainer : TestBase
    {
        IWebElement ClickMeButton => Driver.FindElement(By.XPath("//button[@data-testid='basic-click']"));
        public IWebElement ButtonClickedMessage => Driver.FindElement(By.XPath("//button[text()='Click me']"));
       public IWebElement DoubleButtonClickMeButton => Driver.FindElement(By.XPath("//button[@data-testid='double-click']"));
        public IWebElement ButtonDoubleClickedMessage => Driver.FindElement(By.XPath("//button[text()='Button double clicked']"));
        public IWebElement RightButtonClickMeButton => Driver.FindElement(By.XPath("//button[@data-testid='right-click']"));
        public IWebElement ButtonRightClickedMessage => Driver.FindElement(By.XPath("//button[text()='Button right mouse clicked']"));
       IWebElement RadioButton => Driver.FindElement(By.XPath("//input[@data-testid='option1']"));
        IWebElement Option1ClickedMessage => Driver.FindElement(By.XPath("//div[@class='component-container']/p[text()='option1 clicked']"));
        IWebElement RadioButton2 => Driver.FindElement(By.XPath("//input[@data-testid='option2']"));
        IWebElement Option2ClickedMessage => Driver.FindElement(By.XPath("///div[@class='component-container']/p[text()='option2 clicked']"));
        IWebElement SelectOptionDropDown => Driver.FindElement(By.XPath("//div[@data-testid='dropdown']"));
        IWebElement CheckBox => Driver.FindElement(By.XPath("//div[@data-testid='practice-file-upload']"));
        
        public GeneralComponentsContainer(IWebDriver driver) : base(driver)
        {
        }

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
        public void RadioButtonClick() => RadioButton.Click();
        public void SelectOptionDropDownCkick() => SelectOptionDropDown.Click();
        public void ClickCheckBox() => CheckBox.Click();

        public string GetButtonClickedMessage() => ButtonClickedMessage.Text;
        public string GetButtonDoubleClickedMessage() => ButtonDoubleClickedMessage.Text;
        public string GetButtonRightClickedMessage() => ButtonRightClickedMessage.Text;

       
        public void SelectFromDropDown(string value)
        {
            SelectElement select = new SelectElement(SelectOptionDropDown);
            select.SelectByValue(value);
        }

            public void Check()
        {
            if (!CheckBox.Selected)  
            {
                CheckBox.Click();
            }
        }

        public void Uncheck()
        {
            if (CheckBox.Selected)  
            {
                CheckBox.Click();
            }
        }

        public bool IsChecked()
        {
            return CheckBox.Selected;
        }

        public string GetButtonRightClickedMessageWait()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            IWebElement message = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Button right mouse clicked']")));
            return message.Text;
        }
    }

}
