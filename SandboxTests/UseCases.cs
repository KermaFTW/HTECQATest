using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTECQATest;

namespace SandboxTests
{
    [TestClass]
    public class UseCases
    {
        public static string testCaseName1 = "TestCase1";
        public static string description1 = "First description";
        public static string expectedResults1 = "First Expected Result";
        public static string stepOne1 = "First Step";

        public static string testCaseName2 = "TestCase2";
        public static string description2 = "Second description";
        public static string expectedResults2 = "Second Expected Result";
        public static string stepOne2 = "Second Step";

        public static string testCaseName3 = "TestCase3";
        public static string description3 = "Third description";
        public static string expectedResults3 = "Third Expected Result";
        public static string stepOne3 = "Third Step";

        public static string testCaseName4 = "TestCase4";
        public static string description4 = "Fourth description";
        public static string expectedResults4 = "Fourth Expected Result";
        public static string stepOne4 = "Fourth Step";

        [ClassInitialize]
        public static void OpenUseCasesMenu(TestContext tc)
        {
            PageObject.UseCasesPage.OpenUseCaseMenu();
        }

        [TestMethod]
        public void CreateUseCase1()
        {
            PageObject.UseCasesPage.CreateUseCase(testCaseName1, description1, expectedResults1, stepOne1);
            Assert.IsTrue(PageObject.UseCasesPage.IsUseCaseCreated(testCaseName1));
        }

        [TestMethod]
        public void CreateUseCase2()
        {
            PageObject.UseCasesPage.CreateUseCase(testCaseName2, description2, expectedResults2, stepOne2);
            Assert.IsTrue(PageObject.UseCasesPage.IsUseCaseCreated(testCaseName2));
        }

        [TestMethod]
        public void CreateUseCase3()
        {
            PageObject.UseCasesPage.CreateUseCase(testCaseName3, description3, expectedResults3, stepOne3);
            Assert.IsTrue(PageObject.UseCasesPage.IsUseCaseCreated(testCaseName3));
        }

        [TestMethod]
        public void CreateUseCase4()
        {
            PageObject.UseCasesPage.CreateUseCase(testCaseName4, description4, expectedResults4, stepOne4);
            Assert.IsTrue(PageObject.UseCasesPage.IsUseCaseCreated(testCaseName4));
        }

        [ClassCleanup]
        public static void ReturnToUseCases()
        {
            PageObject.UseCasesPage.ReturnToUseCases(InitializeSandbox.baseUrl);
        }

    }
}
