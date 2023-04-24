﻿using Microsoft.Playwright;
using PlaywrightAutomation.Components;
using PlaywrightAutomation.Extensions;
using PlaywrightAutomation.RuntimeVariables;
using PlaywrightAutomation.Utils;
using TechTalk.SpecFlow;
using static PlaywrightAutomation.Components.BaseWebComponent;

namespace PlaywrightAutomation.Steps.ComponentSteps
{
    [Binding]
    internal class InputComponentSteps : SpecFlowContext
    {
        private readonly IPage _page;
        private readonly SessionRandomValue _sessionRandom;

        public InputComponentSteps(BrowserFactory browserFactory, SessionRandomValue sessionRandom)
        {
            _page = browserFactory.Page;
            _sessionRandom = sessionRandom;
        }

        [When(@"User set '([^']*)' text to '([^']*)' input on '([^']*)' container")]
        public void WhenUserSetTextToInputOnContainer(string text, string input, string container)
        {
            var parent = WebContainer.GetLocator(container);
            _page.Component<Input>(input, new Properties { ParentSelector = parent })
                .FillAsync(text.AddRandom(_sessionRandom)).GetAwaiter().GetResult();
            _page.WaitForLoadStateAsync(LoadState.NetworkIdle).GetAwaiter().GetResult();
        }
    }
}