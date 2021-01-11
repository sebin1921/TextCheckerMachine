﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TextCheckerMachine.UITests.Feature
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("TextCheckerMachineActionTests")]
    public partial class TextCheckerMachineActionTestsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TextCheckerMachineActionTests.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "TextCheckerMachineActionTests", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test To find palindrome in a sentence")]
        [NUnit.Framework.CategoryAttribute("CleanUpBrowser")]
        [NUnit.Framework.TestCaseAttribute("Chrome", null)]
        [NUnit.Framework.TestCaseAttribute("Firefox", null)]
        [NUnit.Framework.TestCaseAttribute("InternetExplorer", null)]
        public virtual void TestToFindPalindromeInASentence(string browser, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CleanUpBrowser"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test To find palindrome in a sentence", null, @__tags);
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
 testRunner.Given(string.Format("I use \'{0}\' as a user agent", browser), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.When("I am on the start up page of the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 7
 testRunner.Then("Verify that the page title is \'Home Page\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 8
 testRunner.When("I find the \'Palindromes\' of text \'aabaa madam malayalam you aabaa\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Word",
                        "Count"});
            table1.AddRow(new string[] {
                        "aabaa",
                        "2"});
            table1.AddRow(new string[] {
                        "malayalam",
                        "1"});
            table1.AddRow(new string[] {
                        "madam",
                        "1"});
#line 9
 testRunner.Then("I get \'3\' unique palindromes as follows:", ((string)(null)), table1, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test To find palindrome in a sentence which  doesn\'t have palindromes")]
        [NUnit.Framework.CategoryAttribute("CleanUpBrowser")]
        [NUnit.Framework.TestCaseAttribute("Chrome", null)]
        [NUnit.Framework.TestCaseAttribute("Firefox", null)]
        [NUnit.Framework.TestCaseAttribute("InternetExplorer", null)]
        public virtual void TestToFindPalindromeInASentenceWhichDoesntHavePalindromes(string browser, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CleanUpBrowser"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test To find palindrome in a sentence which  doesn\'t have palindromes", null, @__tags);
#line 22
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 23
 testRunner.Given(string.Format("I use \'{0}\' as a user agent", browser), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.When("I am on the start up page of the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then("Verify that the page title is \'Home Page\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
 testRunner.When("I find the \'Palindromes\' of text \'I have a dog\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
 testRunner.Then("I get a message \'There is no Palindrome in the given text:\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test To find duplicate words in a sentence")]
        [NUnit.Framework.CategoryAttribute("CleanUpBrowser")]
        [NUnit.Framework.TestCaseAttribute("Chrome", null)]
        [NUnit.Framework.TestCaseAttribute("Firefox", null)]
        [NUnit.Framework.TestCaseAttribute("InternetExplorer", null)]
        [NUnit.Framework.TestCaseAttribute("Edge", null)]
        public virtual void TestToFindDuplicateWordsInASentence(string browser, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CleanUpBrowser"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test To find duplicate words in a sentence", null, @__tags);
#line 37
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 38
 testRunner.Given(string.Format("I use \'{0}\' as a user agent", browser), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.When("I am on the start up page of the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
 testRunner.Then("Verify that the page title is \'Home Page\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
 testRunner.When("I find the \'DuplicateWords\' of text \'bus car bus bus train car\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Word",
                        "Count"});
            table2.AddRow(new string[] {
                        "bus",
                        "3"});
            table2.AddRow(new string[] {
                        "car",
                        "2"});
#line 42
 testRunner.Then("I get the list duplicate as follows:", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test To find duplicate words in a sentence which  doesn\'t have duplicates")]
        [NUnit.Framework.CategoryAttribute("CleanUpBrowser")]
        [NUnit.Framework.TestCaseAttribute("Chrome", null)]
        [NUnit.Framework.TestCaseAttribute("Firefox", null)]
        [NUnit.Framework.TestCaseAttribute("InternetExplorer", null)]
        [NUnit.Framework.TestCaseAttribute("Edge", null)]
        public virtual void TestToFindDuplicateWordsInASentenceWhichDoesntHaveDuplicates(string browser, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CleanUpBrowser"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test To find duplicate words in a sentence which  doesn\'t have duplicates", null, @__tags);
#line 55
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 56
 testRunner.Given(string.Format("I use \'{0}\' as a user agent", browser), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 57
 testRunner.When("I am on the start up page of the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
 testRunner.Then("Verify that the page title is \'Home Page\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
 testRunner.When("I find the \'DuplicateWords\' of text \'I have a dog\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
 testRunner.Then("I get a message \'There is no duplicate words in the given text:\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test To find if text is a valid html")]
        [NUnit.Framework.CategoryAttribute("CleanUpBrowser")]
        [NUnit.Framework.TestCaseAttribute("Firefox", "<Html>", "false", null)]
        [NUnit.Framework.TestCaseAttribute("InternetExplorer", "<Html>", "false", null)]
        [NUnit.Framework.TestCaseAttribute("Firefox", "<Html></html>", "true", null)]
        [NUnit.Framework.TestCaseAttribute("InternetExplorer", "<Html></html>", "true", null)]
        [NUnit.Framework.TestCaseAttribute("Firefox", "<Html><html/> <bod", "false", null)]
        [NUnit.Framework.TestCaseAttribute("InternetExplorer", "<Html><html/> <bod", "false", null)]
        public virtual void TestToFindIfTextIsAValidHtml(string browser, string inputText, string result, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CleanUpBrowser"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test To find if text is a valid html", null, @__tags);
#line 70
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 71
 testRunner.Given(string.Format("I use \'{0}\' as a user agent", browser), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
 testRunner.When("I am on the start up page of the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
 testRunner.Then("Verify that the page title is \'Home Page\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
 testRunner.When(string.Format("I find if the text \'{0}\' is a valid html", inputText), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
 testRunner.Then(string.Format("I get the result \'{0}\'", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

