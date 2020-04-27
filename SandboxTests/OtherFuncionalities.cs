using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTECQATest;

namespace SandboxTests
{
    [TestClass]
    public class OtherFuncionalities
    {
        public static string titleForValidation = "123";
        public static string expectedResutls = "12345";
        public static string stepOne = "12345";

        [TestInitialize]
        public void OpenUseCasesMenu()
        {
            PageObject.UseCasesPage.OpenUseCaseMenu();
        }

        [TestMethod]
        public void AddNewStep()
        {
            PageObject.UseCasesPage.AddNewStep();
            Assert.IsTrue(PageObject.UseCasesPage.IsStepAdded());
        }

        [TestMethod]
        public void UseAutomatedSwitcher()
        {
            PageObject.UseCasesPage.TurnOnAutomatedSwithcer();
            Assert.IsTrue(PageObject.UseCasesPage.IsAutomatedSwitchOn());
        }

        [TestMethod]
        public void TitleLenghtValidation()
        {
            PageObject.UseCasesPage.TitleLenghtValidation(titleForValidation, expectedResutls, stepOne);
            Assert.IsTrue(PageObject.UseCasesPage.IsTitleLenghtValidationShown());
        }

        [TestMethod]
        public void TitleRequiredValidation()
        {
            PageObject.UseCasesPage.TitleRequiredValidation(expectedResutls, stepOne);
            Assert.IsTrue(PageObject.UseCasesPage.IsTitleRequiredValidationShown());
        }

        [TestCleanup]
        public void ReturnToUseCases()
        {
            PageObject.UseCasesPage.ReturnToUseCases(InitializeSandbox.baseUrl);
        }
    }
}
