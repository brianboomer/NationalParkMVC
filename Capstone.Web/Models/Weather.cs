using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
		public string ParkCode { get; set; }
		public int Day { get; set; }
		public int Low { get; set; }
		public int High { get; set; }
		public string Forecast { get; set; }

	    public int HighC => (High - 32) * 5 / 9;
		public int LowC => (Low - 32) * 5 / 9;
    }
}
