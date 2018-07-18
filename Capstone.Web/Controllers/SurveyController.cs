using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {


	    private readonly ISurveyDAL sdal;
	    private readonly IHomeDAL dal;

	    public SurveyController(IHomeDAL dal, ISurveyDAL sdal)
	    {
		    this.dal = dal;
			this.sdal = sdal;
		}
		
		public IActionResult SurveySubmit()
        {
			Survey survey = new Survey();

	        var codes = dal.GetAllParks();

	        var parkOptions = codes.Select(code => new SelectListItem() {Text = code.ParkName, Value = code.ParkCode});

	        ViewBag.ParkCodes = parkOptions;

            return View(survey);
        }

		[HttpGet]
	    public IActionResult SurveyResults()
		{
			var codes = dal.GetAllParks();

			var results = sdal.GetSurveyResults();

			var combinedResults = Tuple.Create(codes, results);
			


			return View(combinedResults);
	    }


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult SurveyResults(Survey survey)
	    {


			sdal.AddSurveyResults(survey.ParkCode, survey.EmailAddress, survey.State, survey.ActivityLevel);
			
			return RedirectToAction("SurveyResults", "Survey");
	    }

	}
}