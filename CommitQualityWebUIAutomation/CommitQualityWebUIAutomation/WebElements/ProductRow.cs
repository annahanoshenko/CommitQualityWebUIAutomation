using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.WebElements
{
    public class ProductRow
    {
        public IWebDriver Driver;

        public ProductRow(IWebElement productRow)
        {
            this.ProductRowElement = productRow;
        }

        public ProductRow(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement ProductRowElement { get; set; }
        public IWebElement ProductName => ProductRowElement.FindElement(By.XPath(".//td[@data-testid ='name']"));
        public IWebElement EditProductBtn => ProductRowElement.FindElement(By.XPath(".//a[@data-testid='edit-button']"));
        public IWebElement ProductPrice => ProductRowElement.FindElement(By.XPath(".//td[@data-testid='price']"));
        public IWebElement ProductDateStocked => ProductRowElement.FindElement(By.XPath(".//td[@data-testid='dateStocked']"));
        public IWebElement DeleteProductBtn => ProductRowElement.FindElement(By.XPath(".//a[@data-testid='delete-button']"));

        public void ClickEditProductBtn() => EditProductBtn.Click();
        public void ClickDeleteProductBtn() => DeleteProductBtn.Click();
        public string GetProductName() => ProductName.Text;
        public string GetProductPrice() => ProductPrice.Text;
        public string GetProductDateStocked () => ProductDateStocked.Text;
    }
}
