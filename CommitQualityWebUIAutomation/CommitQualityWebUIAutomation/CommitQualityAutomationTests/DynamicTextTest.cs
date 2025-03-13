using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Pages;
using CommitQualityWebUIAutomation.PracticePageContainers;


namespace CommitQualityWebUIAutomation.CommitQualityAutomationTests
{
    [TestFixture]
    public class DynamicTextTest : TestBase
    {
        [Test]
        public void ButtonTextChangesAfterClicking()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            productsPage.ClickPracticeBtn();

            PracticePage practicepage = new PracticePage(Driver);
            practicepage.ClickDynamicText();

            DynamicTextContainer dynamicTextContainer = new DynamicTextContainer(Driver);
            string initialText = dynamicTextContainer.GetDynamicButtonText();
            dynamicTextContainer.ClickDynamicTextButton();
            dynamicTextContainer.IsDynamicButtonTextChanged();
            Assert.IsTrue(dynamicTextContainer.IsDynamicButtonTextChanged(), "Button text did not change as expected!");
            
        }
    }
}
