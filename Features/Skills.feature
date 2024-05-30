Feature: Skills

Scenario Outline: A. Create a new Skills record with alpha code
	Given I log into Mars portal
	When I navigate to Skills page
	And I create a new Skills record <skills>
	Then the skill should be saved <skills>

	Examples: 
	| skills   |
	| 'Java'  |
	| 'SQL'   |


	Scenario Outline: B. Edit an existing Skills record
	Given I log into Mars portal
	When I navigate to Skills page
	And I edit an existing Skills record <skills> <newskills>
	Then the old skills record should be updated <newskills>

    Examples: 
	| skills | newskills |
	| 'SQL' | 'C#' |


	Scenario: C. Delete an existing Skills record
	Given I log into Mars portal
	When I navigate to Skills page
	And I delete an existing Skills record 'C#'
	Then the skill record should be deleted 'C#'