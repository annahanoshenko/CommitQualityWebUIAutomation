using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.Pages
{
    public class AddProductPage : MenuBar
    {
        private IWebElement ProductNameTitle => Driver.FindElement(By.XPath("//input[@data-testid='product-textbox']"));
        private IWebElement ProductPrice => Driver.FindElement(By.Id("price"));
        private IWebElement DataStocked => Driver.FindElement(By.Id("dateStocked"));
        private IWebElement SubmitProductBtn => Driver.FindElement(By.XPath("//button[@data-testid='submit-form']"));
        private IWebElement CancleBtn => Driver.FindElement(By.XPath("//a[@data-testid='cancel-button']"));

        public AddProductPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterProductName(string productName) => ProductNameTitle.SendKeys(productName);
        public void EnterProductPrice(string productPrice) => ProductPrice.SendKeys(productPrice);
        public void EnterDateStocked(string dateStocked) => DataStocked.SendKeys(dateStocked);
        public void ClickAddProductBtn() => SubmitProductBtn.Click();
        public void ClickCancleBtn() => CancleBtn.Click();
    }
}
