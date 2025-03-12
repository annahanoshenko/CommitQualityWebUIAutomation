using CommitQualityWebUIAutomation.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitQualityWebUIAutomation.PracticePageContainers
{
    public class AccordionsContainer : PageBase
    {
        IWebElement Accordion1 => Driver.FindElement(By.XPath("//button[@data-testid='accordion-1']"));
        IWebElement Accordion2 => Driver.FindElement(By.XPath("//button[@data-testid='accordion-1']"));
        IWebElement Accordion3 => Driver.FindElement(By.XPath("//button[@data-testid='accordion-1']"));
        IWebElement ClickMeButton => Driver.FindElement(By.XPath("//button[@data-testid='basic-click']"));
        IWebElement DoubleClickMeButton => Driver.FindElement(By.XPath("//button[@data-testid='double-click']"));
        IWebElement RightClickMeButton => Driver.FindElement(By.XPath("//button[@data-testid='right-click']"));
        IWebElement RadioButton => Driver.FindElement(By.XPath("//input[@data-testid='option1']"));
        IWebElement RadioButton2 => Driver.FindElement(By.XPath("//input[@data-testid='option2']"));
        IWebElement CheckBox => Driver.FindElement(By.XPath("//div[@data-testid='practice-file-upload']"));
        public AccordionsContainer(IWebDriver driver) : base(driver)
        {
        }
        public void ClickAccordion1() => Accordion1.Click();
        public void ClickMeButtonClick() => ClickMeButton.Click();
        public void DoubleClickMeButtonClick() => DoubleClickMeButton.Click();
        public void RightClickMeButtonClick() => RightClickMeButton.Click();
        public void ClickAccordion2() => Accordion2.Click();
        public void RadioButtonClick() => RadioButton.Click();
        public void ClickAccordion3() => Accordion3.Click();
        public void ClickCheckBox() => CheckBox.Click();

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

    }
}
