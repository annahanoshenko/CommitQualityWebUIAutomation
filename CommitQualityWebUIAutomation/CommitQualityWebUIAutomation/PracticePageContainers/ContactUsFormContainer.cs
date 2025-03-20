using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace CommitQualityWebUIAutomation.PracticePageContainers
{
    public class ContactUsFormContainer : PageBase
    {
        public ContactUsFormContainer(IWebDriver driver) : base(driver)
        {
        }
        private IWebElement NameField => Driver.FindElement(By.XPath("//input[@id='name']"));
        private IWebElement NameFieldErrorMsg => Driver.FindElement(By.XPath("//div[@class='error']"));
        private IWebElement EmailField => Driver.FindElement(By.XPath("//input[@id='email']"));
        private IWebElement EmailFieldErrorMsg => Driver.FindElement(By.XPath("//div[@class='error']"));
        private IWebElement QueryTypeDropdown => Driver.FindElement(By.XPath("//select[@id='query-type']"));
        private IWebElement QueryTypeDropdownErrorMsg => Driver.FindElement(By.XPath("//div[@class='error']"));
        private IWebElement DateOfBirthField => Driver.FindElement(By.XPath("//input[@type='date']"));
        private IWebElement DateOfBirthErrorMsg => Driver.FindElement(By.XPath("//div[@class='error']"));
        private IWebElement AgreeCheckBox => Driver.FindElement(By.XPath("//input[@type='checkbox']"));
        private IWebElement AgreeCheckBoxErrorMsg => Driver.FindElement(By.XPath("//label[input[@type='checkbox']]//following-sibling::div[@class='error']"));
        private IWebElement SubmitBtn => Driver.FindElement(By.XPath("//button[@type='submit']"));

        public void EnterName(string name) => NameField.SendKeys(name);
        public void EnterEmail(string email) => EmailField.SendKeys(email);
        public void SelectQueryType(string queryType)
        {
            SelectElement option = new SelectElement(QueryTypeDropdown);
            option.SelectByText(queryType);
        }
        public string GetSelectQueryType()
        {
            SelectElement select = new SelectElement(QueryTypeDropdown);
            return select.SelectedOption.Text;
        }
        public void EnterDateOfBirth(string dateOfBirth) => DateOfBirthField.SendKeys(dateOfBirth);
        public void ClickAgreeCheckBox() => AgreeCheckBox.Click();
        public void ClickSubmitBtn() => SubmitBtn.Click();

        public void FillingContuctUsFieldsAndCheckbox(ContactUsFormUserEntity contactUsFormUser)
        {
            EnterName(contactUsFormUser.Name);
            EnterEmail(contactUsFormUser.Email);
            SelectQueryType(contactUsFormUser.QueryType);
            EnterDateOfBirth(contactUsFormUser.DateOfBirth);
            ClickAgreeCheckBox();
            ClickSubmitBtn();
        }
        public void FillingContuctUsFields(ContactUsFormUserEntity contactUsFormUser)
        {
            EnterName(contactUsFormUser.Name);
            EnterEmail(contactUsFormUser.Email);
            SelectQueryType(contactUsFormUser.QueryType);
            EnterDateOfBirth(contactUsFormUser.DateOfBirth);
            ClickSubmitBtn();

        }

        public string GetNameErrorMessage() => NameFieldErrorMsg.Text;
        public string GetEmailErrorMessage() => EmailFieldErrorMsg.Text;
        public string GeQueryTypeDropdownErrorMessage() => QueryTypeDropdownErrorMsg.Text;
        public string GetQDateOfBirthErrorMessage() => DateOfBirthErrorMsg.Text;
        public string GetAgreeCheckBoxErrorMessage() => AgreeCheckBoxErrorMsg.Text;

        public string GetSuccessMessageText()
        {
            IWebElement successMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='success-message']")));
            return successMessage.Text;
        }
    }
}
