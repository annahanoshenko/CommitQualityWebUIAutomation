using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.WebElements
{
    public class ProductRow
    {
        public IWebElement productRow;
        public IWebElement ProductName => productRow.FindElement(By.XPath("//td[@data-testid ='name']"));
        public IWebElement EditProductBtn => productRow.FindElement(By.XPath("//a[@data-testid='edit-button']"));
        public IWebElement DeleteProductBtn => productRow.FindElement(By.XPath("//a[@data-testid='delete-button']"));

        public ProductRow(IWebElement productRow)
        {
            this.productRow = productRow;
        }
    }
}
