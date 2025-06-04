using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Log;
using OpenQA.Selenium.DevTools.V134.Runtime;
using ProjectMars_OnboardTask2.Pages;
using ProjectMars_OnboardTask2.Utilities;
using Reqnroll;
using System;
using System.Reflection.Emit;

namespace ProjectMars_OnboardTask2.Steps
{
    [Binding]
    public class LanguageStepDefinitions 
    {
        private readonly IWebDriver _driver; 
        private readonly HomePage _homePage;
        private readonly SignInPage _signInPage;
        private readonly LanguagePage _languagePage;  
        private readonly RecordAssertions _assertRecord;  
        
        public LanguageStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _homePage = new HomePage(_driver); 
            _signInPage = new SignInPage(_driver);  
            _languagePage = new LanguagePage(_driver);
            _assertRecord = new RecordAssertions(_driver); 

        }

        [Given("I am successfuly signed in")]
        public void GivenIAmSuccessfulySignedIn()
        {
            _homePage.GoToSignInPage();
            
            
        }


        [Given("I am in the Language section of my profile")]
        public void GivenIAmInTheLanguageSectionOfMyProfile()
        {
           _languagePage.GoToLanguageTab();
        }

        [When("I add {string} and {string}")]
        public void WhenIAddAnd(string language, string level)
        {
            _languagePage.AddLanguageRecord(language, level);
        }


      

       

        [Then("successful added {string} {string} should be displayed")]
        public void ThenSuccessfulAddedShouldBeDisplayed(string language, string message)
        {
            Assert.That(_assertRecord.IsSuccessfulMessageShown(language, message), "Test Failed: Expected successful add message not shown.");
        }



        [Then("{string} and {string} should appear in my language list")]
        public void ThenAndShouldAppearInMyLanguageList(string language, string level)
        {
            Assert.That(_assertRecord.IsRecordPresent(language, level), "Test Failed: Record is not added. ");
        }



        [Then("an error {string} should be displayed")]
        public void ThenAnErrorShouldBeDisplayed(string message)
        {
    
            Assert.That(_assertRecord.IsErrorMessageShown(message), "Expected error message was not shown.");
        }
        


        [Given("I verify the language {string} with level {string} exists")]
        public void GivenIVerifyTheLanguageWithLevelExists(string language, string level)
        {
            Assert.That(_assertRecord.IsRecordPresent(language, level), "Original language record was not found.");
        
        }


        [When("I edit {string} to {string} and\\/or {string} to {string}")]
        public void WhenIEditToAndOrTo(string languageOld, string languageNew, string levelOld, string levelNew)
        {
            _languagePage.EditLanguageRecord(languageOld, languageNew, levelOld, levelNew); 
        }

        [Then("updated {string} and\\/or {string} should be shown  in the list")]
        public void ThenUpdatedAndOrShouldBeShownInTheList(string language, string level)
        {
           Assert.That(_assertRecord.IsRecordPresent(language, level),"Test Failed: Updated Record is not found."); 
        }

       
         
        [Then("successful update message {string} {string} should appear")]
        public void ThenSuccessfulUpdateMessageShouldAppear(string language, string message)
        {
            Assert.That(_assertRecord.IsSuccessfulMessageShown(language, message), "Test Failed: Expected successful updated message not shown.");
        }


        [When("I delete existing  {string} with {string} record")]
        public void WhenIDeleteExistingWithRecord(string language, string level)
        {
            _languagePage.DeleteLanguageRecord(language, level); 
        }

        [Then("successful deleted {string}  {string} should be displayed")]
        public void ThenSuccessfulDeletedShouldBeDisplayed(string language, string message)
        {
            _assertRecord.IsSuccessfulMessageShown(language, message);
        }

        [Then("{string} with {string} record should be removed from the list")]
        public void ThenWithRecordShouldBeRemovedFromTheList(string language, string level)
        {
            bool recordPresent= _assertRecord.IsRecordPresent(language, level);
            Assert.That(recordPresent, Is.False, $"The language record '{language}' with level '{level}' should be deleted but still exists.");

        }

    }
}
