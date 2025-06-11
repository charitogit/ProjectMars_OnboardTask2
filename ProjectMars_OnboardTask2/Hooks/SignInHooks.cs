using NUnit.Framework;
using OpenQA.Selenium;
using ProjectMars_OnboardTask2.Pages;
using Reqnroll;
using Reqnroll.BoDi;

namespace ProjectMars_OnboardTask2.Hooks
{
    [Binding]
    public sealed class SignInHooks
    {
        private readonly IWebDriver _driver;
        private readonly SignInPage _signInPage;
        private readonly HomePage _homePage; 

        public SignInHooks(IObjectContainer container)
        {
            _driver = container.Resolve<IWebDriver>();
            _homePage = new HomePage(_driver); 
            _signInPage = new SignInPage(_driver);
        }

        [BeforeScenario("@RequiresSignIn", Order = 1) ]
        public void SignInBeforeScenario()
        {

            _homePage.GoToSignInPage();
            _signInPage.SignInSteps("charie_artz@yahoo.com", "P@ssw0rd");
    

        }

        
    }
}