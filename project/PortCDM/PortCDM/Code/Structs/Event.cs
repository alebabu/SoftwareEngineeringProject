using System;
using System.Collections.Generic;
namespace PortCDM_RestStructs
{
	public struct Event
	{
		public string id, subProcessId, startTime, endTime, componentType, eventDefinitionId, definitionName, definitionDescription;
		public Location from, toOrAt, to, at;
		public List<State> states;
	}
}
