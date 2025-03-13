using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Pages;
using CommitQualityWebUIAutomation.PracticePageContainers;

namespace CommitQualityWebUIAutomation.AutoTests
{
    [TestFixture]
    public class AccordionWithPopupTests : TestBase
    {
        [Test]
        public void TestAccordionWithPopup()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            productsPage.ClickPracticeBtn();

            PracticePage practicepage = new PracticePage(Driver);
            practicepage.ClickPopups();
           
            PopupContainer popupContainer = new PopupContainer(Driver);
            popupContainer.WaitForPopup();
            Assert.IsTrue(popupContainer.IsPopupDisplayed(), "Popup is not displayed!");
            popupContainer.ClickCloseBtn();
            Assert.IsFalse(popupContainer.IsPopupDisplayed(), "Popup is still displayed after closing!");
        }
        
    }
}
