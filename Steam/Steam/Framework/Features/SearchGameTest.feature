Feature: SearchGameTest
I am on Steam main page
I choose "Top sellers" category
I search for games under 5$
In narrow by tag field i choose 'Puzzle', '2D', 'Fantasy'
In narrow by os I choose 'SteamOS + Linux


Scenario: Search for games
	Given I am on the main page
	When I choose Top sellers category
	Then I should see the Top Sellers header
	When I set the price range slider to 5
	And I apply filters

