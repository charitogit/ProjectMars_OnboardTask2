Feature: Skill

A short summary of the feature

As a user I would like to add,edit and delete skills I know in a list
so I can showcase them under my profile page.
	
@positive @SkillCleanup @RequiresSignIn
Scenario Outline: Add new skill with valid details
	Given  I am in the skill section of my profile  
	When   I add new "<skill>" and "<level>"    
	Then  successful add "<skill>" "<message>" should be displayed
	And   "<skill>" and "<level>" should appear in my skill list
	
Examples: 
|testCaseID  | skill		  |  level				| message					 |
|TC036		 | Communication  |  Intermediate		|has been added to your skills| 
|TC036		 | Writing		  |  Expert				|has been added to your skills| 


@negative @SkillCleanup @RequiresSignIn
Scenario Outline: Add new skill with invalid detail format
Given I am in the skill section of my profile
When  I add new "<skill>" and "<level>"  
Then  an invalid "<message>" should appear       

Examples: 
| testCaseID | skill         | level				 | message                               |
| TC037      |               | Beginner				 | Please enter skill and experience level |
| TC038      | Cooking       | Choose Skill Level	 | Please enter skill and experience level |


@negative @SkillCleanup @RequiresSignIn
Scenario Outline: Add duplicate skill record
Given I am in the skill section of my profile
When  I successfully add new "<skill>" and "<level>"  
And   I recreate same skill record "<skill>" and "<level>"
Then  a duplicate error "<message>" should appear   

Examples: 
| testCaseID | skill         | level				 | message                      |
| TC039      | Communication | Intermediate			 | This skill is already exist in your skill list.|
 

@TC040 @negative @SkillCleanup @RequiresSignIn 
Scenario Outline: Add duplicate skill name with different skill level
Given I am in the skill section of my profile
When  I successfully add new "Communication" and "Intermediate"  
And   I recreate same skill name "Communication" and different level "Beginner"
Then  a duplicate error "Duplicated data" should appear   	

@positive @SkillCleanup @RequiresSignIn 
Scenario Outline: Edit skill record with valid details
Given I am in the skill section of my profile
When  I successfully add new skill "<skillOld>" and "<levelOld>" 
And I verify the skill "<skillOld>" with level "<levelOld>" exists   
When I edit "<skillOld>" to "<skillNew>" and "<levelOld>" to "<levelNew>" 
Then successful update message "<skillNew>" "<message>" should be displayed
And  updated "<skillNew>" and "<levelNew>" should be shown  in the list 

Examples: 
|testCaseID  | skillOld	   | skillNew			 |   levelOld	|  levelNew	| message						    |
|TC043		 | Writing	   |  Technical Writing	 |    Expert	|  Expert	| has been updated to your skills| 

@negative  @SkillCleanup @RequiresSignIn 
Scenario Outline: Edit skill record with invalid details
Given I am in the skill section of my profile
When  I successfully add new skill "Communication" and "Intermediate" 
And I verify the skill "<skillOld>" with level "<levelOld>" exists  
When I edit "<skillOld>" to "<skillNew>" and "<levelOld>" to "<levelNew>"
Then an error "<message>" should be displayed 

Examples: 
|testCaseID  | skillOld			   | skillNew			 |  levelOld			|  levelNew				| message											|
|TC044		 | Communication	   |					 |  Intermediate		|  Expert				| Please enter skill and experience level			| 
|TC045		 | Communication	   |  Writing			 |  Intermediate		|  Skill Level	     	| Please enter skill and experience level			| 


@negative  @SkillCleanup @RequiresSignIn 
Scenario Outline: Edit duplicate skill record
Given I am in the skill section of my profile
When  I successfully add new skill "Communication" and "Intermediate" 
And I successfully add new skill "Technical Writing" and "Expert" 
And I verify the skill "<skillOld>" with level "<levelOld>" exists  
When I edit "<skillOld>" to "<skillNew>" and "<levelOld>" to "<levelNew>"
Then an error "<message>" should be displayed 

Examples: 
| testCaseID | skillOld      | skillNew          | levelOld     | levelNew | message                                         |
| TC046      | Communication | Technical Writing | Intermediate | Expert   | This skill is already added to your skill list. |

@negative  @SkillCleanup @RequiresSignIn 
Scenario Outline: Delete skill record 
Given I am in the skill section of my profile
When  I successfully add new skill "Communication" and "Intermediate" 
And I verify the skill "<skill>" with level "<level>" exists 
When  I delete the existing  "<skill>" with "<level>" record
Then successful deletion  "<skill>"  "<message>" should be displayed 
And  the "<skill>" with "<level>" record should be removed from the list 

Examples: 
|testCaseID  | skill		    |  level			|message|
|TC050		 | Communication	| Intermediate		|has been deleted| 
