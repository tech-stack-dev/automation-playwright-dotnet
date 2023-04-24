﻿using Microsoft.Playwright;
using PlaywrightAutomation.Components.Button;
using PlaywrightAutomation.Extensions;
using PlaywrightAutomation.Utils;
using TechTalk.SpecFlow;
using static PlaywrightAutomation.Components.BaseWebComponent;

namespace PlaywrightAutomation.Steps.ComponentSteps
{
    [Binding]
    internal class ButtonComponentSteps : SpecFlowContext
    {
        private readonly IPage _page;

        public ButtonComponentSteps(BrowserFactory browserFactory)
        {
            _page = browserFactory.Page;
        }

        [When(@"User clicks '([^']*)' button on '([^']*)' container")]
        public void WhenUserClicksButtonOnContainer(string button, string container)
        {
            _page.Component<Button>(button, new Properties { ParentSelector = WebContainer.GetLocator(container) })
                .ClickAsync().GetAwaiter().GetResult();
            _page.WaitForLoadStateAsync(LoadState.NetworkIdle).GetAwaiter().GetResult();
        }
    }
}
