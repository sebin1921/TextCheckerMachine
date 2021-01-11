using System;
using System.Web.Mvc;
using TextCheckerMachine.Models;
using TextCheckerMachine.Utils;
using TextCheckerMachine.ViewModels;

namespace TextCheckerMachine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var textCheckerMachineViewModel = new TextCheckerMachineViewModel
            {
                Request = new TextCheckerMachineRequestModel
                {
                    ActionToBePerformed = ActionType.Palindromes,
                    Text = string.Empty
                    
                }
            };
            return View(textCheckerMachineViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(TextCheckerMachineViewModel modelData)
        {
            if (!ModelState.IsValid)
            {
                return View(modelData);
            }

            if (modelData.Request == null || string.IsNullOrEmpty(modelData.Request.Text))
            {
                throw new ArgumentNullException(nameof(modelData));
            }
            var textCheckerMachineViewModel = new TextCheckerMachineViewModel
            {
                Request = modelData.Request,
                Response = new TextCheckerMachineResponseModel()
            };

            switch (modelData.Request.ActionToBePerformed)
            {
                case ActionType.Palindromes:
                    textCheckerMachineViewModel.Response.PalindromeList = OperationHelper.GetPalindromeList(modelData.Request.Text.Trim());
                    break;

                case ActionType.HtmlValidation:
                    textCheckerMachineViewModel.Response.HtmlValidationResponse = OperationHelper.IsValidHtml(modelData.Request.Text);
                    break;

                case ActionType.DuplicateWords:
                    textCheckerMachineViewModel.Response.DuplicateWordList =
                        OperationHelper.GetDuplicateWordList(modelData.Request.Text.Trim());
                    break;
            }
            
            return View(textCheckerMachineViewModel);
        }
    }
}