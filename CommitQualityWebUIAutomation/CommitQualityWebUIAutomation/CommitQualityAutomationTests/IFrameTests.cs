using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Pages;
using CommitQualityWebUIAutomation.PracticePageContainers;

namespace CommitQualityWebUIAutomation.CommitQualityAutomationTests
{
    [TestFixture]
    public class IFrameTests : TestBase
    {
        [Test]
        public void CanTestClickMeButtonInIFrame()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            productsPage.ClickPracticeBtn();

            PracticePage practicepage = new PracticePage(Driver);
            practicepage.ClickIframes();

            IFrameContainer iFrameContainer = new IFrameContainer(Driver);
            iFrameContainer.SwitchToIFrame();
            iFrameContainer.ClickPracticeBtnInsideIframe();
            iFrameContainer.ClickGeneralComponentsContainerInsideIframe();
            iFrameContainer.ClickClickMeButtonInsideIframe();
            Assert.IsTrue(iFrameContainer.IsButtonClickedMessageDisplayed(), "Button clicked message is not displayed!");
            iFrameContainer.SwitchToDefaultContent();
        }
    }
}
