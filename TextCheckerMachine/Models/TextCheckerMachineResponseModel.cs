using System.Collections.Generic;

namespace TextCheckerMachine.Models
{
    /// <summary>
    /// Action result response
    /// </summary>
    public class TextCheckerMachineResponseModel
    {
        /// <summary>
        /// Holding the palindrome word list from the input text
        /// </summary>
        public List<string> PalindromeList { get; set; }

        /// <summary>
        /// Holding the duplicate word list from the input text
        /// </summary>
        public Dictionary<string, int> DuplicateWordList { get; set; }

        /// <summary>
        /// Holding the html validation response
        /// </summary>
        public HtmlValidationResponse HtmlValidationResponse { get; set; }
    }
}