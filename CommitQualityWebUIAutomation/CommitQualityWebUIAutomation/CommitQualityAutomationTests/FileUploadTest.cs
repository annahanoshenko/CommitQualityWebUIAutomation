using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Pages;
using CommitQualityWebUIAutomation.PracticePageContainers;

namespace CommitQualityWebUIAutomation.CommitQualityAutomationTests
{
    [TestFixture]
    internal class FileUploadTest : TestBase
    {
        [Test]
        public void UploadFile_IsSuccessfully()
        {

           ProductsPage productsPage = new ProductsPage(Driver);
            productsPage.ClickPracticeBtn();

            PracticePage practicepage = new PracticePage(Driver);
            practicepage.ClickFileUpload();

            FileUploadContainer fileUploadContainer = new FileUploadContainer(Driver);
            fileUploadContainer.UploadFile("C:/Users/Anna/OneDrive/Pictures/Screenshots/Screenshot 2025-01-08 134315.png");
            fileUploadContainer.ClickSubmitButton();
            string actualAlertText = fileUploadContainer.GetAlertTextWithWait();
            string expectedAlertText = "File successfully uploaded!";
            fileUploadContainer.AcceptAlertWithWait();

            Assert.That(actualAlertText.Equals(expectedAlertText));
        }
    }
}

