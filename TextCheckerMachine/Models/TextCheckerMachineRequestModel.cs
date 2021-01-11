using System.ComponentModel.DataAnnotations;

namespace TextCheckerMachine.Models
{
    /// <summary>
    /// Request coming from View
    /// </summary>
    public class TextCheckerMachineRequestModel
    {
        /// <summary>
        /// Input Text entered
        /// </summary>
        [Required(ErrorMessage = "Input text is required.")]
        public string Text { get; set; }

        /// <summary>
        /// Action to be performed on the text  
        /// </summary>
        [Required(ErrorMessage = "Action type is required")]
        public ActionType ActionToBePerformed { get; set; }
    }
}