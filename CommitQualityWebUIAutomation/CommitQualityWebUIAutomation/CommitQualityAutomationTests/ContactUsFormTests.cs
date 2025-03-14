using CommitQualityWebUIAutomation.Base;
using CommitQualityWebUIAutomation.Entities;
using CommitQualityWebUIAutomation.Pages;
using CommitQualityWebUIAutomation.PracticePageContainers;

namespace CommitQualityWebUIAutomation.CommitQualityAutomationTests
{
    [TestFixture]
    public class ContactUsFormTests : TestBase
    {
        [Test]
        public void ShouldSendContactUsForm_WhenDataIsValid()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            productsPage.ClickPracticeBtn();

            PracticePage practicepage = new PracticePage(Driver);
            practicepage.ClickContactUsForm();

            ContactUsFormContainer contactUsFormContainer = new ContactUsFormContainer(Driver);
            ContactUsFormUserEntity contactUsFormUser = new ContactUsFormUserEntity("John Doe", "johndoe22@gmail.com", "General", "01/01/1990");

            contactUsFormContainer.FillingContuctUsFieldsAndCheckbox(contactUsFormUser);
            
            string selectedOption = contactUsFormContainer.GetSelectQueryType();
            string actualSuccessMessage = contactUsFormContainer.GetSuccessMessageText();
            string expectSuccessMessage = "Thanks for contacting us, we will never respond!";

            Assert.That(actualSuccessMessage.Equals(expectSuccessMessage), "Alert text does not match!");
        }

        [Test]
        public void ShouldNotSubmitContacUsForm_WhenRequiredEmailFieldIsEmpty()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            productsPage.ClickPracticeBtn();

            PracticePage practicepage = new PracticePage(Driver);
            practicepage.ClickContactUsForm();

            ContactUsFormContainer contactUsFormContainer = new ContactUsFormContainer(Driver);
            ContactUsFormUserEntity contactUsFormUser = new ContactUsFormUserEntity("John Doe", "", "General", "01/01/1990");

            contactUsFormContainer.FillingContuctUsFieldsAndCheckbox(contactUsFormUser);

            string selectedOption = contactUsFormContainer.GetSelectQueryType();
            string actualEmailErrorMessage = contactUsFormContainer.GetEmailErrorMessage();
            string expectedEmailErrorMessage = "Email is required.";

            Assert.That(actualEmailErrorMessage.Equals(expectedEmailErrorMessage), "Email error message does not match!");
        }

        [Test]
        public void ShouldNotSubmitContacUsForm_WhenRequiredCheckboxIsNotChecked()
        {
            ProductsPage productsPage = new ProductsPage(Driver);
            productsPage.ClickPracticeBtn();

            PracticePage practicepage = new PracticePage(Driver);
            practicepage.ClickContactUsForm();

            ContactUsFormContainer contactUsFormContainer = new ContactUsFormContainer(Driver);
            ContactUsFormUserEntity contactUsFormUser = new ContactUsFormUserEntity("John Doe", "johndoe22@gmail.com", "General", "01/01/1990");

            contactUsFormContainer.FillingContuctUsFields(contactUsFormUser);

            string selectedOption = contactUsFormContainer.GetSelectQueryType();
            string actualCheckboxErrorMessage = contactUsFormContainer.GetAgreeCheckBoxErrorMessage();
            string expectedCheckboxErrorMessage = "Please check the box to confirm you're aware that this is a practice website.";

            Assert.That(actualCheckboxErrorMessage.Equals(expectedCheckboxErrorMessage), "Checkbox error message does not match!");
        }
    }
}

