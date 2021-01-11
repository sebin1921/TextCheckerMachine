using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TextCheckerMachine.UITests.SetUp
{
    public class BrowserConfiguration
    {
        protected string WebSiteUrl => $"{ConfigurationManager.AppSettings["webSiteHost"]}:{ConfigurationManager.AppSettings["webSitePort"]}";

        public string Title => WebDriver.Title;

        protected IWebDriver WebDriver => Hooks.WebDriver;

        protected void Goto(string url)
        {
            WebDriver.Url = url;
        }
    }
}
