using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace Capstone.Web.Models
{
	public class WeatherAPI 
	{
		public WeatherAPI(string zipCode)
		{
			SetCurrentURL(zipCode);
			xmlDocument = GetXML(CurrentURL);
		}

		public float GetTemp()
		{
			XmlNode temp_node = xmlDocument.SelectSingleNode("//temperature");
			XmlAttribute temp_value = temp_node.Attributes["value"];
			string temp_string = temp_value.Value;
			return float.Parse(temp_string);
		}

		private const string APIKEY = "b3def90c3b0421cd51dbbf219841b523";
		private string CurrentURL;
		private XmlDocument xmlDocument;

		private void SetCurrentURL(string location)
		{
			CurrentURL = "api.openweathermap.org/data/2.5/forecast?zip=" + location + "&mode=xml&units=metric&APPID=" + APIKEY;
		}

		private XmlDocument GetXML(string CurrentURL)
		{
			using (WebClient client = new WebClient())
			{
				string xmlContent = client.DownloadString(CurrentURL);
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(xmlContent);
				return xmlDocument;
			}
		}

	}

}

