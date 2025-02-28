using CommitQualityWebUIAutomation.WebElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitQualityWebUIAutomation.Pages
{
    public class EditProductPage : ProductRaws
    {
        private IWebElement ProductNameTitle => Driver.FindElement(By.XPath("//input[@data-testid='product-textbox']"));
    }
}
