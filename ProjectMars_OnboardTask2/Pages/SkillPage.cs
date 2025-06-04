using OpenQA.Selenium;
using ProjectMars_OnboardTask2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_OnboardTask2.Pages
{
    public class SkillPage
    {

        private readonly IWebDriver _driver;

        public SkillPage(IWebDriver driver)
        {
            _driver = driver;   
        }

        public void GoToSkillTab()
        {
            // Wait and click the "skills" tab
            string tabXPath = "//*[@id='account-profile-section']//a[contains(text(),'Skills')]";
            Wait.WaitToBeVisible(_driver, "XPath", tabXPath, 10);
            _driver.FindElement(By.XPath(tabXPath)).Click();

            
        }
        public void AddSkillRecord(string skill, string level)
        {

            // Wait for the Skills section to be active
            string activeTabContentXPath = "//div[@data-tab='second' and contains(@class, 'active')]";
            Wait.WaitToBeVisible(_driver, "XPath", activeTabContentXPath, 10);

            // Click "Add New" inside the Skills section
            string addNewSkillButtonXPath = $"{activeTabContentXPath}//div[text()='Add New']";
            Wait.WaitToBeClickable(_driver, "XPath", addNewSkillButtonXPath, 10);
            _driver.FindElement(By.XPath(addNewSkillButtonXPath)).Click();

            // Enter skill
            string skillInputXPath = "//input[@name='name']";
            Wait.WaitToBeVisible(_driver, "XPath", skillInputXPath, 10);
            _driver.FindElement(By.XPath(skillInputXPath)).SendKeys(skill);

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

        public void EditSkillRecord(string skillOld, string skillNew, string levelOld, string levelNew)
        {

            // Wait for the Skills tab content to become active
            string activeTabContentXPath = "//div[@data-tab='second' and contains(@class, 'active')]";
            Wait.WaitToBeVisible(_driver, "XPath", activeTabContentXPath, 10);

            // XPath for the edit button within the active section
            string editButtonXPath = $"{activeTabContentXPath}//table/tbody/tr[td[1][normalize-space()='{skillOld}'] and td[2][normalize-space()='{levelOld}']]//i[@class='outline write icon']";

            // Wait and click the edit button of matching skill and level
            Wait.WaitToBeClickable(_driver, "XPath", editButtonXPath, 10);
            _driver.FindElement(By.XPath(editButtonXPath)).Click();


            // Wait for the skill input field, then clear and enter new value
            string skillInputXpath = "//input[@name='name']";
            Wait.WaitToBeVisible(_driver, "XPath", skillInputXpath, 10);
            var skillInput = _driver.FindElement(By.XPath(skillInputXpath));
            skillInput.Click();
            skillInput.SendKeys(Keys.Control + "a");
            skillInput.SendKeys(Keys.Delete);
            skillInput.SendKeys(skillNew);

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

        public void DeleteSkillRecord(string skill, string level)
        {
            //  Click  "Skills" tab
            string tabXPath = "//*[@id='account-profile-section']//a[contains(text(),'Skills')]";
            Wait.WaitToBeVisible(_driver, "XPath", tabXPath, 10);
            _driver.FindElement(By.XPath(tabXPath)).Click();

            //Wait Skills tab content to become active
            string activeTabContentXPath = "//div[@data-tab='second' and contains(@class, 'active')]";
            Wait.WaitToBeVisible(_driver, "XPath", activeTabContentXPath, 10);

            // BuildXPath for the delete button in the matching skill row
            string deleteButtonXPath = $"{activeTabContentXPath}//table/tbody/tr[td[1][normalize-space()='{skill}'] and td[2][normalize-space()='{level}']]//i[@class='remove icon']";

            // Wait  and click  delete button
            Wait.WaitToBeClickable(_driver, "XPath", deleteButtonXPath, 10);
            _driver.FindElement(By.XPath(deleteButtonXPath)).Click();
        }

        
    }
}
