using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace PortCDM.Code.Structs
{
	public class Filter
	{
	    private readonly FilterType filterType;
	    private readonly string filterData;

		public Filter(FilterType type, string data)
		{
			filterType = type;
			filterData = data;
		}

		//Converts a Filter to a JSON-formatted string
		public string toJson()
		{
			string json = "{\n\"type\":\"" + filterType
				+ "\",\n\"element\":\"" + filterData + "\"\n}";
			return json;
		}
	}
}

