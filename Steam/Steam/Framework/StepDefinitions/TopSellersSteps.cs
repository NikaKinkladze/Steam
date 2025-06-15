using Steam.Framework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Steam.Framework.StepDefinitions
{
    [Binding]
    internal class TopSellersSteps
    {
        TopSellersPage topSellersPage = new();

        [Then(@"I should see the Top Sellers header")]
        public void ThenIShouldSeeTheTopSellersHeader()
        {
            Assert.That(topSellersPage.IsTopSellersHeaderPresent(), Is.True, "Top Sellers header is not present on the page");
        }

        [When(@"I set the price range slider to 5 dollars")]
        public void WhenISetThePriceRangeSliderTo5()
        {
            topSellersPage.SetSliderTo5();
        }

        [Then(@"Price is set under 5 dollars")]
        public void ThenPriceIsSetUnder5()
        {
            Assert.That(topSellersPage.IsPriceRangeUnderFive(), Is.True, "Price range should be set to 'Under $5.00'");
        }

        [When(@"I apply genres")]
        public void WhenIApplyTags()
        {
            topSellersPage.SearchForTags("Puzzle", "2D", "Fantasy");
        }

        [Then(@"I should see the genres on the page")]
        public void ThenIShouldSeeTheGenresOnThePage()
        {
            bool allGenresPresent = topSellersPage.AreGenresDisplayed("2D", "Puzzle", "Fantasy");
            Assert.That(allGenresPresent, Is.True, "Not all genres (2D, Puzzle, Fantasy) are displayed on the page.");
        }

        [When(@"I apply OS")]
        public void WhenIApplyOS()
        {
            topSellersPage.ClickLinuxCheckbox();
        }

        [When(@"I click on the first game")]
        public void WhenIClickOnTheFirstGame()
        {
            topSellersPage.ClickFirstGame();
        }
    }
}