using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.PracticePageContainers;

namespace CommitQualityWebUIAutomation.CommitQualityAutomationTests
{
    [TestFixture]
    public class DynamicTextTest : CommitQualityTestBase
    {
        [Test]
        public void ButtonTextChangesAfterClicking()
        {
            productsPage.ClickPracticeBtn();

            practicePage.ClickDynamicText();

            DynamicTextContainer dynamicTextContainer = new DynamicTextContainer(Driver);
            string initialText = dynamicTextContainer.GetDynamicButtonText();
            dynamicTextContainer.ClickDynamicTextButton();
            dynamicTextContainer.IsDynamicButtonTextChanged();
            Assert.IsTrue(dynamicTextContainer.IsDynamicButtonTextChanged(), "Button text did not change as expected!");
            
        }
    }
}
