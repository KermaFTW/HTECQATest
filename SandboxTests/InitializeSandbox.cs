using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTECQATest;

namespace SandboxTests
{
    [TestClass]
    public class InitializeSandbox
    {
        public static string baseUrl;
        public static string email;
        public static string password;

        [AssemblyInitialize]
        public static void LoginToSandbox(TestContext tc)
        {
            baseUrl = tc.Properties["baseUrl"].ToString();
            email = tc.Properties["email"].ToString();
            password = tc.Properties["password"].ToString();


            PageObject.LoginPage.OpenBrowser(baseUrl);
            PageObject.LoginPage.LoginToSandbox(email, password);
        }

        [AssemblyCleanup]
        public static void Close()
        {
            Browser.Close();
        }
    }
}
