using System;
using System.IO;
using System.Reflection;
using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace TextCheckerMachine.UITests.SetUp
{
    public class WebDriverHooks : IisExpressServerStartUp
    {
        public WebDriverHooks(string applicationName) : base(applicationName)
        {
            
        }

        public override void Initialize()
        {
            TestInitialize();
        }

        public static IWebDriver CreateByType(BrowserType type)
        {
            switch (type)
            {
                case BrowserType.Chrome:
                {
                    var options = new ChromeOptions();
                    options.AddArgument("--no-sandbox");
                    options.AddArgument("--browser-test");
                    options.Proxy = null;
                    return new ChromeDriver(
                        ChromeDriverService.CreateDefaultService(),
                        options, TimeSpan.FromMinutes(2));
                }
                case BrowserType.InternetExplorer:
                    var ieOptions = new InternetExplorerOptions
                        {IgnoreZoomLevel = true, IntroduceInstabilityByIgnoringProtectedModeSettings = true};

                    return new InternetExplorerDriver(ieOptions);

                case BrowserType.Firefox:
                {
                    var profile = new FirefoxProfile();
                    var options = new FirefoxOptions { Profile = profile };
                    options.SetPreference("security.enterprise_roots.enabled", true);
                    return new FirefoxDriver(options);
                }
                case BrowserType.Edge:
                    string executableLocation = Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().Location);
                    string edgeDriverLocation = Path.Combine(executableLocation ?? string.Empty, "Drivers\\");

                    if (string.IsNullOrEmpty(edgeDriverLocation))
                    {
                        throw new Exception("Edge driver not found");
                    }

                    var edgeOptions = new EdgeOptions();
                    edgeOptions.BinaryLocation = edgeDriverLocation + "msedgedriver.exe";
                    edgeOptions.AddArgument("--no-sandbox");
                    edgeOptions.AddArgument("--disable-dev-shm-usage");
                    edgeOptions.AddArgument("--browser-test");
                    edgeOptions.UseChromium = true;
                    
                    return new EdgeDriver(edgeDriverLocation, edgeOptions);

                default:
                {
                    Console.WriteLine(@"Unsupported browser type '{0}'. Falling back to Chrome.", type);
                    return new ChromeDriver();
                }
            }
        }

        public override void Cleanup()
        {
            TestCleanup();
        }
    }
}
