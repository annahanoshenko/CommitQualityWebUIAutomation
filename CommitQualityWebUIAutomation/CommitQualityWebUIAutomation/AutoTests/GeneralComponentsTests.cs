using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Pages;
using CommitQualityWebUIAutomation.PracticePageContainers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitQualityWebUIAutomation.AutoTests
{
    [TestFixture]
    public class GeneralComponentsTests : TestBase
    {
        public GeneralComponentsTests(IWebDriver driver) : base(driver)
        {
        }

        [Test]
        public void TestClickButton()
        {
            GeneralComponentsContainer generalComponents = new GeneralComponentsContainer(Driver);
            generalComponents.ClickMeButtonClick();
            Assert.AreEqual("Button clicked", generalComponents.GetButtonClickedMessage());
        }

        [Test]
        public void TestDoubleClickButton()
        {
            GeneralComponentsContainer generalComponents = new GeneralComponentsContainer(Driver);
            generalComponents.DoubleClickMeButtonClick();
            
            Assert.AreEqual("Button double clicked", generalComponents.GetButtonDoubleClickedMessage());
        }
       
        [Test]
        public void TestRightClickButton()
        {
            GeneralComponentsContainer generalComponents = new GeneralComponentsContainer(Driver);
            generalComponents.RightClickMeButtonClick();
            Assert.AreEqual("Button right mouse clicked", generalComponents.GetButtonRightClickedMessage());
        }

        [Test]
        public void TestRadioButton()
        {
            GeneralComponentsContainer generalComponents = new GeneralComponentsContainer(Driver);
            generalComponents.RightClickMeButtonClick();
            Assert.AreEqual("Button right mouse clicked", generalComponents.GetButtonRightClickedMessage());
        }
    }
}
