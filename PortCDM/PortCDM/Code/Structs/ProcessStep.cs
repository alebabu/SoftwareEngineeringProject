using System;
using System.Collections.Generic;
namespace PortCDM_RestStructs
{
	public struct ProcessStep
	{
		public string id, endTime, startTime, processStepDefinitionId, definitionName, definitionDescription, portCallId;
		public List<SubProcess> subProcesses;
	}
}
