using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
	    private readonly IHomeDAL dal;

	    public HomeController(IHomeDAL dal)
	    {
		    this.dal = dal;
	    }

	    public IActionResult Index()
	    {
		    var parks = dal.GetAllParks();
	        return View(parks);
        }

	    public IActionResult Detail(string parkCode)
	    {

		    var park = dal.GetParkDetails(parkCode);
		    var forecast = dal.GetFiveDayForecast(parkCode);

			Tuple<Park,IList<Weather>> data = new Tuple<Park, IList<Weather>>(park, forecast);

			return View(data);
	    }

		public IActionResult GetParkWeather(string parkCode)
		{
			var forecast = dal.GetFiveDayForecast(parkCode);

			return RedirectToAction();
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
