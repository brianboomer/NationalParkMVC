using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult SurveySubmit()
        {
            return View();
        }

	    public IActionResult SurveyResults()
	    {
		    return View();
	    }

	}
}