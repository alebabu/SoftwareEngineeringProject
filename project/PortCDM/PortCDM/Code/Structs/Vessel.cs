using System;

namespace PortCDM_RestStructs
{
	public struct Vessel
	{
		public string imo { get; set; }
		public string id;
		public string name {get;set;}
		public string callSign;
		public string mmsi;
		public string type;
		public int stmVesselId;
		public string photoURL {get;set;}
	}
}
