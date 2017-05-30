using System;

namespace PortCDM.Code.Structs
{
    public struct Vessel
    {
        public string imo { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string callSign { get; set; }
        public string mmsi { get; set; }
        public string type { get; set; }
        public int stmVesselId { get; set; }
        public string photoURL { get; set; }
        public string portCallId { get; set; }
		public string arrivalDate { get; set;}
    }
}
