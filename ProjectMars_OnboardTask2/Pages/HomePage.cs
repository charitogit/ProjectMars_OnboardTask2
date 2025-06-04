using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_OnboardTask2.Pages
{

    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement JoinButton => _driver.FindElement(By.XPath("//button[text()='Join']"));


        public void GoToHomePage()
        {
            _driver.Navigate().GoToUrl("http://localhost:5003/Home");
        }

        public void GoToSignInPage()
        {
            _driver.Navigate().GoToUrl("http://localhost:5003/");
            _driver.FindElement(By.XPath("//a[contains(text(), 'Sign In')]")).Click();

        }

        public void ClickJoinButton()
        {
            JoinButton.Click();
        }

        public void GotToProfileTab()
        {
            _driver.Navigate().GoToUrl("http://localhost:5003/Account/Profile");
        }

    }

}
