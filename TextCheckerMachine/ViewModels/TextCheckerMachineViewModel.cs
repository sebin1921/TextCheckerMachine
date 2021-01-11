using TextCheckerMachine.Models;

namespace TextCheckerMachine.ViewModels
{
    /// <summary>
    /// Master class to hold request and response
    /// </summary>
    public class TextCheckerMachineViewModel
    {
        public TextCheckerMachineRequestModel Request { get; set; }

        public TextCheckerMachineResponseModel Response { get; set; }
    }
}