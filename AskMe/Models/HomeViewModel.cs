using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AskMe.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            QuestionViewModels = new List<QuestionViewModel>();
        }

        public IList<QuestionViewModel> QuestionViewModels { get; set; }

    }
}