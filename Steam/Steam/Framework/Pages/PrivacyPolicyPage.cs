using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using ExampleProject.Framework;
using OpenQA.Selenium;

namespace Steam.Framework.Pages
{
    internal class PrivacyPolicyPage : Form
    {
        private const string PageName = "Privacy Policy Agreement";
        private IList<ILink> LanguageLinks => ElementFactory.FindElements<ILink>(By.CssSelector("#languages a"));
        public PrivacyPolicyPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }

        public bool AreLanguagesPresent(IEnumerable<string> expectedLanguages)
        {
            var actualLanguages = LanguageLinks
                .Select(link => link.GetAttribute("href"))
                .Where(href => !string.IsNullOrEmpty(href))
                .Select(href =>
                {
                    var parts = href.Split('/');
                    return parts.Length > 0 ? parts[^2].ToLower() : string.Empty;
                })
                .ToList();

            return expectedLanguages.All(lang => actualLanguages.Contains(lang.ToLower()));
        }
    }
}
