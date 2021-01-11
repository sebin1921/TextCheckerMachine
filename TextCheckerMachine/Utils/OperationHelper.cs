using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using TextCheckerMachine.Models;

namespace TextCheckerMachine.Utils
{
    public static class OperationHelper
    {
        public static List<string> GetPalindromeList(string text)
        {
            var palindromeWordList = new List<string>();
            var wordArray = text.ToLower().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var word in wordArray)
            {
                if (!CheckIfPalindrome(word)) continue;
                if (!palindromeWordList.Contains(word))
                {
                    palindromeWordList.Add(word);
                }
            }

            return palindromeWordList;
        }

        public static Dictionary<string, int> GetDuplicateWordList(string text)
        {
            var wordArray = text.ToLower().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (var grouping in wordArray.GroupBy(word => word))
            {
                if (grouping.Count() > 1)
                {
                    dictionary.Add(grouping.Key, grouping.Count());
                }
            }

            return dictionary; // number of occurrences is the value
        }

        private static bool CheckIfPalindrome(string word)
        {
            var wordLength = word.Length;

            //// If the word length is one or two then it is not a palindrome
            if (wordLength == 0 || wordLength == 1 || wordLength == 2)
            {
                return false;
            }

            var first = word.Substring(0, word.Length / 2);
            var arr = word.ToCharArray();

            Array.Reverse(arr);

            var temp = new string(arr);
            var second = temp.Substring(0, temp.Length / 2);

            return first.Equals(second);
        }
           
        public static HtmlValidationResponse IsValidHtml(string inputText)
        {
            var htmlValidationResponse = new HtmlValidationResponse();
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(inputText);
            var hasHead = htmlDocument.DocumentNode.SelectSingleNode("html") != null;
            if (!hasHead)
            {
                htmlValidationResponse.Error = "Missing '<Html>'tag";
                htmlValidationResponse.IsValidHtml = false;
                return htmlValidationResponse;
            }
            var parseErrors = htmlDocument.ParseErrors;
            var htmlParseErrors = parseErrors as HtmlParseError[] ?? parseErrors.ToArray();
            if(htmlParseErrors.Any())
            {
                htmlValidationResponse.Error = htmlParseErrors.FirstOrDefault()?.Reason;
                htmlValidationResponse.IsValidHtml = false;
            }
            else
            {
                htmlValidationResponse.IsValidHtml = true;
            }

            return htmlValidationResponse;
        }
    }
}