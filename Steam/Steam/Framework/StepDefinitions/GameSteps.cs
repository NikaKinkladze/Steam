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
    internal class GameSteps
    {
        GamePage gamePage = new();
        TopSellersPage topSellersPage = new();
        private readonly ScenarioContext _scenarioContext;
        private readonly GamePage _gamePage;
        public GameSteps(ScenarioContext scenarioContext, GamePage gamePage)
        {
            _scenarioContext = scenarioContext;
            _gamePage = gamePage;
        }

        [When(@"I store the first game's details from search results")]
        public void StoreFirstGameDetails()
        {
            _scenarioContext["ExpectedGameName"] = topSellersPage.GetFirstGameName();
            _scenarioContext["ExpectedReleaseDate"] = topSellersPage.GetFirstGameReleaseDate();
            _scenarioContext["ExpectedPrice"] = topSellersPage.GetFirstGamePrice();
        }

        [Then(@"Game name, price and release date are same as in the search results")]
        public void GameInfoShouldMatch()
        {
            string expectedGameName = _scenarioContext["ExpectedGameName"].ToString();
            string expectedReleaseDate = _scenarioContext["ExpectedReleaseDate"].ToString();
            string expectedPrice = _scenarioContext["ExpectedPrice"].ToString();

            Assert.That(_gamePage.GetGameName(), Is.EqualTo(expectedGameName),
                "Game name does not match.");
            Assert.That(_gamePage.GetReleaseDate(), Is.EqualTo(expectedReleaseDate),
                "Release date does not match.");
            Assert.That(_gamePage.GetPrice(), Is.EqualTo(expectedPrice),
                "Price does not match.");
        }
    }
}
