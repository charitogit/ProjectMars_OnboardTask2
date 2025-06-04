using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Log;
using ProjectMars_OnboardTask2.Pages;
using ProjectMars_OnboardTask2.Utilities;
using Reqnroll;
using System;


namespace ProjectMars_OnboardTask2.Steps
{
    [Binding]
    public class SkillStepDefinitions
    {
        private readonly IWebDriver _driver;
        private readonly SignInPage _signInPage;
        private readonly SkillPage _skillPage;
        private readonly RecordAssertions _assertRecord;

        public SkillStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _signInPage = new SignInPage(_driver);
            _skillPage = new SkillPage(_driver);
            _assertRecord = new RecordAssertions(_driver);
        }


     
        [Given("I am in the skill section of my profile")]
        public void GivenIAmInTheSkillSectionOfMyProfile()
        {
            _skillPage.GoToSkillTab();
        }


        [When("I add new {string} and {string}")]
        public void WhenIAddNewAnd(string skill, string level)
        {
            _skillPage.AddSkillRecord(skill, level);
        }

        [Then("successful add {string} {string} should be displayed")]
        public void ThenSuccessfulAddShouldBeDisplayed(string skill, string message)
        {
           _assertRecord.IsSuccessfulMessageShown(skill,message);
        }

        [Then("{string} and {string} should appear in my skill list")]
        public void ThenAndShouldAppearInMySkillList(string skill   , string level)
        {
           _assertRecord.IsRecordPresent(skill, level);
        }


        [Given("I verify the skill {string} with level {string} exists")]
        public void GivenIVerifyTheSkillWithLevelExists(string skill, string level)
        {
            _assertRecord.IsRecordPresent(skill,level);
        }

        [When("I edit {string} to {string} and {string} to {string}")]
        public void WhenIEditToAndTo(string oldSkill, string newSkill, string oldLevel, string newLevel)
        {
           _skillPage.EditSkillRecord(oldSkill, newSkill, oldLevel, newLevel);    
        }

        [Then("successful update message {string} {string} should be displayed")]
        public void ThenSuccessfulUpdateMessageShouldBeDisplayed(string skill, string message)
        {
            _assertRecord.IsSuccessfulMessageShown(skill,message);
             
           
              
        }



        [Then("updated {string} and {string} should be shown  in the list")]
        public void ThenUpdatedAndShouldBeShownInTheList(string skill, string level)
        {
            _assertRecord.IsRecordPresent(skill, level); 


        }


       
        [When("I delete the existing  {string} with {string} record")]
        public void WhenIDeleteTheExistingWithRecord(string skill, string level)
        {
            _skillPage.DeleteSkillRecord(skill, level);
        }

        [Then("successful deletion  {string}  {string} should be displayed")]
        public void ThenSuccessfulDeletionShouldBeDisplayed(string skill, string message)
        {
            _assertRecord.IsSuccessfulMessageShown(skill,message);
        }

        [Then("the {string} with {string} record should be removed from the list")]
        public void ThenTheWithRecordShouldBeRemovedFromTheList(string skill, string level)
        {
             
            bool recordPresent = _assertRecord.IsRecordPresent(skill, level);
            Assert.That(recordPresent, Is.False, $"The skill record '{skill}' with level '{level}' should be deleted but it still exists.");

        }











    }
}
