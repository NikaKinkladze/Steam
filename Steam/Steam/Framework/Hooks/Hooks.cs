using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Utilities;
using TechTalk.SpecFlow;

namespace Steam.Framework.Hooks
{
    [Binding]
    internal class Hooks
    {
        private readonly Browser browser = AqualityServices.Browser;
        private static readonly JsonSettingsFile settings = new("config.json");
        public static readonly string relativePathFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Resources\");

        [BeforeScenario]
        public void setup()
        {
            browser.Maximize();
            browser.GoTo(settings.GetValue<string>("url"));
        }

        [AfterScenario]
        public void teardown()
        {
            //browser.Quit();
        }
    }
}