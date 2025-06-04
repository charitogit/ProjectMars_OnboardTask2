Feature: Language

As a user I would like to add,edit and delete languages I know in a list
so I can showcase them under my profile page.


Background: I am successfully signed in 
	Given I am in the sign in page
	When I enter valid "charie_artz@yahoo.com" and valid "P@ssw0rd"
	Then I should see my profile page with greeting "Hi Charito"
	
@positive
Scenario Outline: Add new languaage with valid details
	Given  I am in the Language section of my profile
	When   I add "<language>" and "<level>"  
	Then  successful added "<language>" "<message>" should be displayed
	And   "<language>" and "<level>" should appear in my language list
	
Examples: 
|testCaseID  | language |  level			| message						 |
|TC022		 | English  |  Fluent			|has been added to your languages| 
|TC022		 | Tagalog  |  Native/Bilingual	|has been added to your languages| 


@negative
Scenario Outline: Add new language with invalid details
Given I am in the Language section of my profile
When  I add "<language>" and "<level>"  
Then  an error "<message>" should be displayed     

Examples: 
|testCaseID  | language |  level				 | message						|
|TC023		 |			|  Basic				 |Please enter language and level| 
|TC024		 |	French	|  Choose Language Level |Please enter language and level| 
|TC025		 |	English	|  	Basic				 |Duplicated data				| 
	
@positive
Scenario Outline: Edit Language record with valid details
Given I am in the Language section of my profile
And I verify the language "<languageOld>" with level "<levelOld>" exists  
When I edit "<languageOld>" to "<languageNew>" and/or "<levelOld>" to "<levelNew>"
Then successful update message "<languageNew>" "<message>" should appear  
And  updated "<languageNew>" and/or "<levelNew>" should be shown  in the list 

Examples: 
|testCaseID  | languageOld | languageNew |   levelOld	|  levelNew	| message						    |
|TC028		 | English	   |  French	 |    Fluent	|  Fluent	| has been updated to your languages| 


@negative
Scenario Outline: Edit Language record with invalid details
Given I am in the Language section of my profile
And I verify the language "<languageOld>" with level "<levelOld>" exists  
When I edit "<languageOld>" to "<languageNew>" and/or "<levelOld>" to "<levelNew>"
Then an error "<message>" should be displayed 

Examples: 
|testCaseID  | languageOld | languageNew |  levelOld			|  levelNew			| message											   |
|TC029		 | Tagalog	   |  French	 |  Native/Bilingual	|  Fluent			| This language is already added to your language list.| 
|TC031		 | Tagalog	   |			 |  Native/Bilingual	|  Fluent			| Please enter language and level						| 
|TC032		 | Tagalog	   |  English	 |  Native/Bilingual	|  Language Level	| Please enter language and level						| 



Scenario Outline: Delete language record
Given I am in the Language section of my profile
And I verify the language "<language>" with level "<level>" exists  
When  I delete existing  "<language>" with "<level>" record 
Then successful deleted "<language>"  "<message>" should be displayed 
And   "<language>" with "<level>" record should be removed from the list 

Examples: 
|testCaseID  | language		    |  level			|message		|
|TC035		 | English			| Fluent			|has been deleted| 
