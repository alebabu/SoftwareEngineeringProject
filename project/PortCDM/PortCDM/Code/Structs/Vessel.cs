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
		public string arrivalDate { get; set; }

        public bool Equals(Vessel other)
        {
            return string.Equals(imo, other.imo) && string.Equals(id, other.id) && string.Equals(name, other.name) && string.Equals(callSign, other.callSign) && string.Equals(mmsi, other.mmsi) && string.Equals(type, other.type) && stmVesselId == other.stmVesselId && string.Equals(photoURL, other.photoURL) && string.Equals(portCallId, other.portCallId) && string.Equals(arrivalDate, other.arrivalDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vessel && Equals((Vessel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (imo != null ? imo.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (id != null ? id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (callSign != null ? callSign.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (mmsi != null ? mmsi.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (type != null ? type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ stmVesselId;
                hashCode = (hashCode * 397) ^ (photoURL != null ? photoURL.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (portCallId != null ? portCallId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (arrivalDate != null ? arrivalDate.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Vessel left, Vessel right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vessel left, Vessel right)
        {
            return !left.Equals(right);
        }
    }
}