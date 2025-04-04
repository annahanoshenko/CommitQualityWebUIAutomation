﻿using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Entities;
using CommitQualityWebUIAutomation.Extentions;
using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.Pages
{
    public class EditProductPage : PageBase
    {
        public EditProductPage(IWebDriver driver) : base(driver)
        {
        }
       
        private IWebElement ProductNameTitleField => Driver.FindElement(By.XPath("//input[@data-testid='product-textbox']"));
        private IWebElement PriceField => Driver.FindElement(By.XPath("//input[@data-testid='price-textbox']"));
        private IWebElement DataStockedField => Driver.FindElement(By.XPath("//input[@data-testid='date-stocked']"));
        private IWebElement ProductNameErrorMessage => Driver.FindElement(By.XPath("//div[label[@for='name']]//div[@class='error-message']"));
        private IWebElement ProductPriceErrorMessage => Driver.FindElement(By.XPath("//div[label[@for='price']]//div[@class='error-message']"));
        private IWebElement DateStockedErrorMessage => Driver.FindElement(By.XPath("//div[label[@for='dateStocked']]//div[@class='error-message']"));
        private IWebElement UpdateBtn => Driver.FindElement(By.XPath("//button[@data-testid='submit-form']"));
        private IWebElement CancelBtn => Driver.FindElement(By.XPath("//a[@data-testid='cancel-button']"));

        public void EditProductName(string productName) => ProductNameTitleField.SendKeys(productName);
        public void EditPriceField(string price) => PriceField.SendKeys(price);
        public void EditDataStockedField(string dateStocked) => DataStockedField.SendKeys(dateStocked);
        public void ClickUpdateBtn() => UpdateBtn.Click();
        public void ClickCancelBtn() => CancelBtn.Click();

        public string GetEditProductNameErrorMessage() => ProductNameErrorMessage.Text;
        public string GetEditProductPriceErrorMessage() => ProductPriceErrorMessage.Text;
        public string GeEditProductDateStockedErrorMessage() => DateStockedErrorMessage.Text;
        public string GetAllFiilingFieldsEditProductErrorMessage() => Driver.FindElement(By.XPath("//div[@data-testid='fillin-all-fields-validation']")).Text;
        public string GetErrorsMustBeResolvedBeforeSubmittingEditProductErrorMessage() => Driver.FindElement(By.XPath("//div[@data-testid='all-fields-validation']")).Text;

        public void FillingProductFields(ProductEntity product)
        {
            ProductNameTitleField.Clear();
            EditProductName(product.ProductName);
            PriceField.Clear();
            EditPriceField(product.ProductPrice);
            DataStockedField.Clear();
            EditDataStockedField(product.DateStocked);
            ClickUpdateBtn();
        }
        
        public void ClearAllEditProductPageFields()
        {
            ProductNameTitleField.ClearWithBackSpaceByValueAttribute();
            PriceField.ClearWithBackSpaceByValueAttribute();
            ClickUpdateBtn();

            DataStockedField.ClearWithJavaScriptByValueAttribute(Driver);
            ClickUpdateBtn();
        }
    }
}
