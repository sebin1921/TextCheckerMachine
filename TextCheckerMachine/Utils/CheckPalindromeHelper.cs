using HtmlAgilityPack;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using TextCheckerMachine.Models;

namespace TextCheckerMachine.Utils
{
    public static class CheckPalindromeHelper
    {
        private const string HtmlValidator = "</?\\w+((\\s+\\w+(\\s*=\\s*(?:\".*?\"|\'.*?\'|[^\'\">\\s]+))?)+\\s*|\\s*)/?>";

        public static ConcurrentDictionary<string, int> GetPalindromeList(string text)
        {
            var palindromeWordList = new ConcurrentDictionary<string, int>();
            var wordArray = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var word in wordArray)
            {
                if (CheckIfPalindrome(word))
                {
                    palindromeWordList.AddOrUpdate(word, 1, (s, i) => i+1);
                }
            }

            return palindromeWordList;
        }

        public static Dictionary<string, int> GetDuplicateWordList(string text)
        {
            var wordArray = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

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
           
        public static HtmlValidationResponse IsValidHTML(string inputText)
        {
            var htmlValidationResponse = new HtmlValidationResponse();
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(inputText);
            var parseErrors = htmlDocument.ParseErrors;
            if(parseErrors.Any())
            {
                htmlValidationResponse.error = parseErrors.FirstOrDefault().Reason;
                htmlValidationResponse.isValidHtml = false;
            }
            else
            {
                htmlValidationResponse.isValidHtml = true;
            }

            return htmlValidationResponse;
        }
    }
}