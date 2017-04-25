using System;
using System.Collections.Generic;

namespace PortCDM_RestStructs
{
	public struct PortCall
	{
		public string id;
		public Vessel vessel;
		public string portUnLocode;
		public string arrivalDate;
		public string createdAt;
		public string lastUpdate;
		public string startTime;
		public string endTime;
		public string processDefinitionId;
		public List<ProcessStep> processSteps;
		public List<UncategorizedProcessStep> uncategorizedProcessSteps;
	}
}
