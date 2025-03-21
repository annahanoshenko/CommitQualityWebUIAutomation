using OpenQA.Selenium;

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
