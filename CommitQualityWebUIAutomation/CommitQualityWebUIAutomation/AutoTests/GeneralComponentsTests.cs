using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Pages;
using CommitQualityWebUIAutomation.PracticePageContainers;
using OpenQA.Selenium;


namespace CommitQualityWebUIAutomation.AutoTests
{
    [TestFixture]
    public class GeneralComponentsTests : TestBase
    {

        [Test]
        public void TestClickButton()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            productsPage.ClickPracticeBtn();

            PracticePage practicepage = new PracticePage(Driver);
            practicepage.ClickGeneralComponents();
           
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
            generalComponents.RadioButtonClick();
            Assert.AreEqual("option1 clicked", generalComponents.GetOption1ClickedMessage());

            generalComponents.RadioButton2Click();
            Assert.AreEqual("option2 clicked", generalComponents.GetOption2ClickedMessage());
        }

        [Test]
        public void TestSelectOption1DropDown() {
            GeneralComponentsContainer generalComponents = new GeneralComponentsContainer(Driver);
           
            generalComponents.SelectFromDropDown("option1");
            string selectedOption = generalComponents.GetSelectedDropDownOption();
            Assert.AreEqual("option1", selectedOption, "Dropdown selection did not match!");
        }

        [Test]
        public void Test_ThatAllCheckboxButtonsAreSelected()
        {
            GeneralComponentsContainer generalComponents = new GeneralComponentsContainer(Driver);
            generalComponents.ClickAllCheckboxes();
            Assert.IsTrue(generalComponents.AreAllCheckboxesSelected(), "Not all checkboxes were selected!");
        }

        [Test]
        public void Test_CanUncheckOf2Checkboxes()
        {
            GeneralComponentsContainer generalComponents = new GeneralComponentsContainer(Driver);
            generalComponents.ClickAllCheckboxes();
            generalComponents.UncheckCheckboxes(2);
           
            Assert.IsFalse(generalComponents.IsCheckboxSelected(0), "Checkbox 1 is still checked!");
            Assert.IsFalse(generalComponents.IsCheckboxSelected(1), "Checkbox 2 is still checked!");
        }
    }
}
