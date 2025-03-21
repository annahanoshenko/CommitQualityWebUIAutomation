using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.PracticePageContainers;

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

        [TestCase("option1")]
        [TestCase("option2")]
        public void TestRadioButton(string optionName)
        {
            productsPage.ClickPracticeBtn();

            practicePage.ClickGeneralComponents();
          
            generalComponents.SelectRadioButtonOption(optionName);
            string selectRadioBtn = generalComponents.GetOptionClickedMessage();

            Assert.AreEqual($"{optionName} clicked", selectRadioBtn, "RadioButton selection did not match!");
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
