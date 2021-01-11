using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace TextCheckerMachine.UITests.Pages
{
    public class HomePage :IDisposable
    {
        public IWebDriver WebDriver { get; }

        public HomePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public void Goto(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }
        
       public IWebElement Title => WebDriver.FindElement(By.LinkText("Text Checker Machine"));

       public IWebElement InputText => WebDriver.FindElement(By.Id("Request_Text"));

       public IWebElement PalindromesRadio => WebDriver.FindElement(By.Id("Palindromes"));

       public IWebElement HtmlValidationRadio => WebDriver.FindElement(By.Id("HtmlValidation"));

       public IWebElement DuplicateWordsRadio => WebDriver.FindElement(By.Id("DuplicateWords"));

       public IWebElement BtnSubmit => WebDriver.FindElement(By.CssSelector(".button"));

       public void ClickSubmit() => BtnSubmit.Click();

       public void FillValues(string inputText, string option)
       {
           InputText.SendKeys(inputText);
           switch (option)
           {
               case "Palindromes":
                   PalindromesRadio.Click();
                   break;
               case "HtmlValidation":
                   HtmlValidationRadio.Click();
                   break;
               case "DuplicateWords":
                   DuplicateWordsRadio.Click();
                   break;
           }
       }
      
       public ReadOnlyCollection<IWebElement> FindElementByText(string text)
       {
            return WebDriver.FindElements(By.XPath("//*[contains(text(),'" + text + "')]"));
       }

       public void Dispose()
       {
           WebDriver?.Dispose();
       }
    }
}
