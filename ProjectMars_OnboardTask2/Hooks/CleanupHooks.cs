using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Log;
using ProjectMars_OnboardTask2.Pages;
using Reqnroll;
using Reqnroll.BoDi;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection.Emit;

namespace ProjectMars_OnboardTask2.Hooks
{
    [Binding]
    public class CleanupHooks
    {
        private readonly IWebDriver _driver;
        private readonly LanguagePage _languagePage;
        private readonly SkillPage _skillPage;

        public CleanupHooks(IObjectContainer container)
        {
            _driver = container.Resolve<IWebDriver>();
            _languagePage = new LanguagePage(_driver);
            _skillPage = new SkillPage(_driver);
        }

        // CLEANUP: Delete all Language records before Language scenarios
        [BeforeScenario("LanguageCleanup", Order = 2)]
        public void DeleteAllLanguagesBefore()
        {
            try
            {

                _languagePage.GoToLanguageTab();
                _languagePage.DeleteAllLanguages();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[BeforeScenario Language Cleanup ERROR] " + ex.Message);
            }
        }

        // CLEANUP: Delete all Skill records before Skill scenarios
        [BeforeScenario("SkillCleanup", Order = 2)]
        public void DeleteAllSkillsBefore()
        {
            try
            {
                _skillPage.GoToSkillTab();
                _skillPage.DeleteAllSkills();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[BeforeScenario Skills Cleanup ERROR] " + ex.Message);
            }
        }

        // CLEANUP: Delete test language data only after test
        [AfterScenario("LanguageCleanup", Order = 0) ]
        public void DeleteLanguageTestDataAfter()
        {
         

            try
            {
                _driver.Navigate().Refresh();
                _languagePage.GoToLanguageTab();

                //TC022,TC035
                _languagePage.DeleteLanguageIfExists("English", "Fluent");  
                _languagePage.DeleteLanguageIfExists("Tagalog", "Fluent");

                _languagePage.DeleteLanguageIfExists("", "Basic"); //TC023
                _languagePage.DeleteLanguageIfExists("French", "Choose Language Level"); //TC024

                //TC028
                _languagePage.DeleteLanguageIfExists("French", "Basic");
                
                //TC029
                _languagePage.DeleteLanguageIfExists("French", "Fluent");
                //TC029,TC0031,TC032
                _languagePage.DeleteLanguageIfExists("Tagalog", "Native/Bilingual");



            }
            catch (Exception ex)
            {
                Console.WriteLine("[AfterScenario Language Cleanup ERROR] " + ex.Message);
            }
        }

        // CLEANUP: Delete test skill data only after test
        [AfterScenario("SkillCleanup", Order = 0), ]
        public void DeleteSkillTestDataAfter()
        {
            try
            {
                _driver.Navigate().Refresh();
                _skillPage.GoToSkillTab();

                //TC036, TC039,TC046,TC050 , TC044
                _skillPage.DeleteSkillIfExists("Communication", "Intermediate");
                //TC036 ,TC045
                _skillPage.DeleteSkillIfExists("Writing", "Expert");
                //TC037 
                _skillPage.DeleteSkillIfExists("", "Beginner");
                //TC038 
                _skillPage.DeleteSkillIfExists("Cooking", "Choose Skill Level");
                //TC040
               _skillPage.DeleteSkillIfExists("Communication", "Beginner");
                //TC043,TC046
                _skillPage.DeleteSkillIfExists("Technical Writing", "Expert");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[AfterScenario Skill Cleanup ERROR] " + ex.Message);
            }
        }
    }
}