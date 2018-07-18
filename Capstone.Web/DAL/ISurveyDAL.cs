using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAL
    {

	    void AddSurveyResults(string parkCode, string emailAddress, string state, string activityLevel);
	    IList<Survey> GetSurveyResults();


    }
}
