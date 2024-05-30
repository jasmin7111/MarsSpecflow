Feature: Language


    Scenario Outline: A. Create a new Language record with alpha code
	Given I log into Mars portal
	When I navigate to Language page
	And I create a new Language record <language>
	Then the record should be saved <language>

	Examples: 
	| language  |
	| 'English' |
	| 'French'  |
	| 'Hindi'   |

	Scenario Outline: B. Edit an existing Language record
	Given I log into Mars portal
	When I navigate to Language page
	And I edit an existing Language record <language> <editedlanguage>
	Then the record should be updated <editedlanguage>

    Examples: 
	| language | editedlanguage |
	| 'Hindi' | 'Tamil' |

	Scenario: C. Delete an existing Language record
	Given I log into Mars portal
	When I navigate to Language page
	And I delete an existing Language record 'Tamil'
	Then the record should be deleted 'Tamil'

	


	