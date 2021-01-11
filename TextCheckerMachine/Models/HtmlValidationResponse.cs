namespace TextCheckerMachine.Models
{
    /// <summary>
    /// Holding the html validation action response
    /// </summary>
    public class HtmlValidationResponse
    {
        /// <summary>
        /// text is a valid html ?
        /// </summary>
        public bool IsValidHtml { get; set; }

        /// <summary>
        /// Error message is the text is not valid
        /// </summary>
        public string Error { get; set; }
    }
}