using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Entities;
using CommitQualityWebUIAutomation.Pages;
using CommitQualityWebUIAutomation.WebElements;

namespace CommitQualityWebUIAutomation.AutoTests
{
    [TestFixture]
    public class Tests : TestBase
    {

        [Test]
        public void ShouldLoginExistingUser_WhenDataIsValid()
        {
            UserEntity user = new UserEntity("test", "test");

            LoginPage loginPage = new LoginPage(Driver);
            ProductsPage productsPage = new ProductsPage(Driver);

            loginPage.LoginUser(user);

           bool isLogoutBtnVisible = loginPage.IsLogoutBtnVisible();
           Assert.IsTrue(isLogoutBtnVisible, "Logout button should be displayed after a successful login.");

        }

        [Test]
        public void LoginShouldFail_WhenUsernameAndPasswordFieldsAreEmpty()
        {
            UserEntity user = new UserEntity("", "");

            LoginPage loginPage = new LoginPage(Driver);
            ProductsPage productsPage = new ProductsPage(Driver);

            loginPage.LoginUser(user);

            string actualErrorMessage = loginPage.GetLoginErrorMessage();
            string expectedErrorMessage = "Please enter a username and password";

            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));
        }

        [Test]
        public void User_CanLogoutSuccessfully()
        {
            UserEntity user = new UserEntity("test", "test");
            ProductsPage productsPage = new ProductsPage(Driver);
            LoginPage loginPage = new LoginPage(Driver);
            
            loginPage.LoginUser(user);

            productsPage.ClickLogoutBtn();
            bool isLoginBtnVisible = productsPage.IsLoginBtnVisible();
            Assert.IsTrue(isLoginBtnVisible, "Logout button should be displayed after a successful login.");
        }

        [Test]
        public void ShouldAddProduct_WhenDataIsValid()
        {
            MenuBar menuBar = new MenuBar(Driver);
            ProductRow productRow = new ProductRow(Driver);
            AddProductPage addProductPage = new AddProductPage(Driver);
            ProductsPage productsPage = new ProductsPage(Driver);
            ProductEntity product = new ProductEntity("Test Product", "100", "09/01/2019");

            addProductPage.FillingProductFields(product);

            bool isAddedProductVisible = productsPage.IsProductisVisible(product.ProductName);
            Assert.IsTrue(isAddedProductVisible, $"The product '{product.ProductName}' was not added to the list.");
        }

        [Test]
        public void ShouldNotAddProduct_WhenProductNameFieldIsEmpty()
        {
            MenuBar menuBar = new MenuBar(Driver);
            AddProductPage addProductPage = new AddProductPage(Driver);
            ProductEntity product = new ProductEntity("", "100", "09/01/2019");

            addProductPage.FillingProductFields(product);
            
            string actualProductNameErrorMessage = addProductPage.GetProductNameErrorMessage();
            string expectedProductNameErrorMessage = "Name must be at least 2 characters.";
            Assert.That(actualProductNameErrorMessage, Is.EqualTo(expectedProductNameErrorMessage));

            string actualFiilingFieldsErrorMessage = addProductPage.GetAllFiilingFieldsErrorMessage();
            string expectedFiilingFieldsErrorMessage = "Please fill in all fields";
            Assert.That(actualFiilingFieldsErrorMessage, Is.EqualTo(expectedFiilingFieldsErrorMessage));

            string actualErrorMessage = addProductPage.GetErrorsMustBeResolvedBeforeSubmittingErrorMessage();
            string expectedErrorMessage = "Errors must be resolved before submitting";
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));
        }

        [Test]
        public void ShouldNotAddProduct_WhenProductPriceFieldIsEmpty()
        {
            MenuBar menuBar = new MenuBar(Driver);
            AddProductPage addProductPage = new AddProductPage(Driver);
            ProductEntity product = new ProductEntity("Product3", "", "09/01/2019");

            addProductPage.FillingProductFields(product);

            string actualProductPriceErrorMessage = addProductPage.GetProductPriceErrorMessage();
            string expectedProductPriceErrorMessage = "Price must not be empty and within 10 digits";
            Assert.That(actualProductPriceErrorMessage, Is.EqualTo(expectedProductPriceErrorMessage));

            string actualFiilingFieldsErrorMessage = addProductPage.GetAllFiilingFieldsErrorMessage();
            string expectedFiilingFieldsErrorMessage = "Please fill in all fields";
            Assert.That(actualFiilingFieldsErrorMessage, Is.EqualTo(expectedFiilingFieldsErrorMessage));

            string actualErrorMessage = addProductPage.GetErrorsMustBeResolvedBeforeSubmittingErrorMessage();
            string expectedErrorMessage = "Errors must be resolved before submitting";
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));
        }

        [Test]
        public void ShouldNotAddProduct_WhenProductDateStockedFieldIsInTheFuture()
        {
            MenuBar menuBar = new MenuBar(Driver);
            AddProductPage addProductPage = new AddProductPage(Driver);
            ProductEntity product = new ProductEntity("Product3", "100", "09/01/2222");

            addProductPage.FillingProductFields(product);
           
            string actualProductDateStockeErrorMessage = addProductPage.GetDateStockedErrorMessage();
            string expectedProductDateStockeErrorMessage = "Date must not be in the future.";
            Assert.That(actualProductDateStockeErrorMessage, Is.EqualTo(expectedProductDateStockeErrorMessage));

            string actualErrorMessage = addProductPage.GetErrorsMustBeResolvedBeforeSubmittingErrorMessage();
            string expectedErrorMessage = "Errors must be resolved before submitting";
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));

        }
        [Test]
        public void ProductFilterByName_WorksCorrectly()
        {
            ProductsPage productsPage = new ProductsPage(Driver);

            string productNameToFilter = "Product 1";
            productsPage.EnterProductName(productNameToFilter);
            
            productsPage.ClickFilterBtn();
            
            bool areProductsCorrectlyFiltered = productsPage.AreFilteredProductsOnly(productNameToFilter);
            Assert.IsTrue(areProductsCorrectlyFiltered, "The product filter by name does not work correctly.");

        }

        [Test]
        public void ShouldNotFilterProduct_WhenDataIsInvalid()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            productsPage.EnterProductName("YYY");
            productsPage.ClickFilterBtn();
            string actualErrorMessage = productsPage.GetFilteringErrorMessage();
            string expectedErrorMessage = "No products found";

            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));
        }

        [Test]
        public void FilteringByProductNameField_ResetCorrectly()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            productsPage.EnterProductName("Product 1");
            productsPage.ClickFilterBtn();
            productsPage.ClickResetBtn();
            //
        }
        [Test]
        public void EditingProductInTheProductRow_IsSuccessfully()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            ProductRow productRow = productsPage.GetProductRow("Product 1");
            EditProductPage editProductPage = new EditProductPage(Driver, productRow.ProductRowElement);
            ProductEntity updatedProduct = new ProductEntity("Product 2", "200", "2021-09-01");

            productRow.ClickEditProductBtn();
            editProductPage.FillingProductFields(updatedProduct);

            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            //wait.Until(d => d.FindElement(By.TagName("body")));

            ProductRow updatedProductRow = productsPage.GetProductRow("Product 2");
            Assert.IsNotNull(updatedProductRow, "The edited product did not appear in the list.");

            ProductRow oldProductRow = productsPage.GetProductRow("Product 1");
            Assert.IsNull(oldProductRow, "The old product still exists on the page after editing.");

            Assert.AreEqual("Product 2", updatedProductRow.ProductName.Text, "Product name was not changed.");

          
        }

        [Test]
        public void ShouldNotEditProduct_WhenAllRequiredFieldsAreEmpty()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            ProductRow productRow = productsPage.GetProductRow("Product 1");
            EditProductPage editProductPage = new EditProductPage(Driver, productRow.ProductRowElement);
            ProductEntity product = new ProductEntity("", " ", " ");

            productRow.ClickEditProductBtn();
            editProductPage.FillingProductFields(product);

            string actualAlertText = productsPage.GetAlertTextWithWait();
            string expectedAlertText = "Name must be at least 2 characters.Price must not be empty and within 10 digits. Date must not be empty.Please fill in all fields. Errors must be resolved before submitting";

            Assert.That(actualAlertText, Is.EqualTo(expectedAlertText));
        }

        [Test]
        public void DeletingProduct_ShouldNotBeVisibleAfterPageRefresh()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            ProductRow productRow = productsPage.GetProductRow("Product 1");

            productRow.ClickDeleteProductBtn();
            Driver.Navigate().Refresh();

            //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            //wait.Until(d => d.FindElement(By.TagName("body")));

            var deleteProduct = productsPage.GetProductRow("Product 1");
            Assert.IsNull(deleteProduct, "The product still exists on the page after deleting and refreshing the page.");
        }
    }

}