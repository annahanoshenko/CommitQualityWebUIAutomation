using CommitQualityWebUIAutomation.Base;
using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.Pages
{
    public class MenuBar : PageBase
    {
        private IWebElement LoginBtn => Driver.FindElement(By.XPath("//a[@data-testid='navbar-login']"));
        private IWebElement LogoutBtn => Driver.FindElement(By.XPath("//a[@data-testid='navbar-logout']"));
        private IWebElement ProductsBtn => Driver.FindElement(By.XPath("//a[@data-testid='navbar-products']"));
        private IWebElement AddProductsBtn => Driver.FindElement(By.XPath("//a[@data-testid='navbar-addproduct']"));

        public MenuBar(IWebDriver driver) : base(driver)
        {
        }

        public void ClickLoginBtn() => LoginBtn.Click();
        public void ClickLogoutBtn() => LogoutBtn.Click();
        public void ClickProductsBtn() => ProductsBtn.Click();
        public void ClickAddProductsBtn() => AddProductsBtn.Click();
    }
}
