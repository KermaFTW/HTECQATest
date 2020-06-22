using OpenQA.Selenium;

namespace HTECQATest
{
	public class LoginPage
	{
		private IWebElement loginButton => Browser.Driver.FindElement(By.XPath("//a[@class='btn btn-lg btn-secondary']"));
		private IWebElement emailInput => Browser.Driver.FindElement(By.Name("email"));
		private IWebElement passwordInput => Browser.Driver.FindElement(By.Name("password"));
		private IWebElement submitButton => Browser.Driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block mt-4']"));

		public void OpenBrowser(string baseUrl)
		{
			Browser.GoTo(baseUrl);
		}

		public void LoginToSandbox(string email, string password)
		{
			Browser.Wait(By.XPath("//a[@class='btn btn-lg btn-secondary']"));
			loginButton.Click();
			Browser.Wait(By.Name("email"));
			emailInput.SendKeys(email);
			passwordInput.SendKeys(password);
			submitButton.Click();
			Browser.Wait(By.LinkText("Logout"));
		}
	}
}
