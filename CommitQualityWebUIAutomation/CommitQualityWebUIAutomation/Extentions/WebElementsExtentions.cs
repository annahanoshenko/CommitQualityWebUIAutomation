using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitQualityWebUIAutomation.Extentions
{
    public static class WebElementsExtentions
    {
        public static bool Exists(this IWebElement element)
        {
            try
            {
                string tagName = element.TagName;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
