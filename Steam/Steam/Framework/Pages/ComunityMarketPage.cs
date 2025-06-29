    using Aquality.Selenium.Browsers;
    using Aquality.Selenium.Elements.Interfaces;
    using Aquality.Selenium.Forms;
    using ExampleProject.Framework;
    using OpenQA.Selenium;

namespace Steam.Framework.Pages
{
    internal class CommunityMarketPage : Form
    {
        private const string PageName = "Steam Community :: Steam Community Market";
        private IButton AdvancedOptionsButton => ElementFactory.GetButton(By.Id("market_search_advanced_show"), "Advanced Options Button");
        private ILabel SearchCommunityMarketModalTitle => ElementFactory.GetLabel(By.XPath("//div[@class='title_text' and normalize-space(text())='Search Community Market']"),
    "Search Community Market Modal Title");
        private IButton GameOptionsDrowdown => ElementFactory.GetButton(By.Id("market_advancedsearch_appselect_activeapp"), "Game Options Dropdown");
        private IButton Dota2Button => ElementFactory.GetButton(By.Id("app_option_570"), "Dota 2 Button");
        private IComboBox heroComboBox => ElementFactory.GetComboBox(By.Name("category_570_Hero[]"), "Hero Dropdown");
        private IButton immortalRarityBtn => ElementFactory.GetButton(By.Id("tag_570_Rarity_Rarity_Immortal"), "Immortal Rarity Button");
        private ITextBox searchInAdvancedOptions => ElementFactory.GetTextBox(By.Id("advancedSearchBox"), "Search in Advanced Options");
        private IButton SearchButton => ElementFactory.GetButton(By.XPath("//div[@class='market_advancedsearch_bottombuttons']//div[contains(@onclick,'market_advanced_search')]"), "Search Button");
        private IElement filterContainer => ElementFactory.GetLabel(By.CssSelector(".market_search_results_header"), "Filter Container");
        private ILabel FirstItemName => ElementFactory.GetLabel(By.Id("result_0_name"), "First Item Name");
        private ILabel FirstItemQuantity => ElementFactory.GetLabel(By.CssSelector("#result_0 .market_listing_num_listings_qty"), "First Item Quantity");
        private ILabel FirstItemPrice => ElementFactory.GetLabel(By.CssSelector("#result_0 .normal_price[data-price]"), "First Item Price");
        private ILabel RemoveLifestealer => ElementFactory.GetLabel(By.XPath("//a[contains(text(), 'Lifestealer')]/span[contains(@class, 'removeIcon')]"), "Remove Icon");
        private IElement RemoveGoldenFilter => ElementFactory.GetLabel(By.XPath("//a[contains(., '\"golden\"') or contains(text(), 'golden')]/span[contains(@class, 'removeIcon')]"), "Remove Golden");
        public CommunityMarketPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }

        public bool IsPageOpened()
        {
            return AqualityServices.Browser.Driver.Title.Contains(PageName);
        }

        public void ClickAdvancedOptionsButton()
        {
            AdvancedOptionsButton.Click();
        }

        public bool IsSearchCommunityMarketModalOpened()
        {
            return SearchCommunityMarketModalTitle.State.IsDisplayed;
        }

        public void ClickGameOptionsDropdown()
        {
            GameOptionsDrowdown.Click();
        }

        public void ClickDota2Button()
        {
            Dota2Button.Click();
        }

        public void SelectHeroByName(string heroName)
        {
            heroComboBox.SelectByText(heroName);
        }

        public void ClickImmortalRarityButton()
        {
            immortalRarityBtn.Click();
        }
        public void SearchInAdvancedOptions(string searchText)
        {
            searchInAdvancedOptions.ClearAndType(searchText);
        }

        public void ClickSearchButton()
        {
            SearchButton.Click();
        }

        public void AssertFiltersApplied()
        {
            string filtersText = filterContainer.Text;

            Assert.Multiple(() =>
            {
                Assert.That(filtersText, Does.Contain("Dota 2"), "Missing filter: Dota 2");
                Assert.That(filtersText, Does.Contain("Lifestealer"), "Missing filter: Lifestealer");
                Assert.That(filtersText, Does.Contain("golden"), "Missing filter: golden");
            });
        }

        public (string Name, string Quantity, string Price) GetFirstItemInfo()
        {
            string filteredName = FirstItemName.Text;
            string filteredQuantity = FirstItemQuantity.Text;
            string filteredPrice = FirstItemPrice.Text;

            return (filteredName, filteredQuantity, filteredPrice);
        }

        public void RemoveLifestealerFilter()
        {
            RemoveLifestealer.Click();
        }

        public void RemoveGoldenRarityFilter()
        {
            RemoveGoldenFilter.Click();
        }

        public (string Name, string Quantity, string Price) GetSecondItemInfo()
        {
            string filteredName = FirstItemName.Text;
            string filteredQuantity = FirstItemQuantity.Text;
            string filteredPrice = FirstItemPrice.Text;

            return (filteredName, filteredQuantity, filteredPrice);
        }
    }
}