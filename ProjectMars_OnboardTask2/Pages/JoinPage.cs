using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_OnboardTask2.Pages
{
    using OpenQA.Selenium;
    using ProjectMars_OnboardTask2.Utilities;
    using Reqnroll.BindingSkeletons;

    public class JoinPage
    {
        private readonly IWebDriver _driver;

        public JoinPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // === XPath Locators ===
        private IWebElement FirstNameInput => _driver.FindElement(By.XPath("//input[@name='firstName']"));
        private IWebElement LastNameInput => _driver.FindElement(By.XPath("//input[@name='lastName']"));
        private IWebElement EmailInput => _driver.FindElement(By.XPath("//input[@name='email']"));
        private IWebElement PasswordInput => _driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement ReEnterPasswordInput => _driver.FindElement(By.XPath("//input[@name='confirmPassword']"));
        private IWebElement TermsCheckbox => _driver.FindElement(By.XPath("//input[@name='terms']"));
        private IWebElement JoinButton => _driver.FindElement(By.XPath("//div[@id='submit-btn']"));
        private IWebElement SuccessMessageElement => _driver.FindElement(By.XPath("//div[contains(text(), 'Registration successful')]"));

       
    
        public void EnterAccountDetails(string firstName, string lastName, string email, string password, string confirmPassword)
        {
            EnterNames(firstName, lastName);
            EnterEmail(email);
            EnterPassword(password);
            ReEnterPassword(confirmPassword);
        }

        public void EnterNames(string firstName, string lastName)
        {
            FirstNameInput.Clear();
            FirstNameInput.SendKeys(firstName);

            LastNameInput.Clear();
            LastNameInput.SendKeys(lastName);

        }
        public void TriggerNamesValidationError()
        {
            FirstNameInput.Clear();                 // Clear 
            FirstNameInput.SendKeys("A");          // Type a temporary character
            FirstNameInput.SendKeys(Keys.Backspace); //backspace to empty to trigger error

            LastNameInput.Clear();                 // Clear 
            LastNameInput.SendKeys("A");          // Type a temporary character
            LastNameInput.SendKeys(Keys.Backspace); //backspace to empty to trigger error
        }


        public void EnterEmail(string email)
        {
            EmailInput.Clear();
            EmailInput.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        }

        public void ReEnterPassword(string reEnterPassword)
        {
            ReEnterPasswordInput.Clear();
            ReEnterPasswordInput.SendKeys(reEnterPassword);
        }

        public void CheckAgreeToTerms()
        {
            if (!TermsCheckbox.Selected)
            {
                TermsCheckbox.Click();
            }
        }

        public void UncheckAgreeToTerms()
        {
            if (TermsCheckbox.Selected)
            {
                TermsCheckbox.Click();
            }
        }

        public void SubmitJoinForm()
        {
            JoinButton.Click();
        }

        public string GetSuccessMessage()
        {


            try
            {
                Wait.WaitToBeVisible(_driver, "XPath", "//div[contains(@class, 'ns-show')]", 10);
                string actualMessage = _driver.FindElement(By.XPath("//div[contains(@class, 'ns-show')]")).Text.Trim();
                return actualMessage;
            }
            catch (NoSuchElementException)
            {
                return "Error: Success message element not found.";
            }


        }

        public string GetErrorMessage(string fieldName)
        {

            try
            {

                string keyword = fieldName.ToLower() switch
                {
                    "name" => "name",
                    "email" => "email",
                    "password" => "password",
                    "reenterpassword" => "confirm",
                    "terms" => "terms",
                    _ => fieldName.ToLower()
                };


                //Wait for the prompt 
                Wait.WaitToBeVisible(_driver, "XPath", $"//div[contains(@class, 'prompt') and contains(text(), {keyword})]", 10);

                // Locate the prompt element containing the email error message
                string actualErrorMessage = _driver.FindElement(By.XPath($"//div[contains(@class, 'prompt') and contains(text(), {keyword})]")).Text.Trim();

                return actualErrorMessage;
            }
            catch (NoSuchElementException)
            {
                return "Error: Error message element not found.";
            }


        }

        public bool IsJoinButtonDisabled()
        {

            string classAttr = JoinButton.GetAttribute("class") ?? ""; // ??** ensures null gets empty to avoid NullReferenceException error 
            return classAttr.Contains("teal") || classAttr.Contains("gray"); 
        }

    }

}