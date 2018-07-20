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
using SessionCart.Web.Extensions;

namespace Capstone.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IHomeDAL dal;
		private const string Session_Key = "pref";

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
			TempPreference temperaturePreference = GetTempPreference(preference);

			var park = dal.GetParkDetails(parkCode);
			var forecast = dal.GetFiveDayForecast(parkCode);

			Tuple<Park, IList<Weather>, int> data = new Tuple<Park, IList<Weather>, int>(park, forecast, temperaturePreference.Preference);

			return View(data);
		}

		public IActionResult GetParkWeather(string parkCode)
		{
			var forecast = dal.GetFiveDayForecast(parkCode);

			return RedirectToAction();
		}

		private TempPreference GetTempPreference(int? preference)
		{
			TempPreference tempPreference = HttpContext.Session.Get<TempPreference>(Session_Key);

			if (tempPreference == null)
			{
				tempPreference = new TempPreference();
				tempPreference.Preference = 1;
				HttpContext.Session.Set(Session_Key, tempPreference);
			}
			else
			{
				if (preference.HasValue)
				{
					tempPreference.Preference = (int)preference;
					HttpContext.Session.Set(Session_Key, tempPreference);
				}
			}
			return tempPreference;
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
