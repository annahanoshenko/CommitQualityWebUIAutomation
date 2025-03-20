using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.PracticePageContainers;

namespace CommitQualityWebUIAutomation.CommitQualityAutomationTests
{
    [TestFixture]
    internal class FileUploadTest : CommitQualityTestBase
    {
        [Test]
        public void UploadFile_IsSuccessfully()
        {
            productsPage.ClickPracticeBtn();

            practicePage.ClickFileUpload();

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

