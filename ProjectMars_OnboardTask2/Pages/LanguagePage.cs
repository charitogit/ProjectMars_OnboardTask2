using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Log;
using ProjectMars_OnboardTask2.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_OnboardTask2.Pages
{
    public class LanguagePage
    {

        private readonly IWebDriver _driver;

        public LanguagePage(IWebDriver driver)
        {
            _driver = driver; 

        }

        public void GoToLanguageTab()
        {
            // Wait and click the "Languages" tab
            string tabXPath = "//*[@id='account-profile-section']//a[contains(text(),'Languages')]";
            Wait.WaitToBeVisible(_driver, "XPath", tabXPath, 10);
            _driver.FindElement(By.XPath(tabXPath)).Click();
        }

       
        public void AddLanguageRecord(string language, string level)
        {
    
            // Click "Add New" button in Language section
            Wait.WaitToBeClickable(_driver, "XPath", "//table/thead/tr/th/div[text()='Add New']", 10);
            _driver.FindElement(By.XPath("//table/thead/tr/th/div[text()='Add New']")).Click();

            // Enter language
            string languageInputXPath = "//input[@name='name']";
            Wait.WaitToBeVisible(_driver, "XPath", languageInputXPath, 10);
            _driver.FindElement(By.XPath(languageInputXPath)).SendKeys(language);

            // Select level from dropdown
            string levelDropdownXPath = "//select[@name='level']";
            Wait.WaitToBeClickable(_driver, "XPath", levelDropdownXPath, 10);
            _driver.FindElement(By.XPath(levelDropdownXPath)).Click();

            string levelOptionXPath = $"//select[@name='level']/option[normalize-space()='{level}']";
            _driver.FindElement(By.XPath(levelOptionXPath)).Click();

            // Click Add button
            string addButtonXPath = "//input[@value='Add' and @type='button']";
            Wait.WaitToBeClickable(_driver, "XPath", addButtonXPath, 10);
            _driver.FindElement(By.XPath(addButtonXPath)).Click();


        }

        public void EditLanguageRecord(string languageOld, string languageNew, string levelOld, string levelNew)
        {
            // Click on Edit button for the matching language and level
            string editButtonXpath = $"//table/tbody/tr[td[1][normalize-space()='{languageOld}'] and td[2][normalize-space()='{levelOld}']]//i[@class='outline write icon']";
            var editButton = _driver.FindElement(By.XPath(editButtonXpath));
            editButton.Click();

            // Wait for the language input field, then clear and enter new value
            string languageInputXpath = "//input[@name='name']";
            Wait.WaitToBeVisible(_driver, "XPath", languageInputXpath, 10);
            var languageInput = _driver.FindElement(By.XPath(languageInputXpath));
            languageInput.Click();
            languageInput.SendKeys(Keys.Control + "a");
            languageInput.SendKeys(Keys.Delete);
            languageInput.SendKeys(languageNew); 

            // Select new level from dropdown
            string levelDropdownXpath = "//select[@name='level']";
            Wait.WaitToBeClickable(_driver, "XPath", levelDropdownXpath, 10);
            var levelDropdown = _driver.FindElement(By.XPath(levelDropdownXpath));
            levelDropdown.Click();

            var levelOptionXpath = $"//select[@name='level']/option[normalize-space()='{levelNew}']";
            _driver.FindElement(By.XPath(levelOptionXpath)).Click();

            // Click on the Update button within the same editing form
            string updateButtonXpath = "//input[@value='Update' and @type='button']";
            Wait.WaitToBeClickable(_driver, "XPath", updateButtonXpath, 10);
            var updateButton = _driver.FindElement(By.XPath(updateButtonXpath));
            updateButton.Click();
        }

        public bool IsLanguageRecordEmpty()
        {
            // Locate all rows inside the tbody of the table
            var rows = _driver.FindElements(By.XPath("//table/tbody/tr"));

            // Return true if no rows are found 
            return rows.Count == 0;
        }
        public void DeleteAllLanguages()
        {
           // GoToLanguageTab();

            string rowsXPath = "//table[@class='ui fixed table']/tbody/tr";
            var rows = _driver.FindElements(By.XPath(rowsXPath));

            while (rows.Count > 0)
            {
                var deleteButton = rows[0].FindElement(By.XPath(".//i[@class='remove icon']"));
                deleteButton.Click();
                Wait.WaitToBeVisible(_driver, "XPath", "//div[contains(@class,'ns-show')]", 5); // Wait for toast
                //Wait.WaitForElementToDisappear(_driver, "XPath", rowsXPath, 10);
                rows = _driver.FindElements(By.XPath(rowsXPath));
            }
        }
 
     
        public void DeleteLanguageIfExists(string language, string level)
        {
            try
            {
                GoToLanguageTab();

                string activeTabContentXPath = "//div[@data-tab='first' and contains(@class, 'active')]";
                string deleteButtonXPath = $"{activeTabContentXPath}//table/tbody/tr[td[1][normalize-space()='{language}'] and td[2][normalize-space()='{level}']]//i[@class='remove icon']";

                var deleteButtons = _driver.FindElements(By.XPath(deleteButtonXPath));
                if (deleteButtons.Count > 0)
                {
                    Wait.WaitToBeClickable(_driver, "XPath", deleteButtonXPath, 5);
                    deleteButtons[0].Click();

                    Console.WriteLine($"[Cleanup] Deleted language: {language}, Level: {level}");
                }
                else
                {
                    Console.WriteLine($"[Cleanup] No record found for: {language}, Level: {level}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Cleanup] ERROR deleting language (safe): " + ex.Message);
            }
        }

        

    }
}
