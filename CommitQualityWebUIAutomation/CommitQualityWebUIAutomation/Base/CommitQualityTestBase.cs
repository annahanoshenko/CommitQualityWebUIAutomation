using CommitQualityWebUIAutomation.Pages;
using CommitQualityWebUIAutomation.Pages.PracticePageContainers;
using CommitQualityWebUIAutomation.WebElements;

namespace CommitQualityWebUIAutomation.Base
{
    public class CommitQualityTestBase : TestBase
    {
        protected LoginPage loginPage => new LoginPage(Driver);
        protected MenuBar menuBar => new MenuBar(Driver);
        protected ProductRow productRow => new ProductRow(Driver);
        protected AddProductPage addProductPage => new AddProductPage(Driver);
        protected ProductsPage productsPage => new ProductsPage(Driver);
        protected EditProductPage editProductPage => new EditProductPage(Driver);
        protected PracticePage practicePage => new PracticePage(Driver);
        protected ContactUsFormContainer contactUsFormContainer => new ContactUsFormContainer(Driver);
        protected GeneralComponentsContainer generalComponents => new GeneralComponentsContainer(Driver);
    }
}
