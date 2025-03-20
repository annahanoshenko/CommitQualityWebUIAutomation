using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.PracticePageContainers;

namespace CommitQualityWebUIAutomation.CommitQualityAutomationTests
{
    [TestFixture]
    public class IFrameTests : CommitQualityTestBase
    {
        [Test]
        public void CanTestClickMeButtonInIFrame()
        {
            productsPage.ClickPracticeBtn();

            practicePage.ClickIframes();

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
