using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Moq;
using TextCheckerMachine.Controllers;
using TextCheckerMachine.Models;
using TextCheckerMachine.ViewModels;

namespace TextCheckerMachine.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<HomeController> _homeControllerMock;
        private HomeController _homeController;

        [TestInitialize]
        public void TestInitialize()
        {
            _homeControllerMock =  new Mock<HomeController>();
            
            _homeController = new HomeController();
        }

        [TestMethod]
        public void Index_WithOutMock()
        {
            // Act
            ViewResult result = _homeController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_Invalid_InputFor_DefaultController()
        {
            Assert.IsNull(_homeControllerMock.Object.Index());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "modelData")]
        public void Test_Empty_Request_PostController()
        {
            _homeControllerMock.Object.Index(new TextCheckerMachineViewModel());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "modelData")]
        public void Test_Empty_InputText_PostController()
        {
            _homeControllerMock.Object.Index(
                new TextCheckerMachineViewModel
                {
                    Request = new TextCheckerMachineRequestModel
                    {
                        Text = string.Empty,
                        ActionToBePerformed = ActionType.HtmlValidation
                    }
                });
        }

        #region Palindromes Action tests

        [TestMethod]
        public void Success_TextWithPalindrome_Test()
        {
            const string inputText = "aabaa Madam test madam";
            var expectedResult = new List<string> {"aabaa", "madam"};

            var result = _homeController.Index(
                new TextCheckerMachineViewModel
                {
                    Request = new TextCheckerMachineRequestModel
                    {
                        Text = inputText,
                        ActionToBePerformed = ActionType.Palindromes
                    }
                }) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            var modelResponse = ((TextCheckerMachineViewModel) result.Model).Response;
            Assert.IsNotNull(modelResponse);
            Assert.IsNull(modelResponse.DuplicateWordList);
            Assert.IsNull(modelResponse.HtmlValidationResponse);
            Assert.AreEqual(modelResponse.PalindromeList.Count, 2);
            foreach (var expected in expectedResult)
            {
                Assert.IsTrue(modelResponse.PalindromeList.Contains(expected));
            }
        }

        [TestMethod]
        public void Success_TextWithOutPalindrome_Test()
        {
            const string inputText = "test mad";
            
            var result = _homeController.Index(
                new TextCheckerMachineViewModel
                {
                    Request = new TextCheckerMachineRequestModel
                    {
                        Text = inputText,
                        ActionToBePerformed = ActionType.Palindromes
                    }
                }) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            var modelResponse = ((TextCheckerMachineViewModel)result.Model).Response;
            Assert.IsNotNull(modelResponse);
            Assert.IsNull(modelResponse.DuplicateWordList);
            Assert.IsNull(modelResponse.HtmlValidationResponse);
            Assert.AreEqual(modelResponse.PalindromeList.Count, 0);
        }

        [TestMethod]
        public void Fail_Palindrome_TextWithMinimumLength_Test()
        {
            const string inputText = "to";

            var result = _homeController.Index(
                new TextCheckerMachineViewModel
                {
                    Request = new TextCheckerMachineRequestModel
                    {
                        Text = inputText,
                        ActionToBePerformed = ActionType.Palindromes
                    }
                }) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            var modelResponse = ((TextCheckerMachineViewModel)result.Model).Response;
            Assert.IsNotNull(modelResponse);
            Assert.IsNull(modelResponse.DuplicateWordList);
            Assert.IsNull(modelResponse.HtmlValidationResponse);
            Assert.AreEqual(modelResponse.PalindromeList.Count, 0);
        }

        #endregion Palindromes Action tests

        #region Duplicate word Action tests

        [TestMethod]
        public void Success_TextWithDuplicateWord_Test()
        {
            const string inputText = "This a my test  This is not test test";
            var expectedResult = new Dictionary<string, int> {{"this", 2}, {"test", 3}};

            var result = _homeController.Index(
                new TextCheckerMachineViewModel
                {
                    Request = new TextCheckerMachineRequestModel
                    {
                        Text = inputText,
                        ActionToBePerformed = ActionType.DuplicateWords
                    }
                }) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            var modelResponse = ((TextCheckerMachineViewModel)result.Model).Response;
            Assert.IsNotNull(modelResponse);
            Assert.IsNull(modelResponse.PalindromeList);
            Assert.IsNull(modelResponse.HtmlValidationResponse);
            Assert.AreEqual(modelResponse.DuplicateWordList.Count, 2);
            Assert.AreEqual(ToStringToAssert(modelResponse.DuplicateWordList), ToStringToAssert(expectedResult));
        }

        [TestMethod]
        public void Success_TextWithOutDuplicateWord_Test()
        {
            const string inputText = "This a my test";
            
            var result = _homeController.Index(
                new TextCheckerMachineViewModel
                {
                    Request = new TextCheckerMachineRequestModel
                    {
                        Text = inputText,
                        ActionToBePerformed = ActionType.DuplicateWords
                    }
                }) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            var modelResponse = ((TextCheckerMachineViewModel)result.Model).Response;
            Assert.IsNotNull(modelResponse);
            Assert.IsNull(modelResponse.PalindromeList);
            Assert.IsNull(modelResponse.HtmlValidationResponse);
            Assert.AreEqual(modelResponse.DuplicateWordList.Count, 0);
        }

        #endregion Duplicate word Action tests

        #region Validate html action

        [TestMethod]
        public void Success_TextWithValidHtml_Test()
        {
            const string inputText = "<html></html>";

            var result = _homeController.Index(
                new TextCheckerMachineViewModel
                {
                    Request = new TextCheckerMachineRequestModel
                    {
                        Text = inputText,
                        ActionToBePerformed = ActionType.HtmlValidation
                    }
                }) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            var modelResponse = ((TextCheckerMachineViewModel)result.Model).Response;
            Assert.IsNotNull(modelResponse);
            Assert.IsNull(modelResponse.PalindromeList);
            Assert.IsNull(modelResponse.DuplicateWordList);
            Assert.IsNotNull(modelResponse.HtmlValidationResponse);
            Assert.IsTrue(modelResponse.HtmlValidationResponse.IsValidHtml);
        }
        
        [TestMethod]
        public void Fail_TextWithNoHtmlHead_Test()
        {
            const string inputText = "</html>";

            var result = _homeController.Index(
                new TextCheckerMachineViewModel
                {
                    Request = new TextCheckerMachineRequestModel
                    {
                        Text = inputText,
                        ActionToBePerformed = ActionType.HtmlValidation
                    }
                }) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            var modelResponse = ((TextCheckerMachineViewModel)result.Model).Response;
            Assert.IsNotNull(modelResponse);
            Assert.IsNull(modelResponse.PalindromeList);
            Assert.IsNull(modelResponse.DuplicateWordList);
            Assert.IsNotNull(modelResponse.HtmlValidationResponse);
            Assert.IsFalse(modelResponse.HtmlValidationResponse.IsValidHtml);
            Assert.AreEqual(modelResponse.HtmlValidationResponse.Error, "Missing '<Html>'tag");
        }

        [TestMethod]
        public void Fail_TextWithMissingEndTag_Test()
        {
            const string inputText = "<html></html><body>";

            var result = _homeController.Index(
                new TextCheckerMachineViewModel
                {
                    Request = new TextCheckerMachineRequestModel
                    {
                        Text = inputText,
                        ActionToBePerformed = ActionType.HtmlValidation
                    }
                }) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            var modelResponse = ((TextCheckerMachineViewModel) result.Model).Response;
            Assert.IsNotNull(modelResponse);
            Assert.IsNull(modelResponse.PalindromeList);
            Assert.IsNull(modelResponse.DuplicateWordList);
            Assert.IsNotNull(modelResponse.HtmlValidationResponse);
            Assert.IsFalse(modelResponse.HtmlValidationResponse.IsValidHtml);
            Assert.AreEqual(modelResponse.HtmlValidationResponse.Error, "End tag </body> was not found");
        }
        

        #endregion Validate html action
        
        private string ToStringToAssert(Dictionary<string, int> dictionary)
        {
            var pairStrings = dictionary.OrderBy(p => p.Key)
                .Select(p => p.Key + ": " + string.Join(", ", p.Value));
            return string.Join("; ", pairStrings);
        }
    }
}
