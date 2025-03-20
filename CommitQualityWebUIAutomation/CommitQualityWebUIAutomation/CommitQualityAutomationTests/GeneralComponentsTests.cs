using CommitQualityWebUIAutomation.Base;

namespace CommitQualityWebUIAutomation.AutoTests
{
    [TestFixture]
    public class GeneralComponentsTests : CommitQualityTestBase
    {
        [Test]
        public void TestClickButton()
        {
            productsPage.ClickPracticeBtn();

            practicePage.ClickGeneralComponents();
           
            generalComponents.ClickMeButtonClick();
            Assert.AreEqual("Button clicked", generalComponents.GetButtonClickedMessage());
        }

        [Test]
        public void TestDoubleClickButton()
        {
            productsPage.ClickPracticeBtn();

            practicePage.ClickGeneralComponents();

            generalComponents.DoubleClickMeButtonClick();
            Assert.AreEqual("Button double clicked", generalComponents.GetButtonDoubleClickedMessage());
        }
       
        [Test]
        public void TestRightClickButton()
        {
            productsPage.ClickPracticeBtn();

            practicePage.ClickGeneralComponents();

            generalComponents.RightClickMeButtonClick();
            Assert.AreEqual("Button right mouse clicked", generalComponents.GetButtonRightClickedMessage());
        }

        [Test]
        public void TestRadioButton()
        {
            productsPage.ClickPracticeBtn();

            practicePage.ClickGeneralComponents();

            generalComponents.RadioButtonClick();
            Assert.AreEqual("option1 clicked", generalComponents.GetOption1ClickedMessage());

            generalComponents.RadioButton2Click();
            Assert.AreEqual("option2 clicked", generalComponents.GetOption2ClickedMessage());
        }

        [Test]
        public void TestSelectOption1DropDown() 
        {
            productsPage.ClickPracticeBtn();

            practicePage.ClickGeneralComponents();

            generalComponents.SelectFromDropDown("Option 1");
            string selectedOption = generalComponents.GetSelectedDropDownOption();
            Assert.AreEqual("Option 1", selectedOption, "Dropdown selection did not match!");
        }

        [Test]
        public void Test_ThatAllCheckboxButtonsAreSelected()
        {
            productsPage.ClickPracticeBtn();

            practicePage.ClickGeneralComponents();

            generalComponents.ClickAllCheckboxes();
            Assert.IsTrue(generalComponents.AreAllCheckboxesSelected(), "Not all checkboxes were selected!");
        }

        [Test]
        public void Test_CanUncheckOf2Checkboxes()
        {
            productsPage.ClickPracticeBtn();

            practicePage.ClickGeneralComponents();

            generalComponents.ClickAllCheckboxes();
            generalComponents.UncheckCheckboxes(2);
           
            Assert.IsFalse(generalComponents.IsCheckboxSelected(0), "Checkbox 1 is still checked!");
            Assert.IsFalse(generalComponents.IsCheckboxSelected(1), "Checkbox 2 is still checked!");
        }
    }
}
