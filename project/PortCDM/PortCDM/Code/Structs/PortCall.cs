using System;
using System.Collections.Generic;

namespace PortCDM_RestStructs
{
	public struct PortCall
	{
		public string id {get;set;}
		public Vessel vessel {get;set;}
		public string arrivalDate {get;set;}
	}
}
