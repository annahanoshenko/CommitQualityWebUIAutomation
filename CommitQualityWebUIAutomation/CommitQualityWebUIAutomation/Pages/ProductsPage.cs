using CommitQualityWebUIAutomation.WebElements;
using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.Pages
{
    public class ProductsPage : MenuBar
    {
        IWebElement FilterBtn => Driver.FindElement(By.XPath("//button[@data-testid='filter-button']"));
        IWebElement ResetBtn => Driver.FindElement(By.XPath("//button[@data-testid='reset-filter-button']"));
        IWebElement FilterByProductNameTextField => Driver.FindElement(By.XPath("//input[@class='filter-textbox']"));
        IWebElement[] TableProductRows => Driver.FindElements(By.XPath("//tr[contains(@data-testid,'product-row')]")).ToArray();

        //public ProductRow[] GetProductRows()
        //{
        //    ProductRow[] productRows = new ProductRow[ProductRows.Length];
        //    for (int i = 0; i < productRows.Length; i++)
        //    {
        //        productRows[i] = new ProductRow(ProductRows[i]);
        //    }
        //    return productRows;
        //}
        public ProductRow[] ProductRows => TableProductRows.Select(p => new ProductRow(p)).ToArray();
        public ProductsPage(IWebDriver driver) : base(driver)
        {
        }

        public ProductRow GetProductRow(string productName)
        {
            ProductRow productRow = ProductRows.Single(p => p.ProductName.Text == productName);
            return productRow;
        }


        public void ClickFilterBtn() => FilterBtn.Click();
        public void ClickResetBtn() => ResetBtn.Click();
        public void EnterProductName(string productName) => FilterByProductNameTextField.SendKeys(productName);
       
    }
}
