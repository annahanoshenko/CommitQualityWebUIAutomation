using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Pages;
using CommitQualityWebUIAutomation.PracticePageContainers;


namespace CommitQualityWebUIAutomation.CommitQualityAutomationTests
{
    [TestFixture]
    public class DownLoadFileTest : TestBase
    {
        [Test]
        public void TestFileDownload()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            productsPage.ClickPracticeBtn();

            PracticePage practicepage = new PracticePage(Driver);
            practicepage.ClickFileDownload();

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
