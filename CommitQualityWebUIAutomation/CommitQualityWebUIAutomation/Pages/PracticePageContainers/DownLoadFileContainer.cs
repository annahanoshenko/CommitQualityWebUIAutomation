using CommitQualityWebUIAutomation.Base;
using OpenQA.Selenium;

namespace CommitQualityWebUIAutomation.Pages.PracticePageContainers
{
    public class DownLoadFileContainer : PageBase
    {
        public DownLoadFileContainer(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement DownLoadFileBtn => Driver.FindElement(By.XPath("//button[text()='Download File']"));
        public void DownloadFile() => DownLoadFileBtn.Click();

        public FileInfo WaitForFileDownload(string directoryPath, string fileName, int timeToDownload)
        {
            bool isFileDownloaded = true;

            FileInfo[]? dummyFileSortedByTime = null;

            while (isFileDownloaded)
            {
                var files = new DirectoryInfo(directoryPath).GetFiles();
                var dummyFiles = files.Where(f => f.Name.Contains(fileName)).ToArray();
                dummyFileSortedByTime = dummyFiles.OrderByDescending(f => f.CreationTime).ToArray();

                isFileDownloaded = !dummyFileSortedByTime.Any(f => f.CreationTime > DateTime.Now.AddSeconds(-timeToDownload));

            }

            return dummyFileSortedByTime!.First();
        }
    }
}
