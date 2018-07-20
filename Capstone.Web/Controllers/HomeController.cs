using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Http;

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

	    public IActionResult Detail(string parkCode, int? preference)
	    {
		    if (preference.HasValue)
		    {
			    HttpContext.Session.SetInt32("pref", (int) preference);
		    }

		    int? pref = HttpContext.Session.GetInt32("pref");

		    if (!pref.HasValue)
		    {
			    pref = 1;
			    HttpContext.Session.SetInt32("pref", (int)pref);
		    }

			//if (pref == 1)
		 //   {
			//	pref = "f";

		 //   }
		    if (pref != 1)
		    {
			    pref = 0;
		    }

			HttpContext.Session.SetInt32("pref", (int)pref);

			var park = dal.GetParkDetails(parkCode);
		    var forecast = dal.GetFiveDayForecast(parkCode);

		    //var temperaturePreference = ConvertTemperature();




			Tuple<Park,IList<Weather>,int> data = new Tuple<Park, IList<Weather>, int>(park, forecast, (int)pref);




			return View(data);
	    }

		//private string GetTemperaturePreference()
		//{
		//	string temperaturePreference = HttpContext.Session.Get()
		//}

		//public IActionResult ConvertTemperature(string parkCode, string preference)
		//{
		//	HttpContext.Session.SetString("pref", preference);

		//	return RedirectToAction("Detail", "Home", new { parkCode });
		//}

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
