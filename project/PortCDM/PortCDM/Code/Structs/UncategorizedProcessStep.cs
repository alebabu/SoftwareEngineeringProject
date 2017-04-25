using System;
using System.Collections.Generic;
namespace PortCDM_RestStructs
{
	public struct UncategorizedProcessStep
	{
		public string id, startTime, endTime, processStepDefinitionId, definitionName, definitionDescription, portCallId;
		public List<SubProcess> subProcesses;
	}
}
