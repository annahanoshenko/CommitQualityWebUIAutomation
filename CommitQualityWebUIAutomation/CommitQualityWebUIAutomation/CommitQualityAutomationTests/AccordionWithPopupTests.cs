using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Pages.PracticePageContainers;

namespace CommitQualityWebUIAutomation.AutoTests
{
    [TestFixture]
    public class AccordionWithPopupTests : CommitQualityTestBase
    {
        [Test]
        public void TestAccordionWithPopup()
        {
            productsPage.ClickPracticeBtn();

            practicePage.ClickPopups();
           
            PopupContainer popupContainer = new PopupContainer(Driver);
            popupContainer.WaitForPopup();
            Assert.IsTrue(popupContainer.IsPopupDisplayed(), "Popup is not displayed!");
            popupContainer.ClickCloseBtn();
            Assert.IsFalse(popupContainer.IsPopupDisplayed(), "Popup is still displayed after closing!");
        }   
    }
}
