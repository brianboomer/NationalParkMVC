using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Models
{
    public class Survey
    {
		public int SurveyID { get; set; }
		public string ParkCode { get; set; }
		public string EmailAddress { get; set; }
		public string State { get; set; }
		public string ActivityLevel { get; set; }

	    public static List<SelectListItem> List = new List<SelectListItem>()
	    {
		    new SelectListItem() {Text = "Inactive", Value = "Inactive"},
		    new SelectListItem() {Text = "Sedentary", Value = "Sednetary"},
		    new SelectListItem() {Text = "Active", Value = "Active"},
		    new SelectListItem() {Text = "Extremely Active", Value = "Extremely Active"}
	    };

	    public static List<SelectListItem> StateList = new List<SelectListItem>()
	    {
		    new SelectListItem() {Text = "Alabama", Value = "Alabama"},
		    new SelectListItem() {Text = "Alaska", Value = "Alaska"},
		    new SelectListItem() {Text = "Arizona", Value = "Arizona"},
		    new SelectListItem() {Text = "Arkansas", Value = "Arkansas"},
		    new SelectListItem() {Text = "California", Value = "California"},
		    new SelectListItem() {Text = "Colorado", Value = "Colorado"},
		    new SelectListItem() {Text = "Connecticut", Value = "Connecticut"},
		    new SelectListItem() {Text = "Delaware", Value = "Delaware"},
			new SelectListItem() {Text = "District Of Columbia", Value = "District Of Columbia"},
		    new SelectListItem() {Text = "Florida", Value = "Florida"},
		    new SelectListItem() {Text = "Georgia", Value = "Georgia"},
		    new SelectListItem() {Text = "Hawaii", Value = "Hawaii"},
			new SelectListItem() {Text = "Idaho", Value = "Idaho"},
		    new SelectListItem() {Text = "Illinois", Value = "Illinois"},
		    new SelectListItem() {Text = "Indiana", Value = "Indiana"},
		    new SelectListItem() {Text = "Iowa", Value = "Iowa"},
			new SelectListItem() {Text = "Kansas", Value = "Kansas"},
		    new SelectListItem() {Text = "Kentucky", Value = "Kentucky"},
		    new SelectListItem() {Text = "Louisiana", Value = "Louisiana"},
		    new SelectListItem() {Text = "Maine", Value = "Maine"},
		    new SelectListItem() {Text = "Maryland", Value = "Maryland"},
		    new SelectListItem() {Text = "Massachusetts", Value = "Massachusetts"},
		    new SelectListItem() {Text = "Michigan", Value = "Michigan"},
		    new SelectListItem() {Text = "Minnesota", Value = "Minnesota"},
		    new SelectListItem() {Text = "Mississippi", Value = "Mississippi"},
		    new SelectListItem() {Text = "Missouri", Value = "Missouri"},
		    new SelectListItem() {Text = "Montana", Value = "Montana"},
		    new SelectListItem() {Text = "Nebraska", Value = "Nebraska"},
			new SelectListItem() {Text = "Nevada", Value = "Nevada"},
		    new SelectListItem() {Text = "New Hampshire", Value = "New Hampshire"},
		    new SelectListItem() {Text = "New Jersey", Value = "New Jersey"},
		    new SelectListItem() {Text = "New Mexico", Value = "New Mexico"},
			new SelectListItem() {Text = "New York", Value = "New York"},
		    new SelectListItem() {Text = "North Carolina", Value = "North Carolina"},
		    new SelectListItem() {Text = "North Dakota", Value = "North Dakota"},
		    new SelectListItem() {Text = "Ohio", Value = "Ohio"},
			new SelectListItem() {Text = "Oklahoma", Value = "Oklahoma"},
		    new SelectListItem() {Text = "Oregon", Value = "Oregon"},
		    new SelectListItem() {Text = "Pennsylvania", Value = "Pennsylvania"},
		    new SelectListItem() {Text = "Rhode Island", Value = "Rhode Island"},
		    new SelectListItem() {Text = "South Carolina", Value = "South Carolina"},
		    new SelectListItem() {Text = "South Dakota", Value = "South Dakota"},
			new SelectListItem() {Text = "Tennessee", Value = "Tennessee"},
		    new SelectListItem() {Text = "Texas", Value = "Texas"},
		    new SelectListItem() {Text = "Utah", Value = "Utah"},
		    new SelectListItem() {Text = "Vermont", Value = "Vermont"},
			new SelectListItem() {Text = "Virginia", Value = "Virginia"},
		    new SelectListItem() {Text = "Washington", Value = "Washington"},
		    new SelectListItem() {Text = "West Virginia", Value = "West Virginia"},
		    new SelectListItem() {Text = "Wisconsin", Value = "Wisconsin"},
		    new SelectListItem() {Text = "Wyoming", Value = "Wyoming"},
	    };
	}
}
