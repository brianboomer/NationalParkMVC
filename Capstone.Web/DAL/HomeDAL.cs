using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class HomeDAL : IHomeDAL
    {
	    private string connectionString;

	    public HomeDAL(string connectionString)
	    {
		    this.connectionString = connectionString;
	    }

		public Dictionary<string,string> GetParkCodesAndNames()
	    {
			Dictionary<string,string> kvp = new Dictionary<string, string>();

		    string getResultsQuery = "SELECT parkCode, parkName FROM park;";

		    try
		    {
			    using (SqlConnection connection = new SqlConnection(connectionString))
			    {
				    connection.Open();

					SqlCommand retrieveResults = new SqlCommand(getResultsQuery,connection);

				    SqlDataReader reader = retrieveResults.ExecuteReader();

				    while (reader.Read())
				    {
						kvp.Add(Convert.ToString(reader["parkCode"]),Convert.ToString(reader["parkName"]));
				    }
			    }
		    }
		    catch (SqlException e)
		    {
			    throw;
		    }

		    return kvp;
	    }

	    public IList<Park> GetAllParks()
	    {
		    string getParksQuery = "SELECT * FROM park;";

			List<Park> parks = new List<Park>();

		    try
		    {
			    using (SqlConnection connection = new SqlConnection(connectionString))
			    {
					connection.Open();

				    SqlCommand retrieveParksCommand = new SqlCommand(getParksQuery, connection);

				    SqlDataReader reader = retrieveParksCommand.ExecuteReader();

				    while (reader.Read())
				    {
						Park park = new Park();

					    park.ParkCode = Convert.ToString(reader["parkCode"]);
					    park.ParkName = Convert.ToString((reader["parkName"]));
					    park.State = Convert.ToString((reader["state"]));
					    park.Acreage = Convert.ToInt32((reader["acreage"]));
					    park.ElevationInFeet = Convert.ToInt32((reader["elevationInFeet"]));
					    park.MilesOfTrail = Convert.ToInt32((reader["milesOfTrail"]));
					    park.NumberOfCampsites = Convert.ToInt32((reader["numberOfCampsites"]));
					    park.Climate = Convert.ToString((reader["climate"]));
					    park.YearFounded = Convert.ToInt32((reader["yearFounded"]));
					    park.AnnualVisitorCount = Convert.ToInt32((reader["annualVisitorCount"]));
					    park.InspirationalQuote = Convert.ToString((reader["inspirationalQuote"]));
					    park.InspirationalQuoteSource = Convert.ToString((reader["inspirationalQuoteSource"]));
					    park.ParkDescription = Convert.ToString((reader["parkDescription"]));
					    park.EntryFee = Convert.ToDecimal((reader["entryFee"]));
					    park.NumberOfAnimalSpecies = Convert.ToInt32((reader["numberOfAnimalSpecies"]));

						parks.Add(park);

				    }
			    }
		    }
		    catch (Exception ex)
			{ 
			    throw;
		    }

		    return parks;
	    }

	    public Park GetParkDetails(string pc)
	    {
		    string getParkDetailsQuery = "SELECT * FROM park WHERE parkCode = @parkCode;";

		    Park park = new Park();

		    try
		    {
			    using (SqlConnection connection = new SqlConnection(connectionString))
			    {
				    connection.Open();

				    SqlCommand retrieveParkCommand = new SqlCommand(getParkDetailsQuery, connection);

				    retrieveParkCommand.Parameters.AddWithValue("@parkCode", pc);

				    SqlDataReader reader = retrieveParkCommand.ExecuteReader();

				    while (reader.Read())
				    {
					    park.ParkCode = Convert.ToString(reader["parkCode"]);
					    park.ParkName = Convert.ToString((reader["parkName"]));
					    park.State = Convert.ToString((reader["state"]));
					    park.Acreage = Convert.ToInt32((reader["acreage"]));
					    park.ElevationInFeet = Convert.ToInt32((reader["elevationInFeet"]));
					    park.MilesOfTrail = Convert.ToInt32((reader["milesOfTrail"]));
					    park.NumberOfCampsites = Convert.ToInt32((reader["numberOfCampsites"]));
					    park.Climate = Convert.ToString((reader["climate"]));
					    park.YearFounded = Convert.ToInt32((reader["yearFounded"]));
					    park.AnnualVisitorCount = Convert.ToInt32((reader["annualVisitorCount"]));
					    park.InspirationalQuote = Convert.ToString((reader["inspirationalQuote"]));
					    park.InspirationalQuoteSource = Convert.ToString((reader["inspirationalQuoteSource"]));
					    park.ParkDescription = Convert.ToString((reader["parkDescription"]));
					    park.EntryFee = Convert.ToDecimal((reader["entryFee"]));
					    park.NumberOfAnimalSpecies = Convert.ToInt32((reader["numberOfAnimalSpecies"]));
				    }
			    }
		    }
		    catch (Exception ex)
		    {
			    throw;
		    }

		    return park;
	    }


	}
}
