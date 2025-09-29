Feature: Signin

As a user of Project Mars, I want to sign in to my account
so I can manage my skills and languages in my profile
and make them available to viewers and recruiters.

@positive
Scenario Outline: Sign in with valid credentials
	Given I am in the sign in page
	When I enter valid "<email>" and valid "<password>"
	Then I should see my profile page with greeting "<message>"							

	Examples: 
	| testCaseID | email                 | password | message    |
	| TC001      | charie_artz@yahoo.com | P@ssw0rd | Hi Charito |

	@positive
Scenario Outline: Sign in with valid credentials without selecting "Remember me" 
	Given I am in the sign in page
	When I enter valid "<email>" and valid "<password>" without selecting Remember me 
	Then I should see my profile page with greeting "<message>"							

	Examples: 
	| testCaseID | email                 | password | message    |
	| TC002      | charie_artz@yahoo.com | P@ssw0rd | Hi Charito |

@positive
Scenario Outline: Existing user is redirected to profile page after successful Sign in 
	Given I am in the sign in page
	When I enter valid "<email>" and valid "<password>" 
	Then I should see my profile page with greeting including my first name within the "<message>"							

	Examples: 
	| testCaseID | email                 | password | message    |
	| TC003      | charie_artz@yahoo.com | P@ssw0rd | Hi Charito |


	@negative
Scenario Outline:  Sign in with invalid credentials
Given I am in the sign in page
When  I enter  "<email>" and  "<password>"
Then an error "<message>" should appear 

Examples: 
	| testCaseID | email                 | password      | message            |
	| TC009      | charie_artz@yahoo.com | wrongPassword | Confirm your email |
	| TC010      | qwert				 | P@ssw0rd      | Please enter a valid email address |
	| TC011      | nonexisting@yahoo.com | P@ssw0rd      | Confirm your email |
	| TC012      | aaa					 | bbb			 | Please enter a valid email address |
	| TC013      |						 | P@ssw0rd      | Please enter a valid email address |
	| TC014      | charie_artz@yahoo.com |		         | Password must be at least 6 characters |

		
																