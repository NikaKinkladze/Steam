using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using ExampleProject.Framework;
using OpenQA.Selenium;
using System.Globalization;


namespace Steam.Framework.Pages
{
    internal class SearchPage : Form
    {
        private const string PageName = "Steam Search";

        private IButton SortByBtn => ElementFactory.GetButton(By.Id("sort_by_trigger"), "Sort By Button");
        private IButton HighestToLowestFilterBtn => ElementFactory.GetButton(By.Id("Price_DESC"), "Highest to Lowest Price Filter Button");
        private IList<ILabel> gamePriceLabels => ElementFactory.FindElements<ILabel>(
            By.XPath("//div[@id='search_resultsRows']//div[contains(@class,'search_price')]"), "Game Prices");

        private IComboBox sortDropdown => ElementFactory.GetComboBox(
            By.XPath("//div[contains(@data-sortby,'Price_DESC')]"), "Sort by price desc");
        public SearchPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }

        public bool IsSearchPageOpened()
        {
            return AqualityServices.Browser.Driver.Title.Contains(PageName);
        }

        public void ClickSortByBtn()
        {
            SortByBtn.Click();
        }
        public void ClickHighestToLowestFilterBtn()
        {
            HighestToLowestFilterBtn.Click();
        }
        public List<double> GetGamePrices(int count)
        {
            var prices = new List<double>();

            foreach (var label in gamePriceLabels.Take(count))
            {
                var rawText = label.Text.Trim();
                var split = rawText.Split('€', '$', '₾', '₽'); // Adjust as needed
                if (split.Length > 0 && double.TryParse(split.Last().Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double price))
                {
                    prices.Add(price);
                }
            }

            return prices;
        }
        public void WaitUntilPricesSorted()
        {
            AqualityServices.ConditionalWait.WaitFor(() =>
            {
                var prices = GetGamePrices(5); // Check first 5 prices
                return prices.SequenceEqual(prices.OrderByDescending(p => p));
            }, timeout: TimeSpan.FromSeconds(5));
        }
    }
}
