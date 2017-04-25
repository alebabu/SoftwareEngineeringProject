using System;
namespace PortCDM_RestStructs
{
	public struct Statement
	{
		public string id, timeType, timeStatement, reportedAt, sourceMessageId, comment;
		public Actor reportedBy;
		public Location from, to, at;
	}
}
