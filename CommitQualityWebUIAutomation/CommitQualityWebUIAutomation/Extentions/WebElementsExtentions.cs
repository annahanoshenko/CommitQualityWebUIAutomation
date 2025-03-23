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

        public static void ClearWithBackSpaceByValueAttribute(this IWebElement webElement)
        {
            int numberOfCharactersToDelete = webElement.GetAttribute("value").Length;
            for (int i = 0; i < numberOfCharactersToDelete; i++)
            {
                webElement.SendKeys(Keys.Backspace);
            }
        }

        public static void ClearWithJavaScriptByValueAttribute(this IWebElement webElement, IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].value = '';", webElement);
        }
    }
}
