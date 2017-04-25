using System;
using System.Collections.Generic;

namespace PortCDM_RestStructs
{
	public struct State
	{
		public string id, eventId, stateDefinitionId, definitionName, definitionDescription;
		public LocationStateDetails locationStateDetails;
		public ServiceStateDetails serviceStateDetails;
		public List<Statement> statements;
	}
}
