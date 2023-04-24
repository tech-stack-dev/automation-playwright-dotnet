using Microsoft.Playwright;
using PlaywrightAutomation.Providers;
using PlaywrightAutomation.Utils;
using TechTalk.SpecFlow;

namespace PlaywrightAutomation.Steps
{
    [Binding]
    internal class GeneralSteps : SpecFlowContext
    {
        private IPage _page;
        private readonly BrowserFactory _browserFactory;

        public GeneralSteps(BrowserFactory browserFactory)
        {
            _page = browserFactory.Page;
            _browserFactory = browserFactory;
        }

        [Given(@"User is on career website")]
        public void GivenUserIsOnCareerWebsite()
        {
            _page = _browserFactory
                .OpenNewPage(UrlProvider.Application)
                .GetAwaiter()
                .GetResult();
        }

        [Given(@"User is on '([^']*)' page")]
        public void GivenUserIsOnPage(string url)
        {
            _page = _browserFactory
                .OpenNewPage(url)
                .GetAwaiter()
                .GetResult();
        }
    }
}