using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortCDM.Code.Structs
{
    public struct PortLocation
    {
        public string name { get; set; }
        public string shortName { get; set; }
        public Position coordinates { get; set; }
        public string locationType { get; set; }
        public string URN { get; set; }

        public bool Equals(PortLocation other)
        {
            return string.Equals(name, other.name) && string.Equals(shortName, other.shortName) && Equals(coordinates, other.coordinates) && string.Equals(locationType, other.locationType) && string.Equals(URN, other.URN);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is PortLocation && Equals((PortLocation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (name != null ? name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (shortName != null ? shortName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (coordinates != null ? coordinates.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (locationType != null ? locationType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (URN != null ? URN.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(PortLocation left, PortLocation right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PortLocation left, PortLocation right)
        {
            return !left.Equals(right);
        }
    }
}