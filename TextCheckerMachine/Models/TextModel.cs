using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TextCheckerMachine.Models
{
    public class TextModel
    {
        public string Text { get; set; }

        public ActionType ActionToBePerformed { get; set; }
    }
}