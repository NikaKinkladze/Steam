Feature: SteamGameList
I am user
I am on the Steam main page
I enter game name in search box
I Sort games in descending order of price

Scenario: Game List
	Given I am on the main page
	When I search for "<GameName>"
	Then Search results page is opened
	When I click on 'Sort by'
	And I click on 'Highest price'
	Then The top <Count> games should be sorted in descending order

	Examples:
      | GameName   | Count |
      | The Witcher | 10   |
      | Fallout     | 20   |