using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using ExampleProject.Framework;
using OpenQA.Selenium;

namespace Steam.Framework.Pages
{
    internal class SteamMainPage : Form
    {
        private const string PageName = "Welcome to Steam";
        private ILink PrivacyPolicyLink => ElementFactory.GetLink(By.XPath("//a[contains(@href,'privacy_agreement')]"), "Privacy Policy Link");
        private ILink TopSellersLink => ElementFactory.GetLink(By.XPath("//a[contains(@href, 'topsellers') and contains(text(), 'Top Sellers')]"), "Top Sellers");
        private ILabel CommunityMenu => ElementFactory.GetLabel(By.XPath("//a[contains(@class, 'supernav') and normalize-space(text())='COMMUNITY']"), "Community menu");
        private IButton MarketButton => ElementFactory.GetButton(By.XPath("//a[contains(@href, '/market') and normalize-space(text())='Market']"), "Community Market Button");

        public SteamMainPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }

        public bool IsPageOpened()
        {
            return AqualityServices.Browser.Driver.Title.Contains(PageName);
        }

        public void ClickPrivacyPolicyLink()
        {
            PrivacyPolicyLink.Click();
        }
        public void ClickTopSellersLink()
        {
            TopSellersLink.Click();
        }
        public void ClickMarketButton()
        {
            CommunityMenu.MouseActions.MoveToElement();
            AqualityServices.ConditionalWait.WaitFor(() => MarketButton.State.IsDisplayed);
            MarketButton.Click();
        }
    }
}
