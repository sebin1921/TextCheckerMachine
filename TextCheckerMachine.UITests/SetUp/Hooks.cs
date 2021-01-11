using System.Configuration;
using TechTalk.SpecFlow;

namespace TextCheckerMachine.UITests.SetUp
{
    [Binding]
    public static class Hooks
    {
        public static string WebSiteUrl => $"{ConfigurationManager.AppSettings["webSiteHost"]}:{ConfigurationManager.AppSettings["webSitePort"]}";

        private static readonly WebDriverHooks SeleniumTest =
            new WebDriverHooks(ConfigurationManager.AppSettings["webSiteName"]);

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            SeleniumTest.Initialize();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            SeleniumTest.Cleanup();
        }
    }
}
