using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.PracticePageContainers;

namespace CommitQualityWebUIAutomation.CommitQualityAutomationTests
{
    [TestFixture]
    public class DownLoadFileTest : CommitQualityTestBase
    {
        [Test]
        public void TestFileDownload()
        {
            productsPage.ClickPracticeBtn();

            practicePage.ClickFileDownload();

            DownLoadFileContainer downLoadFileContainer = new DownLoadFileContainer(Driver);
            string downloadPath = @"C:\Users\Anna\Downloads"; 
            string fileName = $"dummy_file";

            downLoadFileContainer.DownloadFile();
            FileInfo isFileDownload = downLoadFileContainer.WaitForFileDownload(downloadPath, fileName, 20);
            string content = File.ReadAllText(isFileDownload.FullName);
            Assert.AreEqual(content, "This is a dummy text file.");
        }
    }
}
