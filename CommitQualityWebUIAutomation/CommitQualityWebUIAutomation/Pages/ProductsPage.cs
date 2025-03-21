using CommitQualityWebUIAutomation.WebElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CommitQualityWebUIAutomation.Pages
{
    public class ProductsPage(IWebDriver driver) : MenuBar(driver)
    {
        private IWebElement FilterBtn => Driver.FindElement(By.XPath("//button[@data-testid='filter-button']"));
        private IWebElement ResetBtn => Driver.FindElement(By.XPath("//button[@data-testid='reset-filter-button']"));
        private IWebElement FilterByProductNameTextField => Driver.FindElement(By.XPath("//input[@class='filter-textbox']"));
        private IWebElement[] TableProductRows => Driver.FindElements(By.XPath("//tr[contains(@data-testid,'product-row')]")).ToArray();

        public ProductRow[] ProductRows => TableProductRows.Select(p => new ProductRow(p)).ToArray();
        public void ClickFilterBtn() => FilterBtn.Click();
        public void ClickResetBtn() => ResetBtn.Click();
        public void EnterProductName(string productName) => FilterByProductNameTextField.SendKeys(productName);

        public string GetFilteringErrorMessage() => Driver.FindElement(By.XPath("//p[@class='add-product-message']")).Text;

        public ProductRow GetProductRow(string productName)
        {
            ProductRow productRow = ProductRows.Single(p => p.ProductName.Text == productName);
            return productRow;
        }

        public bool IsProductisVisible(string productName)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                return wait.Until(d =>
                    d.FindElement(By.XPath($"//td[@data-testid='name' and text()='{productName}']")).Displayed);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool AreFilteredProductsOnly(string productName)
        {
            foreach (var row in ProductRows)
            {
                string productNameInRow = row.GetProductName();
                if (!productNameInRow.Contains(productName))
                {
                    return false;
                }
            }
                return true;
        }
        public string GetProductNameFieldText()
        {
            var productNameField = Driver.FindElement(By.XPath("//input[@placeholder='Filter by product name']"));
            return productNameField.GetAttribute("value");
        }

        public bool AreAllProductsVisible()
        {
            var productRows = Driver.FindElements(By.XPath("//tr[contains(@data-testid,'product-row')]"));
            return productRows.Count > 0;
        }

        public void EditProduct(string productName)
        {
            ProductRow productRow = GetProductRow(productName);
            productRow.ClickEditProductBtn();
        }
        public void DeleteProduct(string productName)
        {
            ProductRow productRow = GetProductRow(productName);
            productRow.ClickDeleteProductBtn();
        }
    }
}
