using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Steam.Framework.Pages;

namespace Steam.Framework.StepDefinitions
{
    [Binding]
    internal class CommunityMarketSteps
    {
        CommunityMarketPage communityMarketPage = new();
        private (string Name, string Quantity, string Price) firstItemBeforeFilters;
        private (string Name, string Quantity, string Price) secondItemAfterFilters;


        [Then(@"I should see the community marketplace Page")]
        public void ThenIShouldSeeTheCommunityMarketPage()
        {
            Assert.That(communityMarketPage.IsPageOpened(), Is.True, "Community Market page is not opened");
        }

        [When(@"I click on 'Show advanced options'")]
        public void WhenIClickOnTheAdvancedOptionsButton()
        {
            communityMarketPage.ClickAdvancedOptionsButton();
        }

        [Then(@"'SEARCH COMMUNITY MARKET' window is open")]
        public void ThenSearchCommunityMarketWindowIsOpen()
        {
            Assert.That(communityMarketPage.IsSearchCommunityMarketModalOpened(), Is.True, "'SEARCH COMMUNITY MARKET' window is not opened");
        }

        [When(@"I click on 'Game Options' dropdown")]
        public void WhenIClickOnTheGameOptionsDropdown()
        {
            communityMarketPage.ClickGameOptionsDropdown();
        }

        [When(@"I click on 'Dota 2' button")]
        public void WhenIClickOnTheDota2Button()
        {
            communityMarketPage.ClickDota2Button();
        }

        [When(@"I choose ""(.*)""")]
        public void ChooseHero(string heroName)
        {
            communityMarketPage.SelectHeroByName(heroName);
        }

        [When(@"I choose Immortal rarity")]
        public void WhenIChooseImmortalRarity()
        {
            communityMarketPage.ClickImmortalRarityButton();
        }

        [When(@"I search for ""(.*)"" in search field")]
        public void WhenISearchForInSearchField(string searchText)
        {
            communityMarketPage.SearchInAdvancedOptions(searchText);
        }

        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {
            communityMarketPage.ClickSearchButton();
        }

        [Then(@"Filters 'Dota 2', 'Lifestealer', 'Immortal', 'golden' have appeared on the page")]
        public void FiltersAreApplied()
        {
            communityMarketPage.AssertFiltersApplied();
        }

        [When(@"I save name, quantity and price of first product")]
        public void WhenISaveFirstItemInfo()
        {
            firstItemBeforeFilters = communityMarketPage.GetFirstItemInfo();
            Console.WriteLine($"Saved Item - Name: {firstItemBeforeFilters.Name}, Quantity: {firstItemBeforeFilters.Quantity}, Price: {firstItemBeforeFilters.Price}");
        }

        [When(@"I remove 'Lifestealer' filter")]
        public void WhenIRemoveLifestealerFilter()
        {
            communityMarketPage.RemoveLifestealerFilter();
        }

        [When(@"I remove 'golden' rarity filter")]
        public void WhenIRemoveGoldenRarityFilter()
        {
            communityMarketPage.RemoveGoldenRarityFilter();
        }

        [Then(@"First item name is different from saved item name")]
        private void ThenFirstItemNameIsDifferentFromSavedItemName()
        {
            Assert.That(secondItemAfterFilters.Name, Is.Not.EqualTo(firstItemBeforeFilters.Name),
                $"Expected item name to be different after filters were removed, but it was still '{secondItemAfterFilters.Name}'");
        }

        [Then(@"First item quantity is different from saved item quantity")]
        private void ThenFirstItemQuantityIsDifferentFromSavedItemQuantity()
        {
            Assert.That(secondItemAfterFilters.Quantity, Is.Not.EqualTo(firstItemBeforeFilters.Quantity),
                $"Expected item quantity to be different after filters were removed, but it was still '{secondItemAfterFilters.Quantity}'");
        }

        [Then(@"First item price is different from saved item price")]
        private void ThenFirstItemPriceIsDifferentFromSavedItemPrice()
        {
            Assert.That(secondItemAfterFilters.Price, Is.Not.EqualTo(firstItemBeforeFilters.Price),
                $"Expected item price to be different after filters were removed, but it was still '{secondItemAfterFilters.Price}'");
        }
    }
}