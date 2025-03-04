using CommitQualityWebUIAutomation.Entities;
using CommitQualityWebUIAutomation.WebElements;
using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.Pages
{
    public class EditProductPage : ProductRow
    {
        public EditProductPage(IWebDriver driver, IWebElement productRow) : base(productRow)
        {
            this.Driver = driver;
        }

        private IWebElement ProductNameTitleField => Driver.FindElement(By.XPath("//input[@data-testid='product-textbox']"));
        private IWebElement PriceField => Driver.FindElement(By.XPath("//input[@data-testid='price-textbox']"));
        private IWebElement DataStockedField => Driver.FindElement(By.XPath("//input[@data-testid='date-stocked']"));
        private IWebElement UpdateBtn => Driver.FindElement(By.XPath("//button[@data-testid='submit-form']"));
        private IWebElement CancelBtn => Driver.FindElement(By.XPath("//a[@data-testid='cancel-button']"));

        public void EditProductName(string productName) => ProductNameTitleField.SendKeys(productName);
        public void EditPriceField(string price) => PriceField.SendKeys(price);
        public void EditDataStockedField(string dateStocked) => DataStockedField.SendKeys(dateStocked);
        public void ClickUpdateBtn() => UpdateBtn.Click();
        public void ClickCancelBtn() => CancelBtn.Click();

        public void FillingProductFields(ProductEntity product)
        {
            EditProductName(product.ProductName);
            EditPriceField(product.ProductPrice);
            EditDataStockedField(product.DateStocked);
            ClickUpdateBtn();
        }
    }
}
