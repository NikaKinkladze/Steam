using Steam.Framework.Pages;
using Steam.Framework.Utils;
using TechTalk.SpecFlow;

namespace Steam.Framework.StepDefinitions
{
    [Binding]
    internal class SteamMainPageSteps
    {
        SteamMainPage steamMainPage = new();

        [Given(@"I am on the main page")]
        public void WhenIOpenTheSteamMainPage()
        {
            Assert.That(steamMainPage.IsPageOpened(), Is.True, "Steam main page is not opened");
        }

        [When(@"I open the Privacy policy page")]
        public void WhenIOpenThePrivacyPolicyPage()
        {
            steamMainPage.ClickPrivacyPolicyLink();
            SwitchToNewTabExtension.SwitchToNewTab();
        }

        [When(@"I choose Top sellers category")]
        public void WhenIOpenTheTopSellersPage()
        {
            steamMainPage.ClickTopSellersLink();
        }
        [When(@"I open the community marketplace")]
        public void WhenIOpenTheCommunityMarketPage()
        {
            steamMainPage.ClickMarketButton();
        }
    }
}