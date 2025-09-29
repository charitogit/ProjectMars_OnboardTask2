# ProjectMars_OnboardTask2

This is an automated test project built with **Reqnroll**, **Selenium WebDriver**, and **C#**. It covers essential user workflows in the Mars Onboard web application.

## ✅ Test Coverage

The following features are automated and tested:

- 🔐 **Sign-In**: Login functionality for existing users
- 📝 **Join**: User registration and validation scenarios
- 🌐 **Manage Language**: Add, edit, delete language entries under Profile
- 💼 **Manage Skills**: Add, edit, delete skill entries under Profile

## 🛠 Technologies Used

- **C#** : Programming Language used
- **Visual Studio**:Primary IDE for development 
- **Reqnroll** (SpecFlow fork): Implements BDD-style tests using Gherkin syntax  
- **Selenium WebDriver**: Handles browser interactions
- **NUnit**: Manages test execution and assertions
- **Page Object Model (POM)**: Separates test logic from page interactions

## 🧪 How to Run Tests

1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```

2. Open the solution in **Visual Studio**.

3. Make sure the local Mars app is running on `http://localhost:5003/`.

4. Build the project.

5. Run the tests via Test Explorer.

## 📂 Folder Structure

- `Features/` – Gherkin feature files
- `StepDefinitions/` – Step definitions linked to features
- `Pages/` – Page Object Models for test interaction
- `Utilities/` – Wait helpers and assertion utilities

## 🧾 Sample Test Scenario (Join.feature)

```gherkin
Feature: Join

As a user of Project Mars, I want to join by creating my account
so I can sign in and manage my skills and languages in my profile
and make them available to viewers and recruiters.

@positive
Scenario Outline: Create new account with valid credentials
  Given I am on the home page
  When I click the Join button
  And I enter valid account details "<FirstName>" "<LastName>" "<Email>" "<Password>" "<ReenterPassword>"
  And I check the I agree to the licensing terms checkbox
  And I click the Join button to submit
  Then I should see the successful "<message>"
    
 
Examples:
  |TestCaseID | FirstName | LastName | Email                  | Password  | ReenterPassword | message                                                |
  |TC004      | John      | Smith    | JohnSmith004@yahoo.com |  JohnP@ssw0rd |  JohnP@ssw0rd    |Registration successful, Please verify your email! |


