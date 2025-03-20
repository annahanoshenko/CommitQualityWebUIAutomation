using CommitQualityWebUIAutomation.Entities;
using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.Pages
{
    public class AddProductPage : MenuBar
    {
        public AddProductPage(IWebDriver driver) : base(driver)
        {
        }
        private IWebElement ProductNameTitle => Driver.FindElement(By.XPath("//input[@data-testid='product-textbox']"));
        private IWebElement ProductPrice => Driver.FindElement(By.Id("price"));
        private IWebElement DataStocked => Driver.FindElement(By.Id("dateStocked"));
        private IWebElement SubmitProductBtn => Driver.FindElement(By.XPath("//button[@data-testid='submit-form']"));
        private IWebElement CancleBtn => Driver.FindElement(By.XPath("//a[@data-testid='cancel-button']"));
        private IWebElement ProductNameErrorMessage => Driver.FindElement(By.XPath("//div[label[@for='name']]//div[@class='error-message']"));
        private IWebElement ProductPriceErrorMessage => Driver.FindElement(By.XPath("//div[label[@for='price']]//div[@class='error-message']"));
        private IWebElement DateStockedErrorMessage => Driver.FindElement(By.XPath("//div[label[@for='dateStocked']]//div[@class='error-message']"));
       
        public void EnterProductName(string productName) => ProductNameTitle.SendKeys(productName);
        public void EnterProductPrice(string productPrice) => ProductPrice.SendKeys(productPrice);
        public void EnterDateStocked(string dateStocked) => DataStocked.SendKeys(dateStocked);
        public void ClickSubmitBtn() => SubmitProductBtn.Click();
        public void ClickCancleBtn() => CancleBtn.Click();

        public string GetProductNameErrorMessage() => ProductNameErrorMessage.Text;
        public string GetProductPriceErrorMessage() => ProductPriceErrorMessage.Text;
        public string GetDateStockedErrorMessage() => DateStockedErrorMessage.Text;
        public string GetAllFiilingFieldsErrorMessage() => Driver.FindElement(By.XPath("//div[@data-testid='fillin-all-fields-validation']")).Text;
        public string GetErrorsMustBeResolvedBeforeSubmittingErrorMessage() => Driver.FindElement(By.XPath("//div[@data-testid='all-fields-validation']")).Text;

        public void FillingProductFields(ProductEntity product)
        {
            ClickAddProductsBtn();
            EnterProductName(product.ProductName);
            EnterProductPrice(product.ProductPrice);
            EnterDateStocked(product.DateStocked);
            ClickSubmitBtn();
        }
    }
}