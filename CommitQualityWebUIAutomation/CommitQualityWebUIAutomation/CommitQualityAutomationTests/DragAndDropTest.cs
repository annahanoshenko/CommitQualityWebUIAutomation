using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Pages;
using CommitQualityWebUIAutomation.PracticePageContainers;


namespace CommitQualityWebUIAutomation.CommitQualityAutomationTests
{
    [TestFixture]
    public class DragAndDropTest : TestBase
    {
        [Test]
        public void DragAndDrop_WorkSuccessfully()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            productsPage.ClickPracticeBtn();

            PracticePage practicePage = new PracticePage(Driver);
            practicePage.ClickDragAndDrop();

            DragAndDropContainer dragAndDropContainer = new DragAndDropContainer(Driver);
            dragAndDropContainer.PerformDragAndDrop();

            Assert.IsTrue(dragAndDropContainer.IsDropSuccessful(), "Drag and drop was not successful!");
        }

    }
}
