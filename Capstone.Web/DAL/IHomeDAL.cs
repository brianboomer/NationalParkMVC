using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface IHomeDAL
    {
	    IList<Park> GetAllParks();
	    Park GetParkDetails(string parkCode);
	    IList<Weather> GetFiveDayForecast(string parkCode);
	}
}
