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
	When I set the price range slider to 5 dollars
	Then Price is set under 5 dollars
	When I apply genres
	Then I should see the genres on the page 
	When I apply OS
	And I store the first game's details from search results
	And I click on the first game
	Then Game name, price and release date are same as in the search results