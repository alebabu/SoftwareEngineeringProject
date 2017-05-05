using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace PortCDM_Filter
{
	public class Filter
	{
		FilterType filtertype;
		string filterdata;

		public Filter(FilterType type, string data)
		{
			filtertype = type;
			filterdata = data;
		}

		public FilterType getType()
		{
			return filtertype;
		}

		public string getData()
		{
			return filterdata;
		}

		//Converts a Filter to a JSON-formatted string
		public string toJson()
		{
			string json = "{\n\"type\":\"" + filtertype
				+ "\",\n\"element\":\"" + filterdata + "\"\n}";
			return json;
		}
	}
}

