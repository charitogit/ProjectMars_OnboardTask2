Feature: Language

As a user I would like to add,edit and delete languages I know in a list
so I can showcase them under my profile page.

	
@positive @RequiresSignIn @LanguageCleanup
Scenario Outline: Add new languaage with valid details
	Given  I am in the Language section of my profile
	When   I add "<language>" and "<level>"  
	Then  successful added "<language>" "<message>" should be displayed
	And   "<language>" and "<level>" should appear in my language list
	
Examples: 
|testCaseID  | language |  level			| message						 |
|TC022		 | English  |  Fluent			|has been added to your languages| 
|TC022		 | Tagalog  |  Fluent			|has been added to your languages| 


@negative @RequiresSignIn @LanguageCleanup
Scenario Outline: Add new language with invalid details
Given I am in the Language section of my profile
When  I add "<language>" and "<level>"  
Then  an error "<message>" should be displayed     

Examples: 
|testCaseID  | language |  level				 | message						|
|TC023		 |			|  Basic				 |Please enter language and level| 
|TC024		 |	French	|  Choose Language Level |Please enter language and level| 


@TC025 @negative @RequiresSignIn @LanguageCleanup
Scenario Outline: Add duplicate language record
Given I am in the Language section of my profile
When  I add "English" and "Fluent" 
And I recreate same language record "English" and "Fluent"
Then  an error "This language is already exist in your language list." should be displayed 
	
@positive  @RequiresSignIn @LanguageCleanup
Scenario Outline: Edit Language record with valid details
Given I am in the Language section of my profile
When I successfully add "English" and "Fluent"
And  I edit "<languageOld>" to "<languageNew>" and/or "<levelOld>" to "<levelNew>"
Then successful update message "<languageNew>" "<message>" should appear  
And  updated "<languageNew>" and/or "<levelNew>" should be shown  in the list 

Examples: 
|testCaseID  | languageOld | languageNew |   levelOld	|  levelNew	| message						    |
|TC028		 | English	   |  French	 |    Fluent	|  Basic	| has been updated to your languages| 


@TC029 @negative  @RequiresSignIn @LanguageCleanup
Scenario Outline: Edit duplicate Language record
Given I am in the Language section of my profile
When I successfully add "Tagalog" and "Native/Bilingual"
And  I successfully add "French" and "Fluent"
And I verify the language "<languageOld>" with level "<levelOld>" exists  
When I edit "<languageOld>" to "<languageNew>" and/or "<levelOld>" to "<levelNew>"
Then an error "<message>" should be displayed 

 Examples: 
|testCaseID  | languageOld | languageNew |  levelOld			|  levelNew			| message											   |
|TC029		 | Tagalog	   |  French	 |  Native/Bilingual	|  Fluent			| This language is already added to your language list.| 
 
@negative  @RequiresSignIn @LanguageCleanup
Scenario Outline: Edit Language record with invalid details
Given I am in the Language section of my profile
When I successfully add "Tagalog" and "Native/Bilingual"
And I verify the language "<languageOld>" with level "<levelOld>" exists  
When I edit "<languageOld>" to "<languageNew>" and/or "<levelOld>" to "<levelNew>"
Then an error "<message>" should be displayed 
 
Examples: 
|testCaseID  | languageOld | languageNew |  levelOld			|  levelNew			| message											   |
|TC031		 | Tagalog	   |			 |  Native/Bilingual	|  Fluent			| Please enter language and level						| 
|TC032		 | Tagalog	   |  English	 |  Native/Bilingual	|  Language Level	| Please enter language and level						| 


@positive  @RequiresSignIn @LanguageCleanup
Scenario Outline: Delete language record
Given I am in the Language section of my profile
When I successfully add "<language>" and "<level>" 
And I verify the language "<language>" with level "<level>" exists  
When  I delete existing  "<language>" with "<level>" record 
Then successful deleted "<language>"  "<message>" should be displayed 
And   "<language>" with "<level>" record should be removed from the list 

Examples: 
| testCaseID | language | level  | message          |
| TC035      | English  | Fluent | has been deleted |
| TC035      | Tagalog  | Fluent | has been deleted |


 

