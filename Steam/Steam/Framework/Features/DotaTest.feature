Feature: DotaTest
I am user
I am on main page
I open comunity marketplace
I click on 'Show advanced options'
I enter parameters: Game - Dota
					Hero - Lifestelaer
					Rarity - Immortal
					Search field - "Golden"
I click search button
I delete filters



Scenario: Dota test
	Given I am on the main page
	When I open the community marketplace
	Then I should see the community marketplace Page
	When I click on 'Show advanced options'
	Then 'SEARCH COMMUNITY MARKET' window is open
	When I click on 'Game Options' dropdown
	And I click on 'Dota 2' button
	When I choose "Lifestealer"
	And I choose Immortal rarity
	And I search for "golden" in search field
	And I click search button
	Then Filters 'Dota 2', 'Lifestealer', 'Immortal', 'golden' have appeared on the page
	When I save name, quantity and price of first product
	And I remove 'Lifestealer' filter
	And I remove 'golden' rarity filter
	Then First item name is different from saved item name
	Then First item quantity is different from saved item quantity
	Then First item price is different from saved item price
