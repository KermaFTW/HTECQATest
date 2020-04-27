using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTECQATest;

namespace SandboxTests
{
    [TestClass]
    public class EditTesCase
    {
        public static string testCaseNameEdit = "TestCaseEdit";
        public static string descriptionEdit = "Edit description";
        public static string expectedResultsEdit = "Edit Expected Result";
        public static string stepOneEdit = "Edit Step";

        [ClassInitialize]
        public static void OpenUseCasesMenu(TestContext tc)
        {
            PageObject.UseCasesPage.OpenUseCaseMenu();
        }

        [TestMethod]
        public void CreateUseCaseAndEdit()
        {
            int noOfCharacters = testCaseNameEdit.Length;
            string newTitle = "This field previously had " + noOfCharacters + " characters";

            PageObject.UseCasesPage.CreateUseCase(testCaseNameEdit, descriptionEdit, expectedResultsEdit, stepOneEdit);
            Assert.IsTrue(PageObject.UseCasesPage.IsUseCaseCreated(testCaseNameEdit));
            PageObject.UseCasesPage.EditAndReplaceWithCount();
            Assert.IsTrue(PageObject.UseCasesPage.IsUseCaseCreated(newTitle));
        }

        [TestCleanup]
        public void ReturnToUseCases()
        {
            PageObject.UseCasesPage.ReturnToUseCases(InitializeSandbox.baseUrl);
        }
    }
}
