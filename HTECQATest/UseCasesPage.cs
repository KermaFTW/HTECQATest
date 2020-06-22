using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HTECQATest
{
	public class UseCasesPage
	{
		//Web elements on page
		private IWebElement useCasesCard => Browser.Driver.FindElement(By.XPath("//div[@data-testid='use_cases_card_id']"));
		private IWebElement createUseCaseButton => Browser.Driver.FindElement(By.XPath("//a[@data-testid='create_use_case_btn']"));
		private IWebElement titleInput => Browser.Driver.FindElement(By.Name("title"));
		private IWebElement descriptionInput => Browser.Driver.FindElement(By.Name("description"));
		private IWebElement expectedResultsInput => Browser.Driver.FindElement(By.Name("expected_result"));
		private IWebElement stepOneInput => Browser.Driver.FindElement(By.Name("testStepId-0"));
		private IWebElement automatedSwitchValue => Browser.Driver.FindElement(By.Id("switch"));
		private IWebElement automatedSwitchButton => Browser.Driver.FindElement(By.XPath("//label[@for='switch']"));
		private IWebElement submitButton => Browser.Driver.FindElement(By.XPath("//button[@data-testid='submit_btn']"));
		private IWebElement addStepButton => Browser.Driver.FindElement(By.XPath("//span[@data-testid='add_step_btn']"));
		private IWebElement stepTwoInput => Browser.Driver.FindElement(By.Name("testStepId-1"));
		private IWebElement editTestCase => Browser.Driver.FindElement(By.LinkText("TestCaseEdit"));
		private IWebElement validationMessage => Browser.Driver.FindElement(By.ClassName("invalid-feedback"));

		//list of created Test Cases 
		private IList<IWebElement> listOfCreatedTC = Browser.Driver.FindElements(By.CssSelector("[href*='use-cases']"));

		public void OpenUseCaseMenu()
		{
			Browser.Wait(By.XPath("//div[@data-testid='use_cases_card_id']"));
			useCasesCard.Click();
		}

		public void CreateUseCase(string title, string description, string expectedResults, string stepOne)
		{
			Browser.Wait(By.XPath("//a[@data-testid='create_use_case_btn']"));
			createUseCaseButton.Click();
			Browser.Wait(By.Name("title"));
			titleInput.SendKeys(title);
			Browser.Wait(By.Name("description"));
			descriptionInput.SendKeys(description);
			Browser.Wait(By.Name("expected_result"));
			expectedResultsInput.SendKeys(expectedResults);
			Browser.Wait(By.Name("testStepId-0"));
			stepOneInput.SendKeys(stepOne);
			Browser.Wait(By.XPath("//button[@data-testid='submit_btn']"));
			submitButton.Click();
			Browser.WaitInSec(3);
		}

		public bool IsUseCaseCreated(string nameOfCreatedTC)
		{
			String[] allText = new String[listOfCreatedTC.Count];
			int i = 0;
			foreach (IWebElement element in listOfCreatedTC)
			{
				allText[i++] = element.Text;
			}

			return allText.Any(nameOfCreatedTC.Contains);
		}

		public void AddNewStep()
		{
			Browser.Wait(By.XPath("//a[@data-testid='create_use_case_btn']"));
			createUseCaseButton.Click();
			Browser.Wait(By.XPath("//span[@data-testid='add_step_btn']"));
			addStepButton.Click();
			Browser.Wait(By.Name("testStepId-1"));
		}

		public bool IsStepAdded()
		{
			return stepTwoInput.Displayed;
		}

		public void ReturnToUseCases(string baseUrl)
		{
			Browser.GoTo(baseUrl + "dashboard");
		}

		public void EditAndReplaceWithCount()
		{
			Browser.Wait(By.LinkText("TestCaseEdit"));
			editTestCase.Click();
			Browser.WaitInSec(3);
			string newTitle = Browser.CountChar(titleInput);
			titleInput.Clear();
			titleInput.SendKeys(newTitle);
			Browser.Wait(By.Name("description"));
			string newDescription = Browser.CountChar(descriptionInput);
			descriptionInput.Clear();
			descriptionInput.SendKeys(newDescription);
			Browser.Wait(By.Name("expected_result"));
			string newExpectedResults = Browser.CountChar(expectedResultsInput);
			expectedResultsInput.Clear();
			expectedResultsInput.SendKeys(newExpectedResults);
			Browser.Wait(By.Name("testStepId-0"));
			string newstepOne = Browser.CountChar(stepOneInput);
			stepOneInput.Clear();
			stepOneInput.SendKeys(newstepOne);
			Browser.Wait(By.XPath("//button[@data-testid='submit_btn']"));
			submitButton.Click();
			Browser.WaitInSec(3);
		}

		public void TurnOnAutomatedSwithcer()
		{
			Browser.Wait(By.XPath("//a[@data-testid='create_use_case_btn']"));
			createUseCaseButton.Click();
			Browser.Wait(By.XPath("//label[@for='switch']"));
			automatedSwitchButton.Click();
		}

		public bool IsAutomatedSwitchOn()
		{
			return automatedSwitchValue.GetAttribute("value") == "true";
		}

		public void TitleLenghtValidation(string titleForValidation, string expectedResults, string steOne)
		{
			Browser.Wait(By.XPath("//a[@data-testid='create_use_case_btn']"));
			createUseCaseButton.Click();
			Browser.Wait(By.Name("title"));
			titleInput.SendKeys(titleForValidation);
			expectedResultsInput.SendKeys(expectedResults);
			stepOneInput.SendKeys(steOne);
			Browser.Wait(By.XPath("//button[@data-testid='submit_btn']"));
			submitButton.Click();
			Browser.WaitInSec(1);
		}

		public bool IsTitleLenghtValidationShown()
		{
			return validationMessage.Text == "Title needs to be between 5 and 255";
		}

		public void TitleRequiredValidation(string expectedResutls, string stepOne)
		{
			Browser.Wait(By.XPath("//a[@data-testid='create_use_case_btn']"));
			createUseCaseButton.Click();
			Browser.Wait(By.Name("expected_result"));
			expectedResultsInput.SendKeys(expectedResutls);
			stepOneInput.SendKeys(stepOne);
			Browser.Wait(By.XPath("//button[@data-testid='submit_btn']"));
			submitButton.Click();
			Browser.WaitInSec(1);
		}
		public bool IsTitleRequiredValidationShown()
		{
			return validationMessage.Text == "Title is required";
		}
	}
}
