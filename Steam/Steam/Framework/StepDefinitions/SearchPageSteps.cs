using Steam.Framework.Pages;
using TechTalk.SpecFlow;

namespace Steam.Framework.StepDefinitions
{
    [Binding]
    internal class SearchPageSteps
    {
        SearchPage searchpage = new();
        private readonly SearchPage searchPage = new();
        private List<double> gamePrices;

        [Then(@"Search results page is opened")]
        public void SearchPageIsOpened()
        {
            Assert.That(searchpage.IsSearchPageOpened(), Is.True, "Search results page is not opened");
        }

        [When(@"I click on 'Sort by'")]
        public void ClickSortBy()
        {
            searchpage.ClickSortByBtn();
        }

        [When(@"I click on 'Highest price'")]
        public void ClickHighestToLowestFilter()
        {
            searchpage.ClickHighestToLowestFilterBtn();
            searchpage.WaitUntilPricesSorted();
        }

        [Then(@"The top (.*) games should be sorted in descending order")]
        public void ThenGamesShouldBeSortedDescending(int topN)
        {
            gamePrices = searchPage.GetGamePrices(topN);
            var sorted = gamePrices.OrderByDescending(p => p).ToList();
            Assert.IsTrue(gamePrices.SequenceEqual(sorted), "Prices are not sorted in descending order.");
        }
    }
}