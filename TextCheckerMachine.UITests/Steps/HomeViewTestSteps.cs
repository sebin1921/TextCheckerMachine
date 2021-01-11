using System;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TextCheckerMachine.UITests.Pages;
using TextCheckerMachine.UITests.SetUp;

namespace TextCheckerMachine.UITests.Steps
{
    [Binding]
    public class HomeViewTestSteps
    {
        public const string BrowserTypeKey = "BrowserType";
        private HomePage _homePage;

        [Given(@"I use '(.*)' as a user agent")]
        public void GivenIUseAsAUserAgent(string browser)
        {
            if (!Enum.TryParse(browser, true, out BrowserType type))
                Assert.Fail("Unknown browser type: {0}", browser);

            ScenarioContext.Current.Set(type, BrowserTypeKey);
        }

        [When(@"I am on the start up page of the application")]
        public void GivenIAmOnTheBlogPostApplicationHomePage()
        {
            var browserType = ScenarioContext.Current.Get<BrowserType>(BrowserTypeKey);
            var browser = WebDriverHooks.CreateByType(browserType);
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(Hooks.WebSiteUrl);
            _homePage = new HomePage(browser);
        }

        [Then(@"Verify that the page title is '(.*)'")]
        public void ThenVerifyThePageTitle(string title)
        {
            var homeScreen = _homePage.Title;
            Assert.IsNotNull(homeScreen);
            Assert.IsTrue(homeScreen.Displayed);
        }

        [When(@"I find the '(.*)' of text '(.*)'")]
        public void WhenIFindThePalindromesOfText(string option, string inputText)
        {
            _homePage.FillValues(inputText, option);
            _homePage.ClickSubmit();
        }

        [Then(@"I get '(.*)' unique palindromes as follows:")]
        public void ThenIGetListPalindromesAsFollows(int totalPalindromes, Table table)
        {
            var results = table.CreateSet<TestData.TestResult>();
            Assert.NotNull(results);

            var palindromeCount = _homePage.FindElementByText($"The number of unique Palindrome(s) in the given text :-  {totalPalindromes}");
            Assert.IsTrue(palindromeCount.Any(), "Palindrome count not found");

            foreach (var result in results)
            {
                var elementList = _homePage.FindElementByText($"{result.Word}");
                Assert.IsTrue(elementList.Any(), $"Text '{result.Word}' not found!");
            }
        }
        
        [Then(@"I get the list duplicate as follows:")]
        public void ThenIGetListDuplicateWordsAsFollows(Table table)
        {
            var results = table.CreateSet<TestData.TestResult>();
            Assert.NotNull(results);

            foreach (var result in results)
            {
                var elementList = _homePage.FindElementByText($"{result.Word} exists {result.Count} time(s)");
                Assert.IsTrue(elementList.Any(), $"Text '{result.Word}' not found!");
            }
        }

        [Then(@"I get a message '(.*)'")]
        public void ThenIGetNoPalindromes(string message)
        {
            var elementList = _homePage.FindElementByText($"{message}");
            Assert.IsTrue(elementList.Any(), $"Text '{message}' not found!");
        }

        [When(@"I find if the text '(.*)' is a valid html")]
        public void WhenIFindIfTheTextIsAValidHtml(string inputText)
        {
            _homePage.FillValues(inputText, "HtmlValidation");
            _homePage.ClickSubmit();
        }

        [Then(@"I get the result '(.*)'")]
        public void ThenIGetTheResult(bool result)
        {
            if (result)
            {
                var elementList = _homePage.FindElementByText("The text is a valid html");
                Assert.IsTrue(elementList.Any(), "Text 'Text is a valid html' not found!");
            }
            else
            {
                var elementList = _homePage.FindElementByText("The text is not a valid html because");
                Assert.IsTrue(elementList.Any(), "Text 'Text is not a valid html' not found!");
            }
        }

        [When(@"I redirect the page to a invalid url")]
        public void WhenIRedirectThePageTo()
        {
            _homePage.Goto($"{_homePage.WebDriver.Url}/test");
        }


        [AfterScenario("CleanUpBrowser")]
        public void CleanUpBrowser()
        {
            _homePage.Dispose();
        }
    }
}
