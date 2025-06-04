Feature: Skill

A short summary of the feature

As a user I would like to add,edit and delete skills I know in a list
so I can showcase them under my profile page.


Background: I am successfully signed in 
	Given I am in the sign in page
	When I enter valid "charie_artz@yahoo.com" and valid "P@ssw0rd"
	Then I should see my profile page with greeting "Hi Charito"
	
@positive
Scenario Outline: Add new skill with valid details
	Given  I am in the skill section of my profile  
	When   I add new "<skill>" and "<level>"    
	Then  successful add "<skill>" "<message>" should be displayed
	And   "<skill>" and "<level>" should appear in my skill list
	
Examples: 
|testCaseID  | skill		  |  level				| message					 |
|TC036		 | Communication  |  Intermediate		|has been added to your skills| 
|TC036		 | Writing		  |  Expert				|has been added to your skills| 


@negative
Scenario Outline: Add new skill with invalid details
Given I am in the skill section of my profile
When  I add new "<skill>" and "<level>"  
Then  an error "<message>" should appear       

Examples: 
| testCaseID | skill         | level				 | message                      |
| TC037      |               | Beginner				 | Please enter skill and experience level |
| TC038      | Cooking       | Choose Skill Level	 | Please enter skill and experience level |
| TC039      | Communication | Intermediate			 | This skill is already exist in your skill list.|
| TC040      | Communication | Beginner				 | Duplicated data			|

	

@positive
Scenario Outline: Edit skill record with valid details
Given I am in the skill section of my profile
And I verify the skill "<skillOld>" with level "<levelOld>" exists   
When I edit "<skillOld>" to "<skillNew>" and "<levelOld>" to "<levelNew>" 
Then successful update message "<skillNew>" "<message>" should be displayed
And  updated "<skillNew>" and "<levelNew>" should be shown  in the list 

Examples: 
|testCaseID  | skillOld	   | skillNew			 |   levelOld	|  levelNew	| message						    |
|TC043		 | Writing	   |  Technical Writing	 |    Expert	|  Expert	| has been updated to your skills| 

@negative

Scenario Outline: Edit skill record with invalid details
Given I am in the skill section of my profile
And I verify the skill "<skillOld>" with level "<levelOld>" exists  
When I edit "<skillOld>" to "<skillNew>" and "<levelOld>" to "<levelNew>"
Then an error "<message>" should be displayed 

Examples: 
|testCaseID  | skillOld			   | skillNew			 |  levelOld			|  levelNew				| message											|
|TC044		 | Communication	   |					 |  Intermediate		|  Expert				| Please enter skill and experience level			| 
|TC045		 | Communication	   |  Public Speaking	 |  Intermediate		|  Skill Level	     	| Please enter skill and experience level			| 
|TC046		 | Communication	   |  Technical Writing	 |  Intermediate		|  Expert				| This skill is already added to your skill list.	| 


Scenario Outline: Delete skill record 
Given I am in the skill section of my profile
And I verify the skill "<skill>" with level "<level>" exists  
When  I delete the existing  "<skill>" with "<level>" record
Then successful deletion  "<skill>"  "<message>" should be displayed 
And  the "<skill>" with "<level>" record should be removed from the list 

Examples: 
|testCaseID  | skill		    |  level			|message|
|TC050		 | Communication	| Intermediate		|has been deleted| 
