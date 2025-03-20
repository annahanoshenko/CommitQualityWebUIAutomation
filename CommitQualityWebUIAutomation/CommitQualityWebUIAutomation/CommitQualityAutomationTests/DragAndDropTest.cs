using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.PracticePageContainers;

namespace CommitQualityWebUIAutomation.CommitQualityAutomationTests
{
    [TestFixture]
    public class DragAndDropTest : CommitQualityTestBase
    {
        [Test]
        public void DragAndDrop_WorkSuccessfully()
        {
            productsPage.ClickPracticeBtn();

            practicePage.ClickDragAndDrop();

            DragAndDropContainer dragAndDropContainer = new DragAndDropContainer(Driver);
            dragAndDropContainer.PerformDragAndDrop();

            Assert.IsTrue(dragAndDropContainer.IsDropSuccessful(), "Drag and drop was not successful!");
        }
    }
}
