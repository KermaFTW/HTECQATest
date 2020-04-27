using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HTECQATest
{
    public class LoginPage
    {
        private IWebElement loginButton => Browser.Driver.FindElement(By.XPath("//a[@class='btn btn-lg btn-secondary']"));
        private IWebElement emailInput => Browser.Driver.FindElement(By.Name("email"));
        private IWebElement passwordInput => Browser.Driver.FindElement(By.Name("password"));
        private IWebElement submitButton => Browser.Driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block mt-4']"));

        WebDriverWait wait = new WebDriverWait(Browser.Driver, new TimeSpan(0, 0, 30));

        public void OpenBrowser(string baseUrl)
        {
            Browser.GoTo(baseUrl);
        }

        public void LoginToSandbox(string email, string password)
        {
            Browser.Wait(loginButton);
            loginButton.Click();
            Browser.Wait(emailInput);
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            submitButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("Logout")));
        }
    }
}
