using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.PracticePageContainers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitQualityWebUIAutomation.AutoTests
{
    [TestFixture]
    public class AccordionWithPopupTests : TestBase
    {
        [Test]
        public void TestAccordionWithPopup()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            productsPage.ClickPracticeBtn();

            PracticePage practicepage = new PracticePage(Driver);
            practicepage.ClickAccordions();

            AccordionsContainer accordions = new AccordionsContainer(Driver);
            accordions.ClickAccordion1();
            Assert.AreEqual("Accordion 1 clicked", accordions.GetAccordion1ClickedMessage());
        }
    }
}
