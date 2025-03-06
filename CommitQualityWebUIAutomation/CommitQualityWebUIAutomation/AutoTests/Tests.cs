using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Entities;
using CommitQualityWebUIAutomation.Helpers;
using CommitQualityWebUIAutomation.Pages;
using CommitQualityWebUIAutomation.WebElements;
using System.Security.Cryptography;

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
            
            string productName = StringsHelper.GenerateRandomString(10);
            ProductEntity product = new ProductEntity(productName, "100", "09/01/2019");

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

            bool isProductVisible = productsPage.IsProductisVisible("Product 1");
            Assert.IsTrue(isProductVisible, "The product filter by name does not work correctly.");
           
            productsPage.ClickResetBtn();
            
            string productNameFieldText = productsPage.GetProductNameFieldText();
            Assert.IsEmpty(productNameFieldText, "The product name filter field is not reset.");
            
            bool areAllProductsVisible = productsPage.AreAllProductsVisible();
            Assert.IsTrue(areAllProductsVisible, "Not all products are visible after resetting the filter.");
        }

        [Test]
        public void EditingProductInTheProductRow_IsSuccessfully()
        {
            LoginPage loginPage = new LoginPage(Driver);
            UserEntity user = new UserEntity("test", "test");
            loginPage.LoginUser(user);

            ProductsPage productsPage = new ProductsPage(Driver);
            AddProductPage addProductPage = new AddProductPage(Driver);
            string productName = StringsHelper.GenerateRandomString(8);
            ProductEntity product = new ProductEntity(productName, "105", "03/02/2022");
            addProductPage.FillingProductFields(product);

            productsPage.EditProduct(productName);

            EditProductPage editProductPage = new EditProductPage(Driver);
            string editProductName = StringsHelper.GenerateRandomString(8);
            ProductEntity editProduct = new ProductEntity(editProductName, "200", "03/02/2021");
            editProductPage.FillingProductFields(editProduct);

            bool isProductEdited = productsPage.IsProductisVisible(editProductName);
            Assert.IsTrue(isProductEdited, "The edited product did not appear in the list");

            bool oldProductExists = productsPage.IsProductisVisible(productName);
            Assert.IsFalse(oldProductExists, "The old product still exists in the list.");
        }

        [Test]
        public void ShouldNotEditProduct_WhenAllRequiredFieldsAreEmpty()
        {
            LoginPage loginPage = new LoginPage(Driver);
            UserEntity user = new UserEntity("test", "test");
            loginPage.LoginUser(user);

            ProductsPage productsPage = new ProductsPage(Driver);
            AddProductPage addProductPage = new AddProductPage(Driver);
            string productName = StringsHelper.GenerateRandomString(8);
            ProductEntity product = new ProductEntity(productName, "105", "03/02/2022");
            addProductPage.FillingProductFields(product);

            productsPage.EditProduct(productName);

            EditProductPage editProductPage = new EditProductPage(Driver);
            ProductEntity editProduct = new ProductEntity("", "", "");
            editProductPage.ClearWithBackSpace();

            string actualEditProductNameErrorMessage = editProductPage.GetEditProductNameErrorMessage();
            string expectedEditProductNameErrorMessage = "Name must be at least 2 characters.";
            Assert.That(actualEditProductNameErrorMessage, Is.EqualTo(expectedEditProductNameErrorMessage));

            string actualEditProductPriceErrorMessage = editProductPage.GetEditProductPriceErrorMessage();
            string expectedEditProductPriceErrorMessage = "Price must not be empty and within 10 digits";
            Assert.That(actualEditProductPriceErrorMessage, Is.EqualTo(expectedEditProductPriceErrorMessage));

            //string actualEditProductDateStockeErrorMessage = editProductPage.GeEditProductDateStockedErrorMessage();
            //string expectedEditProductDateStockeErrorMessage = "Date must not be empty.";
            //Assert.That(actualEditProductDateStockeErrorMessage, Is.EqualTo(expectedEditProductDateStockeErrorMessage));

            string actualFiilingFieldsErrorMessage = editProductPage.GetAllFiilingFieldsEditProductErrorMessage();
            string expectedFiilingFieldsErrorMessage = "Please fill in all fields";
            Assert.That(actualFiilingFieldsErrorMessage, Is.EqualTo(expectedFiilingFieldsErrorMessage));

            string actualErrorMessage = editProductPage.GetErrorsMustBeResolvedBeforeSubmittingEditProductErrorMessage();
            string expectedErrorMessage = "Errors must be resolved before submitting";
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage));
        }

        [Test]
        public void DeletingProduct_ShouldNotBeVisibleAfterPageRefresh()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            AddProductPage addProductPage = new AddProductPage(Driver);
            LoginPage loginPage = new LoginPage(Driver);

            UserEntity user = new UserEntity("test", "test");

            loginPage.LoginUser(user);

            string productName = StringsHelper.GenerateRandomString(8);
            ProductEntity product = new ProductEntity(productName, "104", "11/01/2019");

            addProductPage.FillingProductFields(product);

            productsPage.DeleteProduct(productName);

            Driver.Navigate().Refresh();

            bool productExists = productsPage.IsProductisVisible(productName);
            Assert.IsFalse(productExists, "The product still exists on the page after deleting and refreshing the page.");
        }
    }

}