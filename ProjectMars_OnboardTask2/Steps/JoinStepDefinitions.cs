using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V134.PerformanceTimeline;
using ProjectMars_OnboardTask2.Pages;
using Reqnroll;

namespace ProjectMars_OnboardTask2.Steps
{
    [Binding]
    public class JoinStepDefinitions
    {

        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;
        private readonly JoinPage _joinPage;
        private readonly SignInPage _signInPage;

            public JoinStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _homePage = new HomePage(_driver);
            _joinPage =new JoinPage(_driver);
            _signInPage = new SignInPage(_driver);
        }
       
        [Given("I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            _homePage.GoToHomePage();
        }


        [When("I click the Join button")]
        public void WhenIClickTheJoinButton()
        {
            _homePage.ClickJoinButton();
        }


        [When("I enter valid account details {string} {string} {string} {string} {string}")]
        public void WhenIEnterValidAccountDetails(string firstName, string lastName, string email, string password, string reenterPassword)
        {
           _joinPage.EnterAccountDetails(firstName,lastName,email,password,reenterPassword);
        }


 

        [When("I type an invalid numeric {string} and {string}")]
        public void WhenITypeAnInvalidNumericAnd(string firstName, string lastName)
        {
            _joinPage.EnterNames(firstName, lastName);
        }

        [When("I type empty first name and empty last name")]
        public void WhenITypeEmptyFirstNameAndEmptyLastName()
        {
            _joinPage.TriggerNamesValidationError(); 
        }



        [When("I type an invalid email {string}")]
        public void WhenITypeAnInvalidEmail(string email)
        {
            _joinPage.EnterEmail(email);
        }


        [When("I type an invalid password {string}")]
        public void WhenITypeAnInvalidPassword(string password)
        {
            _joinPage.EnterPassword(password); 
        }

        [When("I type {string} as password and retype  {string} as confirm password")]
        public void WhenITypeAsPasswordAndRetypeAsConfirmPassword(string password, string reEnterPasssword)
        {
            _joinPage.EnterPassword(password);
            _joinPage.ReEnterPassword(reEnterPasssword);
        }



        [When("I check the I agree to the licensing terms checkbox")]
        public void WhenICheckTheIAgreeToTheLicensingTermsCheckbox()
        {
            _joinPage.CheckAgreeToTerms();
        }

        [When("uncheck the I agree to the licensing terms checkbox")]
        public void WhenUncheckTheIAgreeToTheLicensingTermsCheckbox()
        {
            _joinPage.CheckAgreeToTerms();
            _joinPage.UncheckAgreeToTerms(); //to trigger mandatory error
        }

        [When("I click the Join button to submit")]
        public void WhenIClickTheJoinButtonToSubmit()
        {
            _joinPage.SubmitJoinForm(); 
        }

        [Then("I should see the successful {string}")]
        public void ThenIShouldSeeTheSuccessful(string expectedMessage)
        {
           string actualMessage= _joinPage.GetSuccessMessage();
            Assert.That(expectedMessage == actualMessage, "Test failed: message shown not expected"); 
        }

        [Then("I should see the {string}  error message {string}")]
        public void ThenIShouldSeeTheErrorMessage(string fieldName, string expectedErrorMessage)
        {
            string actualMessage = (_joinPage.GetErrorMessage(fieldName));
            Assert.That(expectedErrorMessage == actualMessage, "Test Failed: expected error message not shown");
        }

        [Then("Join button is disabled")]
        public void ThenJoinButtonIsDisabled()
        {
          
            Assert.That(_joinPage.IsJoinButtonDisabled(), Is.True, "Join button is not disabled. ");
        }


        [When("I try to open the Profile tab without logging in")]
        public void WhenITryToOpenTheProfileTabWithoutLoggingIn()
        {
            _homePage.GotToProfileTab();
        }

        [Then("I should be redirected to the Sign In page")]
        public void ThenIShouldBeRedirectedToTheSignInPage()
        {
            _homePage.GoToSignInPage();
        }

        [Then("I should see the Sign In form")]
        public void ThenIShouldSeeTheSignInForm()
        {
            Assert.That(_signInPage.IsSignInFormVisible(), Is.True, "Sign In form is not visible.");
        }

    }
}
