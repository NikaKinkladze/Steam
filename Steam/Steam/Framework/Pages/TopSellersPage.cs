using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using ExampleProject.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace Steam.Framework.Pages
{
    internal class TopSellersPage : Form
    {
        private const string PageName = "Steam Search";
        private ILabel TopSellersHeader => ElementFactory.GetLabel(By.XPath(string.Format(LocatorConstants.PartialTextLocator, "Top Sellers")), "Top Sellers Header");
        public ILabel PriceRangeDisplay => ElementFactory.GetLabel(By.Id("price_range_display"), "Price Range Display");
        private ITextBox tagSearch => ElementFactory.GetTextBox(By.Id("TagSuggest"), "Tag Search Box");
        private IList<ILabel> GenreTagLabels => ElementFactory.FindElements<ILabel>(By.CssSelector("div.searchtag.tag_dynamic > span.label"));
        private ILabel linuxCheckbox = ElementFactory.GetLabel(By.XPath("//span[contains(@class, 'tab_filter_control_include') and @data-value='linux']"), "Linux Checkbox");
        private ILink FirstGameLink => ElementFactory.GetLink(By.CssSelector("a.search_result_row:first-child"), "First Game Link");
        private ILabel FirstGameName => ElementFactory.GetLabel(By.CssSelector("a.search_result_row:first-child span.title"), "First Game Name");
        private ILabel FirstGameReleaseDate => ElementFactory.GetLabel(By.CssSelector("a.search_result_row:first-child div.search_released"), "First Game Release Date");
        private ILabel FirstGamePrice => ElementFactory.GetLabel(By.CssSelector("a.search_result_row:first-child div.discount_final_price"), "First Game Price");

        public TopSellersPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }

        public bool IsTopSellersHeaderPresent()
        {
            return TopSellersHeader.State.IsDisplayed;
        }

        public void SetSliderTo5()
        {
            var slider = AqualityServices.Browser.Driver.FindElement(By.Id("price_range"));
            var jsExecutor = (IJavaScriptExecutor)AqualityServices.Browser.Driver;

            // Set value to 1 and trigger 'input' and 'change' events
            jsExecutor.ExecuteScript(
                "arguments[0].value = 1;" +
                "arguments[0].dispatchEvent(new Event('input'));" +
                "arguments[0].dispatchEvent(new Event('change'));",
                slider);
        }

        public bool IsPriceRangeUnderFive()
        {
            string actualText = PriceRangeDisplay.Text;
            return actualText == "Under $5.00";
        }

        public void SearchForTags(params string[] tags)
        {
            foreach (var tag in tags)
            {
                tagSearch.ClearAndType(tag);

                var checkbox = GetTagCheckboxByDataLoc(tag);
                if (!checkbox.State.WaitForDisplayed(TimeSpan.FromSeconds(10)))
                {
                    throw new TimeoutException($"{tag} checkbox was not displayed within 10 seconds");
                }

                checkbox.Click();
            }
        }

        private ILabel GetTagCheckboxByDataLoc(string tag)
        {
            var locator = By.XPath($"//span[contains(@class,'tab_filter_control') and contains(@data-loc,'{tag}')]");
            return ElementFactory.GetLabel(locator, $"{tag} checkbox");
        }

        public bool AreGenresDisplayed(params string[] expectedGenres)
        {
            var displayedGenres = GenreTagLabels.Select(label => label.Text.Trim()).ToList();
            return expectedGenres.All(genre => displayedGenres.Contains(genre));
        }

        public void ClickLinuxCheckbox()
        {
            if (!linuxCheckbox.State.IsDisplayed)
            {
                throw new NoSuchElementException("Linux checkbox is not displayed on the page");
            }
            linuxCheckbox.Click();
            Thread.Sleep(1000); // Wait for the page to update after clicking the last checkbox
        }

        public string GetFirstGameName() => FirstGameName.Text;
        public string GetFirstGameReleaseDate() => FirstGameReleaseDate.Text;
        public string GetFirstGamePrice() => FirstGamePrice.Text;
        public void ClickFirstGame()
        {
            FirstGameLink.Click();
        }
    }
}
