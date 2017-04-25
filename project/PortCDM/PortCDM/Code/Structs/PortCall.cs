using System;
using System.Collections.Generic;

namespace PortCDM_RestStructs
{
	public struct PortCall
	{
		public string id {get;set;}
		public Vessel vessel {get;set;}
		public string portUnLocode {get;set;}
		public string arrivalDate {get;set;}
		public string createdAt {get;set;}
		public string lastUpdate {get;set;}
		public string startTime {get;set;}
		public string endTime {get;set;}
		public string processDefinitionId {get;set;}
		public List<ProcessStep> processSteps;
		public List<UncategorizedProcessStep> uncategorizedProcessSteps;
	}
}
