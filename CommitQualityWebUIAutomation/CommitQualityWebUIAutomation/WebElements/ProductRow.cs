using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.WebElements
{
    public class ProductRow
    {
        public IWebDriver Driver;

        public IWebElement ProductRowElement { get; set; }
        public IWebElement ProductName => ProductRowElement.FindElement(By.XPath(".//td[@data-testid ='name']"));
        public IWebElement EditProductBtn => ProductRowElement.FindElement(By.XPath(".//a[@data-testid='edit-button']"));
        public IWebElement ProductPrice => ProductRowElement.FindElement(By.XPath(".//td[@data-testid='price']"));
        public IWebElement ProductDateStocked => ProductRowElement.FindElement(By.XPath(".//td[@data-testid='dateStocked']"));
        public IWebElement DeleteProductBtn => ProductRowElement.FindElement(By.XPath(".//a[@data-testid='delete-button']"));

        public ProductRow(IWebDriver driver, IWebElement productRow)
        {
            this.Driver = driver;
            this.ProductRowElement = productRow;
        }

        public ProductRow(IWebElement productRow)
        {
            this.ProductRowElement = productRow;
        }

        public ProductRow(IWebDriver driver)
        {
            Driver = driver;
        }

        private ProductRow GetProductRow(string productName)
        {
            var productRowElement = Driver.FindElements(By.XPath($"//td[contains(text(), '{productName}')]")).FirstOrDefault();
            if (productRowElement == null)
            {
                throw new Exception($"No product row found for product: {productName}");
            }
            return new ProductRow(productRowElement);
        }
        public void ClickEditProductBtn() => EditProductBtn.Click();
        public void ClickDeleteProductBtn() => DeleteProductBtn.Click();
        public string GetProductName() => ProductName.Text;
        public string GetProductPrice() => ProductPrice.Text;
        public string GetProductDateStocked () => ProductDateStocked.Text;

    }
}
