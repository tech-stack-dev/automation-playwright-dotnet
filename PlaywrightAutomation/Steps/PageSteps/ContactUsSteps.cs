using FluentAssertions;
using Microsoft.Playwright;
using PlaywrightAutomation.Extensions;
using PlaywrightAutomation.Pages;
using PlaywrightAutomation.Utils;
using TechTalk.SpecFlow;

namespace PlaywrightAutomation.Steps.PageSteps
{
    [Binding]
    internal class ContactUsSteps : SpecFlowContext
    {
        private readonly IPage _page;

        public ContactUsSteps(BrowserFactory browserFactory)
        {
            _page = browserFactory.Page;
        }

        [Then(@"'([^']*)' title is displayed on Contact Us form")]
        public void ThenTitleIsDisplayedOnContactUsForm(string expectedTitle)
        {
            var actualTitle = _page.Init<ContactUsPage>().Title.TextContentAsync().GetAwaiter().GetResult();
            actualTitle.Should().Be(expectedTitle);
        }
    }
}
