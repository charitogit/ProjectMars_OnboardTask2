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
  |TestCaseID | FirstName | LastName | Email                  | Password  | ReenterPassword | message                                           |
  |TC004      | John      | Smith    | JohnSmith004@yahoo.com  |  JohnP@ssw0rd |  JohnP@ssw0rd    |Registration successful, Please verify your email! |


   
  @positive
Scenario Outline: Check if newly created user can sign in after successfully joining
  Given I am on the home page
  When I click the Join button
  And I enter valid account details "<FirstName>" "<LastName>" "<Email>" "<Password>" "<ReenterPassword>"
  And I check the I agree to the licensing terms checkbox
  And I click the Join button to submit
  Then I should see the successful "Registration successful, Please verify your email!" 

  Given I am in the sign in page
  When I enter valid "<Email>" and valid "<Password>"
  Then I should see my profile page with greeting "Hi John"

Examples:
  | TestCaseID | FirstName | LastName | Email                    | Password  | ReenterPassword |
  | TC005      | John    | Smith      | JohnSmith05@yahoo.com   | JohnP@ssw0rd | JohnP@ssw0rd       |

  @negative @TC007
Scenario: Redirect to Sign-In page when accessing the Profile link without first logging-in
  Given I am on the home page
  When I try to open the Profile tab without logging in
  Then I should be redirected to the Sign In page
  And I should see the Sign In form

   @negative
  Scenario Outline: Prevent account creation when email address is already existing
    Given I am on the home page
    When I click the Join button
    And I enter valid account details "<FirstName>" "<LastName>" "<Email>" "<Password>" "<ReenterPassword>"
    And  I check the I agree to the licensing terms checkbox
    And I click the Join button to submit
    Then  I should see the "email"  error message "<EmailError>"
    And Join button is disabled

  Examples:    
   | TestCaseID | FirstName | LastName | Email               | Password     | ReenterPassword |EmailError                          |
   | TC015      | John      | Smith    | JohnSmith@yahoo.com | JohnP@ssw0rd | JohnP@ssw0rd    | This email has already been used to register an account. |

  @negative
  Scenario Outline: Show password validation error
    Given I am on the home page
    When I click the Join button
    And I type an invalid password "<Password>"
    Then I should see the "password"  error message "<PasswordError>"

    Examples:
       |TestCaseID | Password | PasswordError                           |
       |TC016      | 1234    | Password must be at least 6 characters. |
      

       @negative
  Scenario Outline: Show first names and last name numeric validation error
    Given I am on the home page
    When I click the Join button
    And I type an invalid numeric "<FirstName>" and "<LastName>"
    Then I should see the "name"  error message "<ErrorMessage>"

    Examples:
       |TestCaseID | FirstName | LastName | ErrorMessage                           |
       |TC017      | 111       |111        | Names must contain at least one letter |
   
 
    @negative 
  Scenario Outline: Show first names and last name null validation error
    Given I am on the home page
    When I click the Join button
    And I type empty first name and empty last name
    Then I should see the "name"  error message "<ErrorMessage>"
     
     Examples:
     |TestCaseID | ErrorMessage       |
     |TC018    | This is a required field. |
     
      @negative
  Scenario Outline: Show email format validation error
    Given I am on the home page
    When I click the Join button
    And I type an invalid email "<Email>"
    Then I should see the "email"  error message "<EmailError>"

    Examples:
      |TestCaseID  | Email        | EmailError                          |
      |TC019       | johnsmith.com | Please enter a valid email address. |

   @negative  
  Scenario: Show password and reenter password mismatched validation error
    Given I am on the home page
    When I click the Join button
    And I type "<Password>" as password and retype  "<ReEnterPassword>" as confirm password
    Then I should see the "reeenterpassword"  error message "<ErrorMessage>"
   
     Examples:
     | TestCaseID | Password | ReEnterPassword | ErrorMessage             |
     | TC020      | P@ssw0rd | qwert1234       | Does not match password. |
        
   @negative
  Scenario Outline: Prevent account creation when 'I agree to the terms and conditions' is not selected
    Given I am on the home page
    When I click the Join button
    And I enter valid account details "<FirstName>" "<LastName>" "<Email>" "<Password>" "<ReenterPassword>"
    And uncheck the I agree to the licensing terms checkbox
    Then  I should see the "terms"  error message "<ErrorMessage>"
    And Join button is disabled

  Examples:    
   | TestCaseID | FirstName | LastName | Email               | Password     | ReenterPassword | ErrorMessage                                |
   | TC021      | John      | Smith    | JohnSmith@yahoo.com | JohnP@ssw0rd | JohnP@ssw0rd    | You must agree to the terms and conditions. |