using CommitQualityWebUIAutomation.Entities;
using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.Pages
{
    public class LoginPage : MenuBar
    {
        private IWebElement UsernameTxtField => Driver.FindElement(By.XPath("//input[@data-testid='username-textbox']"));
        private IWebElement PasswordTxtField => Driver.FindElement(By.XPath("//input[@data-testid='password-textbox']"));
        private IWebElement LoginPopUpBtn => Driver.FindElement(By.XPath("//button[@data-testid='login-button']"));

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterUsername(string username) => UsernameTxtField.SendKeys(username);
        public void EnerPassword(string password) => PasswordTxtField.SendKeys(password);
        public void ClickLoginPopUpBtn() => LoginPopUpBtn.Click();

        public void LoginUser(UserEntity user)
        {
            EnterUsername(user.Username);
            EnerPassword(user.Password);
            ClickLoginPopUpBtn();
        }
    }
}
