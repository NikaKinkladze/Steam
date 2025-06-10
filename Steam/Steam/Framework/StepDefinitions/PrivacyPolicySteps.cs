using Steam.Framework.Pages;
using Steam.Framework.Utils;
using TechTalk.SpecFlow;

namespace Steam.Framework.StepDefinitions
{
    [Binding]
    internal class PrivacyPolicySteps
    {
        PrivacyPolicyPage privacyPolicyPage = new();

        [Then(@"I should see the languages")]
        public void Languages()
        {
            var expectedLanguages = TestDataReader.GetLanguages();
            Assert.That(privacyPolicyPage.AreLanguagesPresent(expectedLanguages), Is.True, "Not all expected languages are present on the page");
        }
    }
}