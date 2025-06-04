using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_OnboardTask2.Utilities
{

    public class RecordAssertions
    {

        private readonly IWebDriver _driver;


        public RecordAssertions(IWebDriver driver)
        {
            _driver = driver;
        }


        public bool IsRecordPresent(string name, string level)
        {
            string xPath = $"//table/tbody/tr[td[1][normalize-space()='{name}'] and td[2][normalize-space()='{level}']]";
            return _driver.FindElements(By.XPath(xPath)).Count > 0;
        }

        public bool IsSuccessfulMessageShown(string name, string message)
        {
            try
            {
             
                Wait.WaitToBeVisible(_driver, "XPath", "//div[contains(@class, 'ns-show')]", 10);
                string actualMessage = _driver.FindElement(By.XPath("//div[contains(@class, 'ns-show')]")).Text.Trim();
                string expectedMessage = $"{name} {message}".Trim();

                return actualMessage.Equals(expectedMessage, StringComparison.OrdinalIgnoreCase);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }

        public bool IsErrorMessageShown(string expectedMessage)
        {
            try
            {
                Wait.WaitToBeVisible(_driver, "XPath", "//div[contains(@class, 'ns-show')]", 10);
                string actualMessage = _driver.FindElement(By.XPath("//div[contains(@class, 'ns-show')]")).Text.Trim();
                return actualMessage.Equals(expectedMessage, StringComparison.OrdinalIgnoreCase);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }



    }
}
