using Aquality.Selenium.Browsers;

namespace Steam.Framework.Utils
{
    public static class SwitchToNewTabExtension
    {
        public static void SwitchToNewTab()
        {
            var windowHandles = AqualityServices.Browser.Driver.WindowHandles;
            if (windowHandles.Count > 1)
            {
                // Switch to the last opened tab
                AqualityServices.Browser.Driver.SwitchTo().Window(windowHandles.Last());
            }
            else
            {
                throw new Exception("No new tab was opened.");
            }
        }
    }
}
