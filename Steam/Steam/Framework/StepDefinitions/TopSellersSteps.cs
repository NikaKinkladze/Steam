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

        [When(@"I set the price range slider to 5")]
        public void WhenISetThePriceRangeSliderTo5()
        {
            topSellersPage.SetSliderTo5();
        }

        [When(@"I apply filters")]
        public void WhenIApplyFilters()
        {
            topSellersPage.ApplyFilters();
        }
    }
}