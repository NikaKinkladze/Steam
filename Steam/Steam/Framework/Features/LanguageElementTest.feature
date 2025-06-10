Feature: LanguageElementTest
I am user
I am on main page
I open Privacy policy page
Different languages are displayed


Scenario: Languages are displayed
	Given I am on the main page
	When I open the Privacy policy page
	Then I should see the languages