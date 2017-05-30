using System;
using System.Collections.Generic;

namespace PortCDM.Code.Structs
{
	public struct PortCall
	{
		public string id {get;set;}
		public Vessel vessel {get;set;}
		public string arrivalDate {get;set;}

	    public bool Equals(PortCall other)
	    {
	        return string.Equals(id, other.id) && vessel.Equals(other.vessel) && string.Equals(arrivalDate, other.arrivalDate);
	    }

	    public override bool Equals(object obj)
	    {
	        if (ReferenceEquals(null, obj)) return false;
	        return obj is PortCall && Equals((PortCall) obj);
	    }

	    public override int GetHashCode()
	    {
	        unchecked
	        {
	            var hashCode = (id != null ? id.GetHashCode() : 0);
	            hashCode = (hashCode * 397) ^ vessel.GetHashCode();
	            hashCode = (hashCode * 397) ^ (arrivalDate != null ? arrivalDate.GetHashCode() : 0);
	            return hashCode;
	        }
	    }

	    public static bool operator ==(PortCall left, PortCall right)
	    {
	        return left.Equals(right);
	    }

	    public static bool operator !=(PortCall left, PortCall right)
	    {
	        return !left.Equals(right);
	    }
	}
}
