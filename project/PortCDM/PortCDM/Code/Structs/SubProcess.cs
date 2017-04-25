using System;
using System.Collections.Generic;
namespace PortCDM_RestStructs
{
	public struct SubProcess
	{
		public string id, processStepId, startTime, endTime, componentType, subprocessDefinitionId, definitionName, definitionDescription;
		public Location from, to, at;
		public List<Event> events;
	}
}
