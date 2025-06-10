using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using ExampleProject.Framework;
using OpenQA.Selenium;

namespace Steam.Framework.Pages
{
    internal class TopSellersPage : Form
    {
        private const string PageName = "Steam Search";
        private ILabel TopSellersHeader => ElementFactory.GetLabel(By.XPath(string.Format(LocatorConstants.PartialTextLocator, "Top Sellers")), "Top Sellers Header");
        private ITextBox PriceRangeSlider => ElementFactory.GetTextBox(By.Id("price_range"), "Price Range Slider");
        private ICheckBox GetTagCheckBox(string tag) => ElementFactory.GetCheckBox(By.XPath($"//div[@id='TagFilter_Container']//label[contains(text(), '{tag}')]/preceding-sibling::input"), $"Tag: {tag}");
        private ICheckBox GetOSCheckBox(string os) => ElementFactory.GetCheckBox(By.XPath($"//div[@id='additional_filters']//label[contains(text(), '{os}')]/preceding-sibling::input"), $"OS: {os}");
        public TopSellersPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }

        public bool IsTopSellersHeaderPresent()
        {
            return TopSellersHeader.State.IsDisplayed;
        }

        public void SetSliderTo5()
        {
            var jsExecutor = (IJavaScriptExecutor)AqualityServices.Browser.Driver;

            jsExecutor.ExecuteScript(
                "arguments[0].value = 5;" +
                "arguments[0].dispatchEvent(new Event('input'));" +
                "arguments[0].dispatchEvent(new Event('change'));",
                PriceRangeSlider.GetElement());
        }

        public void ApplyFilters()
        {
            string[] tags = { "Puzzle", "2D", "Fantasy" };
            string os = "SteamOS + Linux";

            foreach (var tag in tags)
            {
                var checkbox = GetTagCheckBox(tag);
                if (!checkbox.IsChecked) checkbox.Check();
            }

            var osCheckbox = GetOSCheckBox(os);
            if (!osCheckbox.IsChecked) osCheckbox.Check();
        }
    }
}
