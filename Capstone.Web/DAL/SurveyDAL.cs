using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class SurveyDAL : ISurveyDAL
    {
	    private string connectionString;

	    public SurveyDAL(string connectionString)
	    {
		    this.connectionString = connectionString;
	    }

	    public void AddSurveyResults(string parkCode, string emailAddress, string state, string activityLevel)
	    {
		    string addSurveyQuery =
			    "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @emailAddress, @state, @activityLevel);";
		    try
		    {
			    using (SqlConnection connection = new SqlConnection(connectionString))
			    {
					connection.Open();

					SqlCommand command = new SqlCommand(addSurveyQuery, connection);

				    command.Parameters.AddWithValue("@parkCode", parkCode);
				    command.Parameters.AddWithValue("@emailAddress", emailAddress);
				    command.Parameters.AddWithValue("@state", state);
				    command.Parameters.AddWithValue("@activityLevel", activityLevel);

				    command.ExecuteNonQuery();
			    }
		    }
		    catch (SqlException e)
		    {
			    Console.WriteLine(e);
			    throw;
		    }


	    }

	    public IList<SurveyResult> GetSurveyResults()
	    {

		    string getSurveyQuery =
				"SELECT parkName, park.parkCode as codeOfPark, COUNT(parkName) as voteTally FROM survey_result INNER JOIN park ON park.parkCode = survey_result.parkCode GROUP BY parkName, park.parkCode ORDER BY voteTally DESC;";

			List<SurveyResult> surveyResults = new List<SurveyResult>();

		    try
		    {
			    using (SqlConnection connection = new SqlConnection(connectionString))
			    {
				    connection.Open();

				    SqlCommand retrieveSurveyCommand = new SqlCommand(getSurveyQuery, connection);

				    SqlDataReader reader = retrieveSurveyCommand.ExecuteReader();

				    while (reader.Read())
				    {
					    SurveyResult surveyResult = new SurveyResult();

					    surveyResult.ParkName = Convert.ToString(reader["parkName"]);
					    surveyResult.ParkCode = Convert.ToString(reader["codeOfPark"]);
					    surveyResult.VoteTally = Convert.ToInt32(reader["voteTally"]);

					    surveyResults.Add(surveyResult);

				    }
			    }
		    }
		    catch (Exception ex)
		    {
			    throw;
		    }


			return surveyResults;
	    }
    }
}
