using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextCheckerMachine.Models
{
    public class Result
    {
        public ConcurrentDictionary<string, int> PalindromeList { get; set; }

        public Dictionary<string, int> DuplicateWordList { get; set; }

        public HtmlValidationResponse HtmlValidationResponse { get; set; }
    }
}