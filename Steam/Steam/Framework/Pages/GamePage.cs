using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using ExampleProject.Framework;
using OpenQA.Selenium;

namespace Steam.Framework.Pages
{
    internal class GamePage : Form
    {
        private const string PageName = "Game Page";
        private ILabel GameTitle => ElementFactory.GetLabel(By.Id("appHubAppName"), "Game Title");
        private ILabel ReleaseDateLabel => ElementFactory.GetLabel(By.CssSelector("div.release_date div.date"), "Release Date");
        private ILabel PriceLabel => ElementFactory.GetLabel(By.CssSelector("div.game_purchase_price.price"), "Game Price");
        public GamePage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }
        public string GetGameName() => GameTitle.Text;

        public string GetReleaseDate()
        {
            string fullDateText = ReleaseDateLabel.Text;
            return fullDateText.Replace("Release Date: ", "").Trim();
        }

        public string GetPrice() => PriceLabel.Text;
    }
}
