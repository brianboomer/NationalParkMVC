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

	    public IList<Survey> GetSurveyResults()
	    {

		    string getSurveyQuery = "SELECT parkCode, COUNT(parkCode) as voteTally FROM survey_result GROUP BY parkCode ORDER BY voteTally DESC";

			List<Survey> surveys = new List<Survey>();

		    try
		    {
			    using (SqlConnection connection = new SqlConnection(connectionString))
			    {
				    connection.Open();

				    SqlCommand retrieveSurveyCommand = new SqlCommand(getSurveyQuery, connection);

				    SqlDataReader reader = retrieveSurveyCommand.ExecuteReader();

				    while (reader.Read())
				    {
					    Survey survey = new Survey();

					    //survey.SurveyID = Convert.ToInt32(reader["surveyId"]);
					    survey.ParkCode = Convert.ToString(reader["parkCode"]);
					    //survey.EmailAddress = Convert.ToString(reader["emailAddress"]);
					    //survey.State = Convert.ToString(reader["state"]);
					    //survey.ActivityLevel = Convert.ToString(reader["activityLevel"]);

					    surveys.Add(survey);

				    }
			    }
		    }
		    catch (Exception ex)
		    {
			    throw;
		    }


			return surveys;
	    }
    }
}
